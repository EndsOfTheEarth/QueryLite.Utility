using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class GuidKeySerialisationTests {

        private interface IMyType { }

        [TestMethod]
        public void GuidKey() {

            GuidKey<IMyType> key1 = new(new Guid("{725D9F52-792C-47AA-8C20-284B8AEE702E}"));

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Assert.AreEqual(16, bytes.Length);

            GuidKey<IMyType> key2 = MessagePackSerializer.Deserialize<GuidKey<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableGuidKey() {

            GuidKey<IMyType>? key1 = new(new Guid("{72284F6B-4A9D-490D-B721-7F2DDB43491C}"));

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Assert.AreEqual(16, bytes.Length);

            GuidKey<IMyType>? key2 = MessagePackSerializer.Deserialize<GuidKey<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyGuidKey() {

            GuidKey<IMyType> key1 = new(Guid.Empty);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Assert.AreEqual(16, bytes.Length);

            GuidKey<IMyType> key2 = MessagePackSerializer.Deserialize<GuidKey<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullGuidKey() {

            GuidKey<IMyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Assert.AreEqual(1, bytes.Length);

            GuidKey<IMyType>? key2 = MessagePackSerializer.Deserialize<GuidKey<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}