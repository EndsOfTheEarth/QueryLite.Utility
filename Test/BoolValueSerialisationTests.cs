using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class BoolValueSerialisationTests {

        private interface IMyType { }

        [TestMethod]
        public void BoolValue() {

            BoolValue<IMyType> key1 = new(true);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            BoolValue<IMyType> key2 = MessagePackSerializer.Deserialize<BoolValue<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableBoolValue() {

            BoolValue<IMyType>? key1 = new(true);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            BoolValue<IMyType>? key2 = MessagePackSerializer.Deserialize<BoolValue<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyBoolValue() {

            BoolValue<IMyType> key1 = new(false);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            BoolValue<IMyType> key2 = MessagePackSerializer.Deserialize<BoolValue<IMyType>>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullBoolValue() {

            BoolValue<IMyType>? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            BoolValue<IMyType>? key2 = MessagePackSerializer.Deserialize<BoolValue<IMyType>?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}