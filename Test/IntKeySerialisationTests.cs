using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class IntKeySerialisationTests {

        private interface IMyType { }

        [TestMethod]
        public void IntKey() {

            IntKey<IMyType> key1 = new(141234123);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            IntKey<IMyType> key2 = MessagePackSerializer.Deserialize<IntKey<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableIntKey() {

            IntKey<IMyType>? key1 = new(int.MaxValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            IntKey<IMyType>? key2 = MessagePackSerializer.Deserialize<IntKey<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyIntKey() {

            IntKey<IMyType> key1 = new(int.MinValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            IntKey<IMyType> key2 = MessagePackSerializer.Deserialize<IntKey<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullIntKey() {

            IntKey<IMyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            IntKey<IMyType>? key2 = MessagePackSerializer.Deserialize<IntKey<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}