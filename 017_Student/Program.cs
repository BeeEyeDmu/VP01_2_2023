using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017_Student
{
  public class Student
  {
    private string name;
    private int age;
    private string major;

    public Student(string name, int age, string major)
    {
      this.name = name;
      this.age = age;
      this.major = major;
    }

    public void DisplayInfo()
    {
      Console.WriteLine("이름 : " + name);
      Console.WriteLine("나이 : " + age);
      Console.WriteLine("전공 : " + major);
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
