namespace QueryLite.Utility {

    [TestClass]
    public class KeyTests {

        private interface IMyType { }

        [TestMethod]
        public void TestTwoParameterKey1() {

            Key<int, string> key1 = new(1, "abc");
            Key<int, string> key2 = new(1, "abc");

            Assert.AreEqual(key1, key2);

            Assert.IsTrue(key1.Equals(key2));

            Assert.IsTrue(key1 == key2);
            Assert.IsFalse(key1 != key2);
        }

        [TestMethod]
        public void TestTwoParameterKey2() {

            Key<int, string> key1 = new(1, "abc");
            Key<int, string> key2 = new(2, "abc");

            Assert.AreNotEqual(key1, key2);

            Assert.IsFalse(key1.Equals(key2));

            Assert.IsFalse(key1 == key2);
            Assert.IsTrue(key1 != key2);
        }

        [TestMethod]
        public void TestThreeParameterKey1() {

            Key<int, string, float> key1 = new(1, "abc", 2.0f);
            Key<int, string, float> key2 = new(1, "abc", 2.0f);

            Assert.AreEqual(key1, key2);

            Assert.IsTrue(key1.Equals(key2));

            Assert.IsTrue(key1 == key2);
            Assert.IsFalse(key1 != key2);
        }

        [TestMethod]
        public void TestThreeParameterKey2() {

            Key<int, string, float> key1 = new(1, "abc", 2.1f);
            Key<int, string, float> key2 = new(1, "abc", 2.2f);

            Assert.AreNotEqual(key1, key2);

            Assert.IsFalse(key1.Equals(key2));

            Assert.IsFalse(key1 == key2);
            Assert.IsTrue(key1 != key2);
        }

        [TestMethod]
        public void TestFourParameterKey1() {

            Key<int, string, float, decimal> key1 = new(1, "abc", 2.0f, 10.5m);
            Key<int, string, float, decimal> key2 = new(1, "abc", 2.0f, 10.5m);

            Assert.AreEqual(key1, key2);

            Assert.IsTrue(key1.Equals(key2));

            Assert.IsTrue(key1 == key2);
            Assert.IsFalse(key1 != key2);
        }

        [TestMethod]
        public void TestFourParameterKey2() {

            Key<int, string, float, decimal> key1 = new(1, "abc", 2.1f, 10.5m);
            Key<int, string, float, decimal> key2 = new(1, "abc", 2.1f, 10.6m);

            Assert.AreNotEqual(key1, key2);

            Assert.IsFalse(key1.Equals(key2));

            Assert.IsFalse(key1 == key2);
            Assert.IsTrue(key1 != key2);
        }

        [TestMethod]
        public void TestFiveParameterKey1() {

            Key<int, string, float, decimal, char> key1 = new(1, "abc", 2.0f, 10.5m, 'a');
            Key<int, string, float, decimal, char> key2 = new(1, "abc", 2.0f, 10.5m, 'a');

            Assert.AreEqual(key1, key2);

            Assert.IsTrue(key1.Equals(key2));

            Assert.IsTrue(key1 == key2);
            Assert.IsFalse(key1 != key2);
        }

        [TestMethod]
        public void TestFiveParameterKey2() {

            Key<int, string, float, decimal, char> key1 = new(1, "abc", 2.0f, 10.5m, 'a');
            Key<int, string, float, decimal, char> key2 = new(1, "abc", 2.0f, 10.5m, 'b');

            Assert.AreNotEqual(key1, key2);

            Assert.IsFalse(key1.Equals(key2));

            Assert.IsFalse(key1 == key2);
            Assert.IsTrue(key1 != key2);
        }
    }
}