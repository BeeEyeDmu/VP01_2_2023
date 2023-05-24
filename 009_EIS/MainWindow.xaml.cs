using System;
using System.Collections.Generic;
using System.Data;
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
    private string pos = "";
    private string dept = "";
    private string gender = "";
    private string dateEnter = "";
    private string dateExit = "";

    private string connStr = "server=localhost; user id=root; password=0000; database=eis_db";
    private MySqlConnection conn; // DB 연결을 위해서 선언

    public MainWindow()
    {
      InitializeComponent();

      conn = new MySqlConnection(connStr);
      DisplayDataGrid();

      //MessageBox.Show("conn 설정!");
    }

    private void btnInsert_Click(object sender, RoutedEventArgs e)
    {
      if (rbMale.IsChecked == true)
        gender = "남성";
      else if (rbFemale.IsChecked == true)
        gender = "여성";

      if(dpEnter.SelectedDate != null)
        dateEnter = dpEnter.SelectedDate.Value.Date.ToShortDateString();
      if (dpExit.SelectedDate != null)
        dateExit = dpExit.SelectedDate.Value.Date.ToShortDateString();
      else
        dateExit = DateTime.MaxValue.ToShortDateString();

      dept = cbDept.Text;
      pos = cbPos.Text;

      //MessageBox.Show(dept + " " + pos + " " + gender + " " + dateEnter + " " + dateExit);
      conn.Open();

      string sql = string.Format(
        "INSERT INTO eis_table (name, department, position, " +
        "gender, date_enter, date_exit, contact, comment)" +
        " VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
        txtName.Text, dept, pos, gender, 
        dateEnter, dateExit, txtContact.Text, txtComment.Text);

      MySqlCommand cmd = new MySqlCommand(sql, conn);
      if(cmd.ExecuteNonQuery() == 1)
        MessageBox.Show("Inserted Successfully!");

      conn.Close();
      InitControls();
      DisplayDataGrid();
    }

    private void InitControls()
    {
      txtEid.Text = "";
      txtName.Text = "";
      txtComment.Text = "";
      txtContact.Text = "";
      cbDept.SelectedIndex = -1;
      cbPos.SelectedIndex = -1;
      rbMale.IsChecked = false;
      rbFemale.IsChecked = false;
      dpEnter.Text = "";
      dpExit.Text = "";
    }

    private void btnLoadData_Click(object sender, RoutedEventArgs e)
    {
      DisplayDataGrid();
    }

    private void DisplayDataGrid()
    {
      conn.Open();

      string sql = "SELECT * FROM eis_table";

      MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
      DataSet ds = new DataSet();
      da.Fill(ds);
      dataGrid.ItemsSource = ds.Tables[0].DefaultView;

      conn.Close();
    }

    private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //DataGrid dg = (DataGrid)sender;
      DataGrid dg = sender as DataGrid;  
      DataRowView rowView = dg.SelectedItem as DataRowView;

      if (rowView == null)
        return;

      txtEid.Text = rowView.Row[0].ToString();
      txtName.Text = rowView.Row[1].ToString();
      cbDept.Text = rowView.Row[2].ToString();
      cbPos.Text = rowView.Row[3].ToString();

      if(rowView.Row[4].ToString() == "남성")
      {
        rbMale.IsChecked = true;
        rbFemale.IsChecked = false;
      }
      else
      {
        rbMale.IsChecked = false;
        rbFemale.IsChecked = true;
      }

      dpEnter.Text = rowView.Row[5].ToString();
      dpExit.Text = rowView.Row[6].ToString();
      txtContact.Text = rowView.Row[7].ToString();
      txtComment.Text = rowView.Row[8].ToString();
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
      conn.Open();

      dept = cbDept.Text;
      pos = cbPos.Text;
      if (rbMale.IsChecked == true)
        gender = "남성";
      else
        gender = "여성";

      try
      {
        string sql = string.Format(
          "UPDATE eis_table SET name='{0}', department='{1}',"
          + "position='{2}', gender='{3}', date_enter='{4}', "
          + "date_exit='{5}', contact='{6}', comment='{7}'"
          + "WHERE eid={8}",
          txtName.Text, dept, pos, gender, dpEnter.Text, dpExit.Text,
          txtContact.Text, txtComment.Text, txtEid.Text);

        MySqlCommand cmd = new MySqlCommand(sql, conn);
        if (cmd.ExecuteNonQuery() == 1)
          MessageBox.Show("Updated Successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

      conn.Close();
      InitControls();
      DisplayDataGrid();
    }
  }
}
