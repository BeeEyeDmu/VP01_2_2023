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
using System.Windows.Threading; // DispatcherTimer

namespace _008_MatchingGame
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    private Random r = new Random();
    private string[] icon = { "딸기", "레몬", "모과", "배", "사과", "수박", "파인애플", "포도" };
    private int[] rnd = new int[16];  // 0으로 초기화된다
    private Button first = null;
    private Button second = null;

    // 타이머 사용시 주의점
    // WinForm: Timer t = new Timer()
    // WPF: DispatcherTimer t = new DispatcherTimer()
    private DispatcherTimer myTimer = new DispatcherTimer();
    private int matched = 0;    // 맞춘 카드의 숫자

    public MainWindow()
    {
      InitializeComponent();
      BoardSet();

      // 타이머 처리
      myTimer.Interval = new TimeSpan(0,0,0,0,750); // 0.75초
      myTimer.Tick += MyTimer_Tick;
    }

    private void MyTimer_Tick(object sender, EventArgs e)
    {
      myTimer.Stop();
      first.Content = MakeImage("../../Images/check.png");
      second.Content = MakeImage("../../Images/check.png");
      first = null;
      second = null;
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

      if (first == null) // 지금 눌린 버튼이 첫번째 버튼
      {
        first = btn;
        btn.Content = MakeImage(fruit + ".png");
        return;
      }
      else if (second == null)
      {
        second = btn;
        btn.Content = MakeImage(fruit + ".png");
      }
      else
        return;

      // first와 second가 매칭되는지를 체크(Tag로 체크)
      if((int)first.Tag == (int)second.Tag)
      {
        first = null;
        second = null;
        matched += 2;
        if(matched >= 16) // 모두 다 맞추었으면
        {
          MessageBoxResult result = MessageBox.Show("성공! 다시 할까요?", 
            "Success!", MessageBoxButton.YesNo);
          if (result == MessageBoxResult.Yes) // 처음부터 다시 시작
          {
            // 1. rnd[] 초기화
            ResetRnd();
            // 2. board 초기화(board 안에 있는 Children을 삭제)
            board.Children.Clear();
            // 3. BoardSet()
            BoardSet();
            // 4. matched = 0 초기화
            matched = 0;
          }
          else
            this.Close();
        }
      }
      else
      {
        myTimer.Start();
      }

    }

    // rnd[] 배열을 초기화한다
    private void ResetRnd()
    {
      for(int i=0; i < 16; i++)
        rnd[i] = 0;
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
