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

namespace _006_UserControl
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnColor_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnRed_Click(object sender, RoutedEventArgs e)
    {
      btnColor.Background = Brushes.Red;
    }

    private void btnGreen_Click(object sender, RoutedEventArgs e)
    {
      btnColor.Background = Brushes.Green;
    }

    private void btnBlue_Click(object sender, RoutedEventArgs e)
    {
      btnColor.Background = Brushes.Blue;
    }
  }
}
