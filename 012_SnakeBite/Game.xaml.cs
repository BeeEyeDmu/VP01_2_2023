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
using System.Windows.Shapes;

namespace _012_SnakeBite
{
  /// <summary>
  /// Game.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class Game : Window
  {
    Ellipse[] snakes = new Ellipse[30];
    Ellipse egg;
    Random r = new Random();
    int visibleCount = 5; // 뱀 중에서 보이는 Ellipse의 갯수
    int size = 10;        // Ellipse의 크기
    public Game()
    {
      InitializeComponent();
      InitEgg();
    }

    private void InitEgg()
    {
      egg = new Ellipse();
      egg.Width = size;
      egg.Height = size;
      egg.Stroke = Brushes.Black;
      egg.Fill = Brushes.Red;

      // 캔버스 크기 Width="420" Height="320"
      int x = r.Next(0, (int)field.Width / size);
      int y = r.Next(0, (int)field.Height / size);

      Point p = new Point(x*size, y*size);
      egg.Tag = p;

      field.Children.Add(egg);
      Canvas.SetLeft(egg, x * size);
      Canvas.SetTop(egg, y * size);
    }
  }
}
