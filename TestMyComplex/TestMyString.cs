namespace TestMyString
{
    class Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Copy_Constructor()
        {
            MyString a = new MyString("5 7 3");
            MyString b = new MyString(a);

            Assert.AreEqual(a.ToString(), b.ToString());
        }

        [Test]
        public void Test_Add()
        {
            MyString a = new MyString("3 1 2");
            MyString b = new MyString("1 2 3");

            MyString res = a.Add(b);
            Assert.AreEqual(res.ToString(), "1 1 2 2 3 3");
        }

        [Test]
        public void Test_Subtract()
        {
            MyString a = new MyString("3 1 2 10 6 11");
            MyString b = new MyString("1 2 3");

            MyString res = a.Subtract(b);
            Assert.AreEqual(res.ToString(), "10 6 11");
        }

        [Test]
        public void Test_Multiply()
        {
            MyString a = new MyString("3 1 2 10 6 11");
            MyString b = new MyString("2 3");

            MyString res = a.Multiply(b);
            Assert.AreEqual(res.ToString(), "15 5 10 50 30 55");
        }

        [Test]
        public void Test_Divide()
        {
            MyString a = new MyString("5 35 10");
            MyString b = new MyString("10 5");

            MyString res = a.Divide(b);
            Assert.AreEqual(res.ToString(), "1 7 2");
        }
    }
}
