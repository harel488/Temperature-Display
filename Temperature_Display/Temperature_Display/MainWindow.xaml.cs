using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
using System.Threading;

namespace Temperature_Display
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timerDisp = new DispatcherTimer();
        DispatcherTimer tempDisp = new DispatcherTimer();
        int min = 0, sec = 0, milisec = 0;
        const string TEMP_FILE_PATH = @"C:\Users\harel isaschar\source\repos\Temperature_Display\Temperature_Display\files\tempFile.txt";

        ExTempSensor sens;

        public MainWindow()
        {
            InitializeComponent();
            sens = new ExTempSensor();
            timerDisp.Interval = TimeSpan.FromMilliseconds(1); // dispatcher for timer label

            tempDisp.Interval = TimeSpan.FromSeconds(30);     //  dispatcher for printing the temperature to screen
                                                              //   and write the current value of the sensor to text file
            timerDisp.Tick += OnTime;
            tempDisp.Tick += TempDisplay;
            timerDisp.Start();
            tempDisp.Start();
            tempLabel.Content = File.ReadAllText(TEMP_FILE_PATH) + " °C";

        }


        /// <summary>
        /// replacing the content of tempLabel every 30 sec, and store it in text file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TempDisplay(object sender, EventArgs e)
        {
            sens.MakeRandomVal();
            File.WriteAllText(TEMP_FILE_PATH, String.Format("{0:0.00}", sens.ConvertToCelcius()));
            string temp = File.ReadAllText(TEMP_FILE_PATH) + " °C";
            tempLabel.Content = temp;
        }






        /// <summary>
        /// Changing the timer content by miliseconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTime(object sender, EventArgs e)
        {
            milisec++;
            if (milisec == 60)
            {
                milisec = 0;
                sec++;
            }

            if (sec == 60)
            {
                sec = 0;
                min++;
            }

            timer.Content = string.Format("{0}:{1}:{2}", min.ToString().PadLeft(2, '0'), sec.ToString().PadLeft(2, '0'), milisec.ToString().PadLeft(2, '0'));
        }
    }
}



