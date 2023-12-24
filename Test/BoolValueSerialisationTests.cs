using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class BoolValueSerialisationTests {

        private interface MyType { }

        [TestMethod]
        public void BoolValue() {

            BoolValue<MyType> key1 = new BoolValue<MyType>(true);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            BoolValue<MyType> key2 = MessagePackSerializer.Deserialize<BoolValue<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableBoolValue() {

            BoolValue<MyType>? key1 = new BoolValue<MyType>(true);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            BoolValue<MyType>? key2 = MessagePackSerializer.Deserialize<BoolValue<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyBoolValue() {

            BoolValue<MyType> key1 = new BoolValue<MyType>(false);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            BoolValue<MyType> key2 = MessagePackSerializer.Deserialize<BoolValue<MyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullBoolValue() {

            BoolValue<MyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            BoolValue<MyType>? key2 = MessagePackSerializer.Deserialize<BoolValue<MyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}