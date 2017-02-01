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
using Microsoft.Win32;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Text.RegularExpressions;

namespace Warung
{
    /// <summary>
    /// Interaction logic for Isibarangbaru.xaml
    /// </summary>
    public partial class Isibarangbaru : Window
    {
        private OpenFileDialog openFileDialog = null;
        string imagesource;
        string searchFor;
        string replaceWith;

        
        public Isibarangbaru()
        {
            openFileDialog = new OpenFileDialog();
            InitializeComponent();
            openFileDialog.FileOk += openFileDialogFileOk;
        }

        private void Bphoto_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.Filter= "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialog.ShowDialog();
        }

        String s;
        private   void openFileDialogFileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReplaceSubstrings app = new ReplaceSubstrings();

            string fullPathname = openFileDialog.FileName;
            FileInfo src = new FileInfo(fullPathname);
            image1.Source = new BitmapImage(new Uri(src.FullName));
            
           
             s = Convert.ToBase64String(getJPGFromImageControl(image1.Source as BitmapImage));
            imagesource = src.FullName;
            imagesource = imagesource.Replace('\\','/');            
        }

        private void bsimpan_Click(object sender, RoutedEventArgs e)
        {
            koneksi c = new koneksi();
            c.IntCon();

            try
            {
                string QuerySelect = "insert into barang values('" + Tbarcode.Text + "', ('" +  s + "'),'" + tnama.Text + "', '" + tmodal.Text + "','" + tharga.Text + "','" + tstok.Text  + "')";
                SQLiteCommand createCommend = new SQLiteCommand(QuerySelect, c.cn);
                createCommend.ExecuteNonQuery();
                MessageBox.Show("penyimpana sukses");
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Save has been failed");
            }

        }

        private void button_Kembali_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
            
        }
        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }
    }
}
