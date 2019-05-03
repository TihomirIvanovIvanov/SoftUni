namespace PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var pets = new List<Pet>();
            var clinics = new List<Clinic>();

            var commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                var commandInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var command = commandInput[0];

                switch (command)
                {
                    case "Create":
                        {
                            try
                            {
                                var type = commandInput[1];
                                if (type == "Pet")
                                {
                                    var name = commandInput[2];
                                    var age = int.Parse(commandInput[3]);
                                    var kind = commandInput[4];

                                    var pet = new Pet(name, age, kind);
                                    pets.Add(pet);
                                }
                                else
                                {
                                    var clinicName = commandInput[2];
                                    var roomCount = int.Parse(commandInput[3]);

                                    var clinic = new Clinic(clinicName, roomCount);
                                    clinics.Add(clinic);
                                }
                            }
                            catch (InvalidOperationException ioe)
                            {
                                Console.WriteLine(ioe.Message);
                            }
                            break;
                        }
                    case "Add":
                        {
                            var name = commandInput[1];
                            var petToAdd = pets.FirstOrDefault(p => p.Name == name);

                            var clinicName = commandInput[2];
                            var clinicToAdd = clinics.FirstOrDefault(p => p.Name == clinicName);

                            Console.WriteLine(clinicToAdd.Add(petToAdd));
                            break;
                        }
                    case "Release":
                        {
                            var clinicName = commandInput[1];
                            var clinicToRelease = clinics.FirstOrDefault(c => c.Name == clinicName);
                            Console.WriteLine(clinicToRelease.Release());
                            break;
                        }
                    case "HasEmptyRooms":
                        {
                            var clinicName = commandInput[1];
                            var clinicToChech = clinics.FirstOrDefault(c => c.Name == clinicName);
                            Console.WriteLine(clinicToChech.HasEmptyRooms);
                            break;
                        }
                    case "Print":
                        {
                            var clinicName = commandInput[1];
                            var clinicToPrint = clinics.FirstOrDefault(c => c.Name == clinicName);
                            if (commandInput.Length == 3)
                            {
                                var roomNumber = int.Parse(commandInput[2]);
                                Console.WriteLine(clinicToPrint.Print(roomNumber));
                            }
                            else
                            {
                                Console.WriteLine(clinicToPrint.PrintAll());
                            }
                            break;
                        }
                }
            }
        }
    }
}