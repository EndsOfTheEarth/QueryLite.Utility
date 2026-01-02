using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class LongKeySerialisationTests {

        private interface IMyType { }

        [TestMethod]
        public void LongKey() {

            LongKey<IMyType> key1 = new(987123412342344234L);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            LongKey<IMyType> key2 = MessagePackSerializer.Deserialize<LongKey<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableLongKey() {

            LongKey<IMyType>? key1 = new(long.MaxValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            LongKey<IMyType>? key2 = MessagePackSerializer.Deserialize<LongKey<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyLongKey() {

            LongKey<IMyType> key1 = new(long.MinValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            LongKey<IMyType> key2 = MessagePackSerializer.Deserialize<LongKey<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullLongKey() {

            LongKey<IMyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            LongKey<IMyType>? key2 = MessagePackSerializer.Deserialize<LongKey<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}