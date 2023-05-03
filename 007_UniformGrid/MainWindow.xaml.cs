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

namespace _007_UniformGrid
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      chessBoard.Rows = 8;
      chessBoard.Columns = 8;

      for (int i = 0; i < 64; i++)
      {
        Rectangle r = new Rectangle();
        if ((i / 8) % 2 == 0)  // 짝수 row라면
        {
          if (i % 2 == 0)
            r.Fill = Brushes.Black;
          else
            r.Fill = Brushes.Red;
        }
        else
        {
          if (i % 2 == 0)
            r.Fill = Brushes.Red;
          else
            r.Fill = Brushes.Black;
        }
        chessBoard.Children.Add(r);
      }
    }
  }
}
