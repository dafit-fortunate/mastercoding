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

namespace Warung
{
    /// <summary>
    /// Interaction logic for pengolahan.xaml
    /// </summary>
    public partial class pengolahan : Window
    {
        public pengolahan()
        {
            InitializeComponent();
        }



        private int NilaiTambah(int angkaPertama, int angkaKedua)
        {
            Ekspresi.Text = angkaPertama.ToString() + " + " + angkaKedua.ToString();
            return angkaKedua + angkaPertama;
        }

        private int NilaiKurang(int angkaPertama, int angkaKedua)
        {
            Ekspresi.Text = angkaPertama.ToString() + " - " + angkaKedua.ToString();
            return angkaPertama - angkaKedua;
        }

        private int NilaiKali(int angkaPertama, int angkaKedua)
        {
            Ekspresi.Text = angkaPertama.ToString() + " * " + angkaKedua.ToString();
            return angkaPertama * angkaKedua;

        }
        private int NilaiBagi (int angkaPertama, int angkaKedua)
        {
            Ekspresi.Text = angkaPertama.ToString() + " / " + angkaKedua.ToString();
            return angkaPertama / angkaKedua;
        }
         private void NilaiHasil(int jawaban)
        {
            Hasil.Text = jawaban.ToString();
        }

        private void Hitung_Click(object sender, RoutedEventArgs e)
        {
            int HitungNilai = 0;

            try
            {
                int angkaPertama = System.Int32.Parse(Angka1.Text);
                int angkaKedua = System.Int32.Parse(Angka2.Text);

                if (Tambah.IsChecked.HasValue && Tambah.IsChecked.Value)
                {
                    HitungNilai = NilaiTambah(angkaPertama, angkaKedua);
                    NilaiHasil(HitungNilai);
                }
                else if (Kurang.IsChecked.HasValue && Kurang.IsChecked.Value)
                {
                    HitungNilai = NilaiKurang(angkaPertama, angkaKedua);
                    NilaiHasil(HitungNilai);
                }
                else if (Kali.IsChecked.HasValue && Kali.IsChecked.Value)
                {
                    HitungNilai = NilaiKali(angkaPertama, angkaKedua);
                    NilaiHasil(HitungNilai);
                }
                else if (Bagi.IsChecked.HasValue && Bagi.IsChecked.Value)
                {
                    HitungNilai = NilaiBagi(angkaPertama, angkaKedua);
                    NilaiHasil(HitungNilai);
                }
            
            }

            catch (Exception caught)
            {
                Ekspresi.Text = "";
                Hasil.Text = "";
            }
            
        }

        private void Kluar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
             
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
