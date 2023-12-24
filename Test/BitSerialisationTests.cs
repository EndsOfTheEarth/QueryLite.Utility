using MessagePack;

namespace QueryLite.Utility {

    [TestClass]
    public class BitSerialisationTests {

        [TestMethod]
        public void Bit() {

            Bit key1 = new Bit(true);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Bit key2 = MessagePackSerializer.Deserialize<Bit>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullableBit() {

            Bit? key1 = new Bit(true);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Bit? key2 = MessagePackSerializer.Deserialize<Bit?>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void EmptyBit() {

            Bit key1 = new Bit(false);

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Bit key2 = MessagePackSerializer.Deserialize<Bit>(bytes);

            Assert.AreEqual(key1, key2);
        }

        [TestMethod]
        public void NullBit() {

            Bit? key1 = null;

            byte[] bytes = MessagePackSerializer.Serialize(key1);

            Bit? key2 = MessagePackSerializer.Deserialize<Bit?>(bytes);

            Assert.AreEqual(key1, key2);
        }        
    }
}