using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_strudentScore
{
  public class Student
  {
    // (1)학생의 학번, 이름, 3개 과목의 점수를 저장하는
    // 클래스를 만들어라
    //private int id;
    //private string name;
    //private int sub1;
    //private int sub2;
    //private int sub3;

    // 속성은 대문자로
    // public int Id { get; set; }
    public string Name { get; set; }
    public int Sub1 { get; set; }
    public int Sub2 { get; set; }
    public int Sub3 { get; set; }

    // Id는 음수일 수 없다는 조건
    private int id;

    public int Id
    {
      get { return id; }
      set { if(id > 0) id = value; }
    }

    // 생성자
    public Student(int id, string name, int sub1, 
      int sub2, int sub3)
    {
      this.id = id;
      this.Name = name;
      this.Sub1 = sub1;
      this.Sub2 = sub2;
      this.Sub3 = sub3;
    }

    public Student()
    {

    }

    public void Print()
    {
      Console.WriteLine("{0} {1} {2:F2}",
        Id, Name, (Sub1 + Sub2 + Sub3) / 3.0);
    }
  }
}
