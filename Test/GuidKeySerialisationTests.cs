using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class GuidKeySerialisationTests {

        private interface MyType { }

        [TestMethod]
        public void GuidKey() {

            GuidKey<MyType> key1 = new GuidKey<MyType>(new Guid("{725D9F52-792C-47AA-8C20-284B8AEE702E}"));

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Assert.AreEqual(16, bytes.Length);

            GuidKey<MyType> key2 = MessagePackSerializer.Deserialize<GuidKey<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableGuidKey() {

            GuidKey<MyType>? key1 = new GuidKey<MyType>(new Guid("{72284F6B-4A9D-490D-B721-7F2DDB43491C}"));

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Assert.AreEqual(16, bytes.Length);

            GuidKey<MyType>? key2 = MessagePackSerializer.Deserialize<GuidKey<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyGuidKey() {

            GuidKey<MyType> key1 = new GuidKey<MyType>(Guid.Empty);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Assert.AreEqual(16, bytes.Length);

            GuidKey<MyType> key2 = MessagePackSerializer.Deserialize<GuidKey<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullGuidKey() {

            GuidKey<MyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Assert.AreEqual(1, bytes.Length);

            GuidKey<MyType>? key2 = MessagePackSerializer.Deserialize<GuidKey<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}