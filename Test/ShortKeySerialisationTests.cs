using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class ShortKeySerialisationTests {

        private interface IMyType { }

        [TestMethod]
        public void ShortKey() {

            ShortKey<IMyType> key1 = new(155);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            ShortKey<IMyType> key2 = MessagePackSerializer.Deserialize<ShortKey<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableShortKey() {

            ShortKey<IMyType>? key1 = new(short.MaxValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            ShortKey<IMyType>? key2 = MessagePackSerializer.Deserialize<ShortKey<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyShortKey() {

            ShortKey<IMyType> key1 = new(short.MinValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            ShortKey<IMyType> key2 = MessagePackSerializer.Deserialize<ShortKey<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullShortKey() {

            ShortKey<IMyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            ShortKey<IMyType>? key2 = MessagePackSerializer.Deserialize<ShortKey<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}