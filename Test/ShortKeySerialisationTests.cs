using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class ShortKeySerialisationTests {

        private interface MyType { }

        [TestMethod]
        public void ShortKey() {

            ShortKey<MyType> key1 = new ShortKey<MyType>(155);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            ShortKey<MyType> key2 = MessagePackSerializer.Deserialize<ShortKey<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableShortKey() {

            ShortKey<MyType>? key1 = new ShortKey<MyType>(short.MaxValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            ShortKey<MyType>? key2 = MessagePackSerializer.Deserialize<ShortKey<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyShortKey() {

            ShortKey<MyType> key1 = new ShortKey<MyType>(short.MinValue);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            ShortKey<MyType> key2 = MessagePackSerializer.Deserialize<ShortKey<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullShortKey() {

            ShortKey<MyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            ShortKey<MyType>? key2 = MessagePackSerializer.Deserialize<ShortKey<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}