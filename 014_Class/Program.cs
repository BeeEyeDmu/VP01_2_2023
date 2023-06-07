using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_Class
{
  public class Rectangle
  {
    private int width;
    private int height;

    // Setter
    public void SetWidth(int w)
    {
      if(w >= 0)
        width = w;
      else
        Console.WriteLine("width와 height는 0보다 크거나 같아야 합니다.");
    }
    public void SetHeight(int h)
    {
      if(h >= 0)
        height = h;
      else
        Console.WriteLine("width와 height는 0보다 크거나 같아야 합니다.");
    }
    // Getter 함수: GetWidth(), GetHeight()
    public int GetWidth()
    {
      return width;
    }
    public int GetHeight()
    {
      return height;
    }

    public int Area()
    {
      return width * height;
    }
  }

  public class Date
  {
    private int year, month, day;

    public void SetYear(int year)
    {
      if(year >= 0)
        this.year = year;
    }
    public void SetMonth(int month)
    {
      if (month > 0 && month <= 12)
        this.month = month;
    }
    public void SetDay(int day)
    {
      if (day > 0 && day <= 31)
        this.day = day;
    }

    // Getter
    public int GetYear()
    {
      return this.year;
    }
    public int GetMonth()
    {
      return month;
    }
    public int GetDay()
    {
      return day;
    }

    // 날짜를 출력하는 메소드
    public void Print()
    {
      Console.WriteLine(year + "/" + month + "/" + day);
    }

    // 생성자: 리턴값이 없고 클래스와 같은 이름을 갖는 함수
    public Date(int y, int m, int d)
    {
      year = y;
      month = m;
      day = d;
    }

    public Date()
    {
      year = 1;
      month = 1;
      day = 1;
    }
  }
  public class Program
  {
    static void Main(string[] args)
    {
      // 생성자를 이용해서 날짜를 초기화
      Date today = new Date(2023, 6, 7);
      Console.Write("today :");
      today.Print();

      Date date = new Date(); // date는 Date 클래스의 객체(instance)

      //date.SetYear = 2023;
      date.SetYear(2023);
      date.SetMonth(6);
      date.SetDay(7);

      // 오늘 날짜를 출력하시오 2023/6/7
      Console.WriteLine("{0}/{1}/{2}", 
        date.GetYear(), date.GetMonth(), date.GetDay());
      date.Print();

      Rectangle a = new Rectangle();
      a.SetWidth(10); 
      a.SetHeight(10);

      // 면적을 계산해봐
      // int area = a.width * a.height;
      //int area = a.GetWidth() * a.GetHeight();
      int area = a.Area();
      Console.WriteLine("a의 면적 = {0}", area);
    }
  }
}
