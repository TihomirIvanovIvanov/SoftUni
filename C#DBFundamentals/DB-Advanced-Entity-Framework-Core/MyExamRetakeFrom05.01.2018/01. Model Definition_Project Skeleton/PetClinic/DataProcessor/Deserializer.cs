namespace PetClinic.DataProcessor
{
    using System;

    using PetClinic.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;
    using PetClinic.DataProcessor.Dto.Import;
    using PetClinic.Models;
    using System.Linq;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Deserializer
    {
        private const string FailureMessage = "Error: Invalid data.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializeAnimalsAids = JsonConvert.DeserializeObject<AnimalAidDto[]>(jsonString);
            var validAnimalsAids = new List<AnimalAid>();

            foreach (var animalsDto in deserializeAnimalsAids)
            {
                if (!IsValid(animalsDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var animalExist = validAnimalsAids.Any(n => n.Name == animalsDto.Name);
                if (animalExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var animal = new AnimalAid()
                {
                    Name = animalsDto.Name,
                    Price = animalsDto.Price,
                };

                validAnimalsAids.Add(animal);
                sb.AppendLine(string.Format(SuccessMessage, $"{animal.Name}"));
            }
            context.AnimalAids.AddRange(validAnimalsAids);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var animalsJson = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            var sb = new StringBuilder();

            var animals = new List<Animal>();

            foreach (var animal in animalsJson)
            {
                if (!IsValid(animal) || !IsValid(animal.Passport))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool serialNumberMatch = Regex.IsMatch(animal.Passport.SerialNumber, @"^([A-Za-z]{7})+(\d{3})$");
                bool phoneNumberMatch = Regex.IsMatch(animal.Passport.OwnerPhoneNumber, @"^(\+359|0)+(\d{9})$");

                if (!serialNumberMatch || !phoneNumberMatch)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool passportExists = animals.Any(a => a.Passport.SerialNumber == animal.Passport.SerialNumber);
                bool passportExistsDb = context.Passports.Any(p => p.SerialNumber == animal.Passport.SerialNumber);

                if (passportExists || passportExistsDb)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                animals.Add(new Animal
                {
                    Name = animal.Name,
                    Type = animal.Type,
                    Age = animal.Age,
                    Passport = new Passport
                    {
                        SerialNumber = animal.Passport.SerialNumber,
                        OwnerName = animal.Passport.OwnerName,
                        OwnerPhoneNumber = animal.Passport.OwnerPhoneNumber,
                        RegistrationDate = DateTime.ParseExact(animal.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                    }
                });
                sb.AppendLine($"Record {animal.Name} Passport №: {animal.Passport.SerialNumber} successfully imported.");
            }
            context.AddRange(animals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));
            var deserializeVets = (VetDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            var validVets = new List<Vet>();

            foreach (var vetsDto in deserializeVets)
            {
                if (!IsValid(vetsDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var phoneNumberExist = validVets.Any(v => v.PhoneNumber == vetsDto.PhoneNumber);
                var phoneNumberExistDb = context.Vets.Any(v => v.PhoneNumber == vetsDto.PhoneNumber);

                if (phoneNumberExist || phoneNumberExistDb)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var vets = new Vet()
                {
                    Name = vetsDto.Name,
                    Profession = vetsDto.Profession,
                    Age = vetsDto.Age,
                    PhoneNumber = vetsDto.PhoneNumber,
                };

                validVets.Add(vets);
                sb.AppendLine(string.Format(SuccessMessage, $"{vets.Name}"));
            }
            context.Vets.AddRange(validVets);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ProcedureDto[]), new XmlRootAttribute("Procedures"));
            var deserializeProcedure = (ProcedureDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            var validProcedure = new List<Procedure>();

            foreach (var procedureDto in deserializeProcedure)
            {
                if (!IsValid(procedureDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var vetExist = context.Vets.SingleOrDefault(v => v.Name == procedureDto.Vet);
                var serialNumberExist = context.Animals.SingleOrDefault(a => a.PassportSerialNumber == procedureDto.Animal);
                var animalAidExist = context.AnimalAids.SingleOrDefault(a => a.Name == procedureDto.AnimalAid.Name);

                if (vetExist != null || serialNumberExist != null || animalAidExist != null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var date = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                var procedure = new Procedure()
                {
                    Vet = vetExist,
                    Animal = serialNumberExist,
                    DateTime = date,
                };
                
            }

            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool result = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return result;
        }
    }
}
