namespace StorageMester.BusinessLogic.Tests
{
    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class StorageMesterTests
    {
        private Type storageMaster;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = this.GetType("StorageMaster");
        }

        [Test]
        public void ValidateAddProductMethod()
        {
            var addProductMethod = storageMaster.GetMethod("AddProduct");

            var instance = Activator.CreateInstance(storageMaster);
            var productType = "SolidStateDrive";
            var price = 230.43;

            var actualResult = addProductMethod.Invoke(instance, new object[] { productType, price });
            var expectedResult = $"Added {productType} to pool";

            Assert.AreEqual(expectedResult, actualResult);

            var productsPoolField = (IDictionary<string, Stack<Product>>)storageMaster
                .GetField("productsPool", (BindingFlags)62)
                .GetValue(instance);

            Assert.That(productsPoolField[productType].Count, Is.EqualTo(1));
        }

        [Test]
        public void ValidateRegisterStorageMaster()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");

            var instance = Activator.CreateInstance(storageMaster);
            var storageType = "DistributionCenter";
            var name = "Gosho";

            var actualResult = registerStorageMethod.Invoke(instance, new object[] { storageType, name });
            var expectedResult = $"Registered Gosho";

            Assert.AreEqual(expectedResult, actualResult);

            var storageRegistryField = (IDictionary<string, Storage>)storageMaster
               .GetField("storageRegistry", (BindingFlags)62)
               .GetValue(instance);

            Assert.That(storageRegistryField[name].Name, Is.EqualTo(name));
        }

        [Test]
        public void ValidateSendVehicleToMethod()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");

            var instance = Activator.CreateInstance(storageMaster);

            var firstStorageType = "DistributionCenter";
            var firstName = "Gosho";

            var secondStorageType = "AutomatedWarehouse";
            var secondName = "Pesho";

            registerStorageMethod.Invoke(instance, new object[] { firstStorageType, firstName });
            registerStorageMethod.Invoke(instance, new object[] { secondStorageType, secondName });

            var actualResult = storageMaster.GetMethod("SendVehicleTo")
                .Invoke(instance, new object[] { firstName, 0, secondName });

            var expectedResult = $"Sent Van to Pesho (slot 1)";

            Assert.AreEqual(expectedResult, actualResult);
        }

        private Type GetType(string type)
        {
            var targetType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            return targetType;
        }
    }
}
