using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_strudentScore
{
  internal class Program
  {
    static void Main(string[] args)
    {
      // (1)학생의 학번, 이름, 3개 과목의 점수를 저장하는
      // 클래스를 만들어라(속성: getter, setter 자동)
      // (2) s1과 s2 객체를 만들고 생성자로 초기화해라
      // (3) 학번, 이름, 평균점수를 출력하는 메소드를 만들고 
      // s1과 s2 객체를 출력하라

      Student s1 = new Student();      

      s1.Id = 22615011;
      s1.Name = "홍길동";
      s1.Sub1 = 88;
      s1.Sub2 = 78;
      s1.Sub3 = 90;

      Student s2 
        = new Student(22615021, "아이유", 70, 80, 90);

      s1.Print();
      s2.Print();
    }
  }
}
