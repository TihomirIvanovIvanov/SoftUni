namespace PetClinic.DataProcessor
{
    using System;

    using PetClinic.Data;
    using System.Linq;
    using PetClinic.DataProcessor.Dto.Export;
    using System.Globalization;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var date = "dd-MM-yyyy";

            var animals = context.Animals
                .Where(on => on.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(a => new AnimalDto()
                {
                    OwnerName = a.Passport.OwnerName,
                    AnimalName = a.Name,
                    Age = a.Age,
                    SerialNumber = a.Passport.SerialNumber,
                    RegisteredOn = a.Passport.RegistrationDate.ToString(date, CultureInfo.InvariantCulture),
                })
                .OrderBy(a => a.Age)
                .ThenBy(s => s.SerialNumber)
                .ToArray();

            var json = JsonConvert.SerializeObject(animals, Formatting.Indented);
            return json;

        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            throw new NotImplementedException();
        }
    }
}
