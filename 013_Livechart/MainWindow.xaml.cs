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
using LiveCharts;
using LiveCharts.Wpf;

namespace _013_Livechart
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    // 클래스의 속성(property)을 만들 때, prop<Tab><Tab>
    public SeriesCollection seriesCollection { get; set; }
    public string[] xMarks { get; set; }
    public Func<double, string> Values { get; set; }

    public MainWindow()
    {
      InitializeComponent();

      seriesCollection = new SeriesCollection
      {
        new LineSeries
        {
          Title = "2020",
          Values = new ChartValues<double> {3, 4, 5, 6, 7 }
        },
        new LineSeries
        {
          Title = "2021",
          Values = new ChartValues<double> {7, 5, 8, 9, 4 }
        },
        new LineSeries
        {
          Title = "2022",
          Values = new ChartValues<double> {5, 9, 7, 5, 10 }
        }
      };
      LineSeries s = new LineSeries();
      s.Title = "2023";
      s.Values = new ChartValues<double> { 7,9,2,8,4 };
      seriesCollection.Add(s);

      xMarks = new string[] { "Kang", "Cho", "Kim", "Lee", "Park" };
      Values = value => value.ToString("N"); // Lambda 식
      DataContext = this;
    }
  }
}
