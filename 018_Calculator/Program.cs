using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018_Calculator
{
  public class Calculator
  {
    public static int Add(int n1, int n2)
    {
      return n1 + n2;
    }

    public static int Subtract(int n1, int n2)
    {
      return n1 - n2;
    }

    public static int Multiply(int n1, int n2)
    {
      return n1 * n2;
    }
    public static double Divide(int n1, int n2)
    {
      return (double)n1 / n2;
    }
  }
  internal class Program
  {
    static void Main(string[] args)
    {
      int num1 = 5;
      int num2 = 10;

      int sum = Calculator.Add(num1, num2);
      int diff = Calculator.Subtract(num1, num2);
      int product = Calculator.Multiply(num1, num2);
      double quotient = Calculator.Divide(num1, num2);

      Console.WriteLine("덧셈 : " + sum);
      Console.WriteLine("뺄셈 : " + diff);
      Console.WriteLine("곱셈 : " + product);
      Console.WriteLine("나눗셈 : " + quotient);
    }
  }
}
