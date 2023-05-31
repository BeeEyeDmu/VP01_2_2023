using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _012_SnakeBite
{
  /// <summary>
  /// Game.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class Game : Window
  {
    private Ellipse[] snakes = new Ellipse[30];
    private Ellipse egg;
    private Random r = new Random();
    private int visibleCount = 5; // 뱀 중에서 보이는 Ellipse의 갯수
    private int size = 15;        // Ellipse의 크기

    private DispatcherTimer timer = new DispatcherTimer();
    private Stopwatch sw = new Stopwatch();
    private string move = "";
    private int eaten = 0;

    private SoundPlayer myPlayer;
    private MediaPlayer bgm;

    public Game() // 생성자
    {
      InitializeComponent();
      InitEgg();
      InitSnakes();
      InitSound();

      timer.Interval = new TimeSpan(0, 0, 0, 0, 100); // 0.1초
      timer.Tick += Timer_Tick;
    }

    private void InitSound()
    {
      myPlayer = new SoundPlayer();
      myPlayer.SoundLocation = "../../Sounds/Windows Notify.wav";

      bgm = new MediaPlayer();
      bgm.Open(new Uri("../../Sounds/stranger.mp3", UriKind.Relative));
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (move != "")
      {
        // 뱀이 몸통 좌표
        for (int i = visibleCount; i > 0; i--)
          snakes[i].Tag = (Point)snakes[i - 1].Tag;

        // 머리의 좌표
        Point q = (Point)snakes[0].Tag;

        if (move == "U")
          snakes[0].Tag = new Point(q.X, q.Y - size);
        else if (move == "D")
          snakes[0].Tag = new Point(q.X, q.Y + size);
        else if (move == "L")
          snakes[0].Tag = new Point(q.X - size, q.Y);
        else if (move == "R")
          snakes[0].Tag = new Point(q.X + size, q.Y);

        EatEgg();
        DrawSnakes();
      }
      
      TimeSpan ts = sw.Elapsed;
      //txtTimer.Text = ts.ToString();
      txtTimer.Text = String.Format("Time = {0:00}:{1:00}.{2:00}",
        ts.Minutes, ts.Seconds, ts.Milliseconds);
    }

    // 알을 먹었는지 체크(뱀의 머리와 egg의 좌표가 같은가)
    private void EatEgg()
    {
      Point pS = (Point)snakes[0].Tag;
      Point pE = (Point)egg.Tag;

      if(pS.X == pE.X && pS.Y == pE.Y)
      {
        myPlayer.Play();
        egg.Visibility = Visibility.Hidden;
        visibleCount++;
        snakes[visibleCount-1].Visibility = Visibility.Visible; // 꼬리 하나 늘려줌
        txtScore.Text = "Eggs = " + ++eaten;

        if(visibleCount == 30)
        {
          bgm.Stop();
          timer.Stop();
          sw.Stop();
          DrawSnakes();
          TimeSpan ts = sw.Elapsed;          
          string s = String.Format("Time = {0:00}:{1:00}.{2:00}",
            ts.Minutes, ts.Seconds, ts.Milliseconds);
          MessageBox.Show("Success!!! " + s + "sec");
          this.Close();
        }
        int x = r.Next(1, (int)field.Width / size - 1);
        int y = r.Next(1, (int)field.Height / size - 1);

        Point p = new Point(x * size, y * size);
        egg.Tag = p;
        egg.Visibility = Visibility.Visible;
        Canvas.SetLeft(egg, p.X);
        Canvas.SetTop(egg, p.Y);
      }
    }

    private void DrawSnakes()
    {
      for (int i = 0; i < visibleCount; i++)
      {
        Point p = (Point)snakes[i].Tag;
        Canvas.SetLeft(snakes[i], p.X);
        Canvas.SetTop(snakes[i], p.Y);
      }
    }

    private void InitSnakes()
    {
      int x = r.Next(1, (int)field.Width / size - 1);
      int y = r.Next(1, (int)field.Height / size - 5); // 뱀이 다 보이게

      for (int i = 0; i < 30; i++)
      {
        snakes[i] = new Ellipse();
        snakes[i].Width = size;
        snakes[i].Height = size;
        if (i % 5 == 0)
          snakes[i].Fill = Brushes.Green;
        else
          snakes[i].Fill = Brushes.Gold;

        snakes[i].Stroke = Brushes.Black;
        field.Children.Add(snakes[i]);

        snakes[i].Tag = new Point(x * size, (y + i) * size);
        Canvas.SetLeft(snakes[i], x * size);
        Canvas.SetTop(snakes[i], (y + i) * size);
      }
      // 머리
      snakes[0].Fill = Brushes.Chocolate;
      for (int i = visibleCount; i < 30; i++)
        snakes[i].Visibility = Visibility.Hidden;
    }

    private void InitEgg()
    {
      egg = new Ellipse();
      egg.Width = size;
      egg.Height = size;
      egg.Stroke = Brushes.Black;
      egg.Fill = Brushes.Red;

      // 캔버스 크기 Width="420" Height="320"
      int x = r.Next(1, (int)field.Width / size - 1);
      int y = r.Next(1, (int)field.Height / size - 1);

      Point p = new Point(x * size, y * size);
      egg.Tag = p;

      field.Children.Add(egg);
      Canvas.SetLeft(egg, x * size);
      Canvas.SetTop(egg, y * size);
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
      timer.Start();
      sw.Start();
      bgm.Play();

      if (e.Key == Key.Left)
        move = "L";
      else if (e.Key == Key.Right)
        move = "R";
      else if (e.Key == Key.Up)
        move = "U";
      else if (e.Key == Key.Down)
        move = "D";
      else if (e.Key == Key.Escape)
      {
        bgm.Pause();
        move = "";
      }
    }
  }
}
