using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_StudentProp
{
  public class Student
  {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }

    public Student(string name, int age, string major)
    {
      Name = name;
      Age = age;
      Major = major;
    }

    public void DisplayInfo()
    {
      Console.WriteLine("이름 : " + Name);
      Console.WriteLine("나이 : " + Age);
      Console.WriteLine("전공 : " + Major);
    }
  }
  internal class Program
  {
    static void Main(string[] args)
    {
      Student s = new Student("홍길동", 20, "의료IT공학");
      s.DisplayInfo();
    }
  }
}
