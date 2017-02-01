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
using System.Drawing;
using System.Threading.Tasks;


namespace Warung
{
    /// <summary>
    /// Interaction logic for autoGenerate.xaml
    /// </summary>
    public partial class autoGenerate : Window
    {
        static int i = 1;
        public autoGenerate()
        {
            InitializeComponent();
            load();
        }
        

        
        double _i = 20;
        
        private void button_Click_1(object sender, RoutedEventArgs e)
        {

            
        }

        private void load()
        {
            int I = 0;
            while (I < 5)
            {
                TextBox tb = new TextBox();
                tb.Text = "";
                tb.Name = "YUO" + I;
                tb.Height = 20;
                tb.Width = 100;
                tb.HorizontalAlignment = new HorizontalAlignment();
                tb.VerticalAlignment = new VerticalAlignment();
                tb.Margin = new Thickness(10, 20+_i, 0, 0);
                _i += 30;
                I++;
                grid1.Children.Add(tb);

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            load();
        }
    }
}
