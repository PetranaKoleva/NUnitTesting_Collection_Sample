
using Collections;

namespace Collection.UNitTests
{
    public class CollectionTests
    {

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

    }
}