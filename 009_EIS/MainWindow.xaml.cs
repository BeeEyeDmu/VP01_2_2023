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
using MySql.Data.MySqlClient;

namespace _009_EIS
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    string pos = "";
    string dept = "";
    string gender = "";
    string dateEnter = "";
    string dateExit = "";

    string connStr = "server=localhost; user id=root; password=0000; database=eis_db";
    MySqlConnection conn; // DB 연결을 위해서 선언

    public MainWindow()
    {
      InitializeComponent();

      conn = new MySqlConnection(connStr);
      MessageBox.Show("conn 설정!");
    }
  }
}
