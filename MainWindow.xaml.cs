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
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;

namespace Warung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            load();
            
        }

        private void bCari_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                koneksi c = new koneksi();
                c.IntCon();

                string QuerySelect = "Select * from barang where nama_barang like '%" + TCari.Text + "%'";
                SQLiteCommand createCommend = new SQLiteCommand(QuerySelect);
                createCommend.ExecuteNonQuery();

                SQLiteDataAdapter MysqlDtA = new SQLiteDataAdapter(createCommend);
                DataTable dt = new DataTable("barang");
                MysqlDtA.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                MysqlDtA.Update(dt);
                c.IntCon();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BTest_Click(object sender, RoutedEventArgs e)
        {
            koneksi cn = new koneksi();
            cn.IntCon();
          
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void TCari_TextChanged(object sender, TextChangedEventArgs e)
        {
            koneksi c = new koneksi();
            c.IntCon();

            string QuerySelect = "Select * from barang where barcode like '%" + TCari.Text + "%'";
            SQLiteCommand createCommend = new SQLiteCommand(QuerySelect, c.cn);
            createCommend.ExecuteNonQuery();

            SQLiteDataAdapter MysqlDtA = new SQLiteDataAdapter(createCommend);
            DataTable dt = new DataTable("barang");
            MysqlDtA.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            MysqlDtA.Update(dt);
            

        }
        
        public void load()
        {
            koneksi c = new koneksi();
            c.IntCon();

            string QuerySelect = " Select * from barang ";
            SQLiteCommand createCommend = new SQLiteCommand(QuerySelect, c.cn);
            createCommend.ExecuteNonQuery();

            SQLiteDataAdapter MysqlDtA = new SQLiteDataAdapter(createCommend);
            DataTable dt = new DataTable("barang");
            MysqlDtA.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            MysqlDtA.Update(dt);
           
        }

        private void btisidat_Click(object sender, RoutedEventArgs e)
        {
            Isibarangbaru baru = new Isibarangbaru();
            baru.Show();
            this.Close();
        }

        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            koneksi c = new koneksi();
            c.IntCon();

            string QuerySelect = "Select * from barang where barcode= '" + TCari.Text + "'";
            SQLiteCommand createCommend = new SQLiteCommand(QuerySelect, c.cn);
            createCommend.ExecuteNonQuery();

            
            SQLiteDataReader re;
            re = createCommend.ExecuteReader();

            while (re.Read())
            {
                string base64 = re.GetString (1);
                image.Source = ByteToImage(Convert.FromBase64String(base64));

            }
            


        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
