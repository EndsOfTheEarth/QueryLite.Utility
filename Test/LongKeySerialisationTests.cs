using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class LongKeySerialisationTests {

        private interface MyType { }

        [TestMethod]
        public void LongKey() {

            LongKey<MyType> key1 = new LongKey<MyType>(987123412342344234L);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            LongKey<MyType> key2 = MessagePackSerializer.Deserialize<LongKey<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableLongKey() {

            LongKey<MyType>? key1 = new LongKey<MyType>(long.MaxValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            LongKey<MyType>? key2 = MessagePackSerializer.Deserialize<LongKey<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyLongKey() {

            LongKey<MyType> key1 = new LongKey<MyType>(long.MinValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            LongKey<MyType> key2 = MessagePackSerializer.Deserialize<LongKey<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullLongKey() {

            LongKey<MyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            LongKey<MyType>? key2 = MessagePackSerializer.Deserialize<LongKey<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}