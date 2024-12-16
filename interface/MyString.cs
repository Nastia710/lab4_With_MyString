using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class MyString: IMyNumber<MyString>
{
    string str;

    public MyString(string str)
    {
        this.str = str;
    }
    public MyString(MyString myString)
    {
        this.str = myString.str;
    }

    public MyString Add(MyString that)
    {
        string line = Sort(this.str + " " + that.str);
        return new MyString(line);
    }

    public MyString Subtract(MyString that)
    {
        string[] firstLine = this.str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] secondLine = that.str.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var resultNumbers = new List<string>();
        foreach (var firstNum in firstLine)
        {
            bool found = false;
            foreach (var secNum in secondLine)
            {
                if (firstNum == secNum)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                resultNumbers.Add(firstNum);
            }
        }

        string result = string.Join(" ", resultNumbers);

        return new MyString(result);
    }

    public MyString Multiply(MyString that)
    {
        string[] firstLine = this.str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] secondLine = that.str.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var resultNumbers = new List<string>();

        double sumNumFromSecLine = 0;
        double[] numbersFromSecLine = new double[secondLine.Length];

        for (int i = 0; i < secondLine.Length; i++)
        {
            numbersFromSecLine[i] = int.Parse(secondLine[i]);
        }

        foreach (var num in numbersFromSecLine)
        {
            sumNumFromSecLine += num;
        }

        double[] numbersFromFirstLine = new double[firstLine.Length];

        for (int i = 0; i < firstLine.Length; i++)
        {
            numbersFromFirstLine[i] = (int.Parse(firstLine[i]) * sumNumFromSecLine);
            resultNumbers.Add(numbersFromFirstLine[i].ToString());
        }

        string result = string.Join(" ", resultNumbers);

        return new MyString(result);
    }

    public MyString Divide(MyString that)
    {
        string[] firstLine = this.str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] secondLine = that.str.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var resultNumbers = new List<string>();

        double[] numbersFromSecLine = new double[secondLine.Length];

        for (int i = 0; i < secondLine.Length; i++)
        {
            numbersFromSecLine[i] = int.Parse(secondLine[i]);
        }
        
        double subtractNumFromSecLine = numbersFromSecLine[0];

        for (int i = 1; i < numbersFromSecLine.Length; i++)
        {
            subtractNumFromSecLine -= numbersFromSecLine[i];
        }

        if (subtractNumFromSecLine == 0)
        {
            throw new DivideByZeroException();
        }

        double[] numbersFromFirstLine = new double[firstLine.Length];

        for (int i = 0; i < firstLine.Length; i++)
        {
            numbersFromFirstLine[i] = (int.Parse(firstLine[i]) / subtractNumFromSecLine);
            resultNumbers.Add(numbersFromFirstLine[i].ToString());
        }

        string result = string.Join(" ", resultNumbers);

        return new MyString(result);
    }

    public string Sort(string line)
    {
        string[] numbersStr = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double[] numbers = new double[numbersStr.Length];

        for (int i = 0; i < numbersStr.Length; i++)
        {
            numbers[i] = double.Parse(numbersStr[i]);
        }

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    double temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }

        string result = string.Join(" ", numbers);
        return result;
    }

    override public String ToString()
    {
        return $"{str}";
    }
}

