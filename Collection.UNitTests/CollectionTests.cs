
using Collections;

namespace Collection.UNitTests
{
    public class CollectionTests
    {
        private object collection;
        private object coll;

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            var coll = new Collection<int>();
            Assert.AreEqual(coll.ToString(), "[]");
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var coll = new Collection<int>(5);
            Assert.AreEqual(coll.ToString(), "[5]");
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var coll = new Collection<int>(5, 6);
            Assert.AreEqual(coll.ToString(), "[5, 6]");
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var coll = new Collection<int>(5, 6);
            Assert.AreEqual(coll.Count, 2, "Check for count");
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));
        }

        [Test]
        public void Test_Collection_Add()
        {
            var coll = new Collection<string>("Ivan", "Maria");
            coll.Add("Stefan");
            Assert.AreEqual(coll.ToString(), "[Ivan, Maria, Stefan]");

        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var collection = new Collection<int>(5, 6, 7);
            var item = collection[1];
            Assert.That(item.ToString(), Is.EqualTo("6"));
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var collection = new Collection<int>(5, 6, 7);
            collection[1] = 666;
            Assert.That(collection.ToString(), Is.EqualTo("[5, 666, 7]"));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var names = new Collection<string>("Bob", "Joe");
            Assert.That(() => { var name = names[-1]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[2]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[500]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Bob, Joe]"));
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();
            var nested = new Collection<object>(names, nums, dates);
            string nestedToString = nested.ToString();
            Assert.That(nestedToString,
              Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));
        }

    }

}
