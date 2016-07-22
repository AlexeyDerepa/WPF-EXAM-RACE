using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace DOPOLNENIE_003
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //double[] durations = new double[6];
        //double[] paths = new double[6];
        int secunds = 50;
       // Random rand = new Random();
        List<HorseRun> listHorse = new List<HorseRun>();

        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(secunds);
            timer.Tick += timer_Tick;


            for (int i = 0; i < 6; i++)
                listHorse.Add(new HorseRun());


        }

        void proses(HorseRun obj, ref Rectangle horse_1, ref Rectangle horse_2, ref Border border_1, ref StackPanel stackpanel_1, ref Label label_1, ref Label label_2)
        {
            if (obj.path < 100)
            {
                obj++;
                horse_1.Width = obj.path * grid1.ActualWidth / 100;
            }
            else if (obj.winer == false && HorseRun._flagEnd == false)
            {
                border_1.Style = (Style)this.Resources["styleBorder1"];
                obj.winer = true;
                HorseRun._flagEnd = true;
                horse_1.Width = 0;
                horse_2.Width = 0;
                label_1.Visibility = System.Windows.Visibility.Hidden;
                stackpanel_1.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                label_2.Visibility = System.Windows.Visibility.Visible;

            }
            else if (obj.winer == false && HorseRun._flagEnd == true)
            {
                horse_1.Width = 0;
                horse_2.Width = 0;
                obj.winer = true;
            }
        }

        void initialization(HorseRun obj, ref Rectangle horse_1, ref Rectangle horse_2, ref Border border_1, ref StackPanel stackpanel_1, ref Label label_1, ref Label label_2)
        {

            obj.Initialization();
            horse_1.Style = (Style)this.Resources["RectangleHorseShadow"];
            //horse_2.Style = (Style)this.Resources["RectangleHorse"];
                horse_2.Width = 80;
            border_1.Style = (Style)this.Resources["styleBorder"];
            HorseRun._flagEnd = false;
            label_1.Visibility = System.Windows.Visibility.Visible;
            stackpanel_1.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            label_2.Visibility = System.Windows.Visibility.Hidden;


        }

        void timer_Tick(object sender, EventArgs e)
        {
            proses(listHorse[0], ref horse1, ref horse11, ref border1, ref stackpanel1, ref labelHorse1, ref labelHorse11);
            proses(listHorse[1], ref horse2, ref horse22, ref border2, ref stackpanel2, ref labelHorse2, ref labelHorse22);
            proses(listHorse[2], ref horse3, ref horse33, ref border3, ref stackpanel3, ref labelHorse3, ref labelHorse33);
            proses(listHorse[3], ref horse4, ref horse44, ref border4, ref stackpanel4, ref labelHorse4, ref labelHorse44);
            proses(listHorse[4], ref horse5, ref horse55, ref border5, ref stackpanel5, ref labelHorse5, ref labelHorse55);
            proses(listHorse[5], ref horse6, ref horse66, ref border6, ref stackpanel6, ref labelHorse6, ref labelHorse66);

            if (listHorse[0].winer == true && listHorse[1].winer == true && listHorse[2].winer == true && listHorse[3].winer == true && listHorse[4].winer == true && listHorse[5].winer == true)
            {
                timer.IsEnabled = false;
                MessageBox.Show("Гонка окончена");
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timer.IsEnabled = true;

            //for (int i = 0; i < listHorse.Count; i++)
            //    listHorse[i].Initialization();


            initialization(listHorse[0], ref horse1, ref horse11, ref border1, ref stackpanel1, ref labelHorse1, ref labelHorse11);
            initialization(listHorse[1], ref horse2, ref horse22, ref border2, ref stackpanel2, ref labelHorse2, ref labelHorse22);
            initialization(listHorse[2], ref horse3, ref horse33, ref border3, ref stackpanel3, ref labelHorse3, ref labelHorse33);
            initialization(listHorse[3], ref horse4, ref horse44, ref border4, ref stackpanel4, ref labelHorse4, ref labelHorse44);
            initialization(listHorse[4], ref horse5, ref horse55, ref border5, ref stackpanel5, ref labelHorse5, ref labelHorse55);
            initialization(listHorse[5], ref horse6, ref horse66, ref border6, ref stackpanel6, ref labelHorse6, ref labelHorse66);

            //horse1.Width = 0;
            //horse2.Width = 0;
            //horse3.Width = 0;
            //horse4.Width = 0;
            //horse5.Width = 0;
            //horse6.Width = 0;


        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            stackPanelMain.VerticalAlignment =
                (Math.Abs((int)((Slider)sender).Value) == 90) ?
                System.Windows.VerticalAlignment.Top :
                System.Windows.VerticalAlignment.Center;
            labelAngle.Content = ((int)((Slider)sender).Value).ToString() + " градусов";
        }
    }
}
