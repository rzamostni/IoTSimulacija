using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTPromet
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            timerLogForme.Interval = 1;
            timerLogForme.Start();
        }

        private int brojac = 0;
        public static string porukaStara = "";
        public static string porukaNova = "";

        private void button12_Click(object sender, EventArgs e)
        {
            tbLog.Clear();
        }

        private void timerLogForme_Tick(object sender, EventArgs e)
        {
            brojac++;
            if (porukaStara != porukaNova)
            {
                tbLog.Text = tbLog.Text + "Sistemski brojač:" + brojac.ToString() + " Poruka: " + porukaNova+ "\r\n";
                porukaStara = porukaNova;
            }
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText("D:\\log.txt", tbLog.Text);
        }
    }
}
