using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _008_MatchingGame
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    Random r = new Random();
    string[] icon = { "딸기", "레몬", "모과", "배", "사과", "수박", "파인애플", "포도" };
    int[] rnd = new int[16];  // 0으로 초기화된다

    public MainWindow()
    {
      InitializeComponent();
      BoardSet();
    }

    private void BoardSet()
    {
      for(int i=0; i<16; i++)
      {
        Button btn = new Button();
        btn.Background = Brushes.White;
        btn.Margin = new Thickness(10);
        
        btn.Tag = TagSet();
        // btn.Content = (int)(btn.Tag);  // Tag 테스트용
        btn.Content = MakeImage("../../Images/check.png");
        btn.Click += Btn_Click;
        board.Children.Add(btn);
      }
    }

    private void Btn_Click(object sender, RoutedEventArgs e)
    {
      Button btn = sender as Button;

      string fruit = "../../Images/" + icon[(int)btn.Tag];
      btn.Content = MakeImage(fruit + ".png");
    }

    // v로 넘어온 이미지 파일을 img 객체로 만들어서 리턴하는 메소드
    private Image MakeImage(string v)
    {
      BitmapImage bi = new BitmapImage();
      bi.BeginInit();
      bi.UriSource = new Uri(v, UriKind.Relative);
      bi.EndInit();

      Image img = new Image();
      img.Margin = new Thickness(10); 
      img.Stretch = Stretch.Fill;
      img.Source = bi;

      return img;
    }

    // 0~15까지의 숫자를 한번씩만 만들어 리턴한다.
    private int TagSet()
    {
      int i;

      while(true)
      {
        i = r.Next(16);
        if(rnd[i] == 0) // 처음 이 숫자가 나왔다면
        {
          rnd[i] = 1;
          break;
        }
      }
      return i%8; // 0~7까지의 숫자 = 과일을 구분
    }
  }
}
