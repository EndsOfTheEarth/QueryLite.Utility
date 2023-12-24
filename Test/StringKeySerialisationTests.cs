using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class StringKeySerialisationTests {

        private interface MyType { }

        [TestMethod]
        public void StringKey() {

            StringKey<MyType> key1 = new StringKey<MyType>("{725D9F52-792C-47AA-8C20-284B8AEE702E}");

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            StringKey<MyType> key2 = MessagePackSerializer.Deserialize<StringKey<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableStringKey() {

            StringKey<MyType>? key1 = new StringKey<MyType>("{72284F6B-4A9D-490D-B721-7F2DDB43491C}");

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            StringKey<MyType>? key2 = MessagePackSerializer.Deserialize<StringKey<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyStringKey() {

            StringKey<MyType> key1 = new StringKey<MyType>(string.Empty);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            StringKey<MyType> key2 = MessagePackSerializer.Deserialize<StringKey<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullStringKey() {

            StringKey<MyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            StringKey<MyType>? key2 = MessagePackSerializer.Deserialize<StringKey<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}