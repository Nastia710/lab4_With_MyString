
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        testAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
        testAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));

        Console.WriteLine();
        Console.WriteLine(new MyComplex(10, 0).Add(new MyComplex(15, 0)));

        Console.WriteLine();
        testSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));
        testSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));

        Console.WriteLine();
        Console.WriteLine(new MyFrac(10, 20));

        Console.WriteLine();
        Console.WriteLine(new MyFrac(20, 10));

        //DivideByZero
        /*Console.WriteLine();
        testSquaresDifference(new MyFrac(1, -1), new MyFrac(1, 1));*/
        Console.WriteLine();

        MyFrac[] myFracs = { new MyFrac(1, 3), new MyFrac(1, 6), new MyFrac(3, 4), new MyFrac(5, -1) };
        Array.Sort(myFracs);
        StringBuilder sb = new StringBuilder();
        foreach (var item in myFracs)
        {
            sb.Append(item + " ");
        }
        Console.WriteLine(sb);

        //DivideByZero
        Console.WriteLine();
        MyFrac a = new MyFrac(-5, 2);
        MyFrac b = new MyFrac(a);

        Console.WriteLine(b);

        Console.WriteLine();
        Console.WriteLine(new MyFrac(10, 1));

        Console.WriteLine();
        Console.WriteLine(new MyComplex("-1-2i").Add(new MyComplex("2-3i")));

        Console.WriteLine();
        Console.WriteLine(new MyComplex("-1-2i").Subtract(new MyComplex("-1+2i")));

        Console.WriteLine();
        Console.WriteLine(new MyComplex("-1-2i").Multiply(new MyComplex("-1+2i")));

        Console.WriteLine();
        Console.WriteLine(new MyComplex("-1-2i").Divide(new MyComplex("-1+2i")));

        Console.WriteLine();
        Console.WriteLine(new MyString("3 4 5").Add(new MyString("1 2")));

        Console.WriteLine();
        Console.WriteLine(new MyString("1 2 3 4 5 1 6 7 8 1 2 3").Subtract(new MyString("2 3 1")));

        Console.WriteLine();
        Console.WriteLine(new MyString("3 4 5").Multiply(new MyString("1 2")));

        Console.WriteLine();
        Console.WriteLine(new MyString("3 4 5").Divide(new MyString("1 2")));

        Console.WriteLine();
        MyString str = new MyString("3 4 5");
        Console.WriteLine(new MyString(str));
    }

    static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        T aPlusB = a.Add(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a + b) = " + aPlusB);
        Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr);
        T wholeRightPart = curr;
        curr = a.Multiply(b); // ab
        curr = curr.Add(curr); // ab + ab = 2ab
                               // I’m not sure how to create constant factor "2" in more elegant way,
                               // without knowing how IMyNumber is implemented
        Console.WriteLine("2*a*b = " + curr);

        wholeRightPart = wholeRightPart.Add(curr);
        curr = b.Multiply(b);
        Console.WriteLine("b^2 = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
    }

    static void testSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing (a-b)=(a^2-b^2)/(a+b) with a = " + a + ", b = " + b + " ===");
        T aDifferenceB = a.Subtract(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a - b) = " + aDifferenceB);
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr);
        T wholeRightPart = curr;
        curr = b.Multiply(b);
        Console.WriteLine("b^2 = " + curr);
        wholeRightPart = wholeRightPart.Subtract(curr);
        Console.WriteLine("(a^2-b^2) = " + wholeRightPart);
        curr = a.Add(b);
        Console.WriteLine("(a + b) = " + curr);
        wholeRightPart = wholeRightPart.Divide(curr);
        Console.WriteLine("(a^2-b^2)/(a+b) = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing (a-b)=(a^2-b^2)/(a+b) with a = " + a + ", b = " + b + " ===");
    }
}
