using NUnit.Framework;

public class Kalkulator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}

[TestFixture]
public class KalkulatorTest
{
    [Test]
    public void DodajTest()
    {
        Kalkulator calculator = new Kalkulator();

        int wynik = calculator.Add(3, 5);

        Assert.AreEqual(8, wynik);
    }
}
