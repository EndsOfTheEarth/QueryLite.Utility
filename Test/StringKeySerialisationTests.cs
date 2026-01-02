using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class StringKeySerialisationTests {

        private interface IMyType { }

        [TestMethod]
        public void StringKey() {

            StringKey<IMyType> key1 = new("{725D9F52-792C-47AA-8C20-284B8AEE702E}");

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            StringKey<IMyType> key2 = MessagePackSerializer.Deserialize<StringKey<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableStringKey() {

            StringKey<IMyType>? key1 = new("{72284F6B-4A9D-490D-B721-7F2DDB43491C}");

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            StringKey<IMyType>? key2 = MessagePackSerializer.Deserialize<StringKey<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyStringKey() {

            StringKey<IMyType> key1 = new(string.Empty);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            StringKey<IMyType> key2 = MessagePackSerializer.Deserialize<StringKey<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullStringKey() {

            StringKey<IMyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            StringKey<IMyType>? key2 = MessagePackSerializer.Deserialize<StringKey<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}