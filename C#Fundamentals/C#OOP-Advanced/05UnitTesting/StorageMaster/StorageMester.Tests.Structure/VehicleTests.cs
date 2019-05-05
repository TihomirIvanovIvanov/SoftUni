namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Entities.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class VehicleTests
    {
        private Type vehicle;

        [SetUp]
        public void SetUp()
        {
            this.vehicle = this.GetType("Vehicle");
        }

        //Validte Entities
        [Test]
        public void ValidateAllVehicles()
        {
            var types = new[]
            {
                "Semi",
                "Van",
                "Truck",
                "Vehicle"
            };

            foreach (var type in types)
            {
                var currentType = GetType(type);

                Assert.That(currentType, Is.Not.Null, $"{type} doesnt exist");
            }
        }

        [Test]
        public void ValidateVihiclesProp()
        {
            var actualProp = this.vehicle.GetProperties();
            var expectedProp = new Dictionary<string, Type>
            {
                //new[] { "Capacity", "Trunk", "IsFull", "IsEmpty" };

                { "Capacity", typeof(int) },
                { "Trunk", typeof(IReadOnlyCollection<Product>) },
                { "IsFull", typeof(bool) },
                { "IsEmpty", typeof(bool) }
            };

            foreach (var actual in actualProp)
            {
                var isValidProp = expectedProp.Any
                    (x => x.Key == actual.Name &&
                          x.Value == actual.PropertyType);

                Assert.That(isValidProp, $"{actual.Name} doesnt exist!");
            }
        }

        //void LoadProduct(Product product)
        //Product Unload()
        [Test]
        public void ValidateVihicleMethods()
        {
            var expectedMethods = new List<Method>
            {
                new Method(typeof(void), "LoadProduct", typeof(Product)),
                new Method(typeof(Product), "Unload")
            };

            foreach (var method in expectedMethods)
            {
                var currentMethod = this.vehicle.GetMethod(method.Name);
                Assert.That(currentMethod, Is.Not.Null, $"{method.Name} Method doesnt exist");

                var currentMethodReturnType = currentMethod.ReturnType == method.ReturnType;

                Assert.That(currentMethodReturnType, $"{method.Name} Method invalid return type");

                var expectedMethodParams = method.InputParameters;
                var actualParams = currentMethod.GetParameters();

                for (int i = 0; i < expectedMethodParams.Length; i++)
                {
                    var actualParam = actualParams[i].ParameterType;
                    var expectedParam = expectedMethodParams[i];

                    Assert.AreEqual(expectedParam, actualParam);
                }
            }
        }

        [Test]
        public void ValidateVehicleFields()
        {
            var trunkFields = this.vehicle.GetField("trunk", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.That(trunkFields, Is.Not.Null, $"Invalid field");
        }

        [Test]
        public void ValidateVihicleIsAbastract()
        {
            Assert.That(this.vehicle.IsAbstract, "Vehicle type must be abstract");
        }

        [Test]
        public void ValidateVehicleChildClasses()
        {
            var derivedTypes = new[]
            {
                GetType("Semi"),
                GetType("Truck"),
                GetType("Van"),
            };

            foreach (var type in derivedTypes)
            {
                Assert.That(type.BaseType, Is.EqualTo(this.vehicle), $"{type} doesnt inherit {this.vehicle}");
            }
        }

        [Test]
        public void ValidateVehicleCtor()
        {
            var ctor = this.vehicle.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault();

            Assert.That(ctor, Is.Not.Null, "Constructor doesnt exist");

            var ctorParams = ctor.GetParameters();

            Assert.That(ctorParams[0].ParameterType, Is.EqualTo(typeof(int)));
        }

        private Type GetType(string type)
        {
            var targetType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            return targetType;
        }

        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputParameters)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputParameters = inputParameters;
            }

            public Type ReturnType { get; set; }

            public string Name { get; set; }

            public Type[] InputParameters { get; set; }
        }
    }
}
