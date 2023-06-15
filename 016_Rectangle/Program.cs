using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016_Rectangle
{
  public class Rectangle
  {
    private double width; // 필드
    private double height;

    // Getter, Setter는 필요없겠다

    // 생성자
    public Rectangle(double w, double h)
    {
      width = w;
      height = h;
    }

    public double GetArea()
    {
      return width * height;
    }

    public double GetPerimeter()
    {
      return 2*(width+height);
    }

  }
  internal class Program
  {
    static void Main(string[] args)
    {
      Rectangle rect = new Rectangle(5, 3);
      double area = rect.GetArea();
      double perimeter = rect.GetPerimeter();

      Console.WriteLine("넓이 : " + area);
      Console.WriteLine("둘레 : " + perimeter);
    }
  }
}
