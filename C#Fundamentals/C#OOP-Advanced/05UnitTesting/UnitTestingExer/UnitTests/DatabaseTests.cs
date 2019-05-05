namespace DatabaseTests
{
    using Database;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void CtorShouldWorkWithCollection()
        {
            var database = new Database(new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(6, database.Fetch());
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { -1, -2, -3, -4 })]

        public void TestIfConstructorIsValid(int[] data)
        {
            Database db = new Database(data);

            var field = GetFieldInfo(db, typeof(int[]));

            var actualValues = (int[])field.GetValue(db);
            var buffer = new int[actualValues.Length - data.Length];

            //Assert.That(actualValues, Is.EquivalentTo(data.Concat(buffer)));
            Assert.AreEqual(data.Concat(buffer), actualValues);
        }

        [Test]
        public void TestInvalidConstructor()
        {
            var data = new int[17];

            Assert.That(() => new Database(data),
                Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        [TestCase(100)]
        [TestCase(-100)]

        public void TestAddMethodValid(int value)
        {
            var db = new Database();

            db.Add(value);

            var valuesInfo = GetFieldInfo(db, typeof(int[]));
            var currentIndexInfo = GetFieldInfo(db, typeof(int));

            var firstValue = ((int[])valuesInfo.GetValue(db)).First();
            var valueCount = (int)currentIndexInfo.GetValue(db);

            Assert.AreEqual(value, firstValue);
            Assert.AreEqual(1, valueCount);
        }

        [Test]
        public void TestAddMethodInvalid()
        {
            var data = new int[16];
            var db = new Database(data);

            var currentIndexInfo = GetFieldInfo(db, typeof(int));
            currentIndexInfo.SetValue(db, 16);

            Assert.That(() => db.Add(1),
                Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0 })]

        public void TestRemoveMethodValid(int[] data)
        {
            var db = new Database(data);

            var field = GetFieldInfo(db, typeof(int[]));
            field.SetValue(db, data);

            var currentIndexInfo = GetFieldInfo(db, typeof(int));
            currentIndexInfo.SetValue(db, data.Length);

            db.Remove();

            var actualValues = (int[])field.GetValue(db);
            var buffer = new int[actualValues.Length - (data.Length - 1)];
            data = data.Take(data.Length - 1).Concat(buffer).ToArray();

            Assert.AreEqual(data, actualValues);
        }

        [Test]
        public void TestRemoveMethodInvalid()
        {
            var db = new Database();

            var currentIndexInfo = GetFieldInfo(db, typeof(int));
            currentIndexInfo.SetValue(db, 0);

            Assert.That(() => db.Remove(),
                Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0 })]

        public void TestFetchMethodValid(int[] data)
        {
            var db = new Database(data);

            var fetchedValues = db.Fetch();

            var field = GetFieldInfo(db, typeof(int[]));

            var actualValues = (int[])field.GetValue(db);
            var dataToCompare = actualValues.Take(data.Length);

            Assert.AreEqual(dataToCompare, fetchedValues);
        }

        private FieldInfo GetFieldInfo(object instance, Type fieldType)
        {
            var fieldInfo = instance.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.FieldType == fieldType);

            return fieldInfo;
        }
    }
}