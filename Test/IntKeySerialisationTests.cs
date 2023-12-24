using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class IntKeySerialisationTests {

        private interface MyType { }

        [TestMethod]
        public void IntKey() {

            IntKey<MyType> key1 = new IntKey<MyType>(141234123);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            IntKey<MyType> key2 = MessagePackSerializer.Deserialize<IntKey<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableIntKey() {

            IntKey<MyType>? key1 = new IntKey<MyType>(int.MaxValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            IntKey<MyType>? key2 = MessagePackSerializer.Deserialize<IntKey<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyIntKey() {

            IntKey<MyType> key1 = new IntKey<MyType>(int.MinValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            IntKey<MyType> key2 = MessagePackSerializer.Deserialize<IntKey<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullIntKey() {

            IntKey<MyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            IntKey<MyType>? key2 = MessagePackSerializer.Deserialize<IntKey<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}