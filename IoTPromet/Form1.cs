using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTPromet
{
    public partial class PrometForm : Form
    {
        public PrometForm()
        {
            InitializeComponent();

        }

        private void PrometForm_Load(object sender, EventArgs e)
        {
            timerR1.Interval = 1000;
            timerR2.Interval = 1000;
            timerR3.Interval = 1000;
            timerR3.Start();
            timerR1.Start();
            timerR2.Start();
            Form f2 = new InterfaceVozilaForm();
            Form f3 = new LogForm();
            f2.Show();
            f3.Show();

            string defText = "Vozilo prilazi raskrižju!";
            labelR1I.Text = defText;
            labelR1J.Text = defText;
            labelR1S.Text = defText;
            labelR1Z.Text = defText;
            labelR2I.Text = defText;
            labelR2J.Text = defText;
            labelR2S.Text = defText;
            labelR2Z.Text = defText;
            labelR3I.Text = defText;
            labelR3J.Text = defText;
            labelR3S.Text = defText;
            labelR3Z.Text = defText;


            BrisanjeOznaka();
            
            
        }

        private void IspisNaLog(string tekst)
        {
            LogForm.porukaNova = tekst;

        }

        public void BrisanjeOznaka()
        {
            //labelR1I.Show();
            //labelR1J.Show();
            //labelR1S.Show();
            //labelR1Z.Show();
            //labelR2I.Show();
            //labelR2J.Show();
            //labelR2S.Show();
            //labelR2Z.Show();
            //labelR3I.Show();
            //labelR3J.Show();
            //labelR3S.Show();
            //labelR3Z.Show();


            labelR1I.Hide();
            labelR1J.Hide();
            labelR1S.Hide();
            labelR1Z.Hide();
            labelR2I.Hide();
            labelR2J.Hide();
            labelR2S.Hide();
            labelR2Z.Hide();
            labelR3I.Hide();
            labelR3J.Hide();
            labelR3S.Hide();
            labelR3Z.Hide();
        }

        public void BrisanjeOznakaR1()
        {

            labelR1I.Hide();
            labelR1J.Hide();
            labelR1S.Hide();
            labelR1Z.Hide();
        }

        public void BrisanjeOznakaR2()
        {
            labelR2I.Hide();
            labelR2J.Hide();
            labelR2S.Hide();
            labelR2Z.Hide();
        }
        public void BrisanjeOznakaR3()
        {
            labelR3I.Hide();
            labelR3J.Hide();
            labelR3S.Hide();
            labelR3Z.Hide();
        }






        public static int[] Zastavice = new int[12];

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int brojacR1 = 0;
        int brojacR2 = 0;
        int brojacR3 = 0;


        private int[] zastavicaR1 = new int[4];
        private int[] zastavicaR2 = new int[4];
        private int[] zastavicaR3 = new int[4];

        private int citanjeZastavicaR1()
        {
            int brojZastavice = -1;

            for (int i = 0; i < 4; i++)
            {
                if (Zastavice[i] > 0) brojZastavice = i;
            }
            return brojZastavice;
        }
        private int citanjeZastavicaR2()
        {
            int brojZastavice = -1;

            for (int i = 4; i < 8; i++)
            {
                if (Zastavice[i] > 0) brojZastavice = i-4;
            }
            return brojZastavice;
        }


        private int citanjeZastavicaR3()
        {
            int brojZastavice = -1;

            for (int i = 8; i < 12; i++)
            {
                if (Zastavice[i] > 0) brojZastavice = i-8;
            }
            return brojZastavice;
        }



        private void timerR1_Tick(object sender, EventArgs e)
        {
            brojacR1++;
            if (brojacR1 < 5 & citanjeZastavicaR1()==-1)
            {
                BrisanjeOznakaR1();
                semaforR1I.BackColor = Color.Red;
                semaforR1Z.BackColor = Color.Red;
                semaforR1S.BackColor = Color.LightGreen;
                semaforR1J.BackColor = Color.LightGreen;
            }
            else if(brojacR1 < 7 & citanjeZastavicaR1() == -1)
            {
                BrisanjeOznakaR1();
                semaforR1I.BackColor = Color.Yellow;
                semaforR1Z.BackColor = Color.Yellow;
                semaforR1S.BackColor = Color.Red;
                semaforR1J.BackColor = Color.Red;
            }
            else if(brojacR1 < 12 & citanjeZastavicaR1() == -1)
            {
                BrisanjeOznakaR1();
                semaforR1I.BackColor = Color.LightGreen;
                semaforR1Z.BackColor = Color.LightGreen;
                semaforR1S.BackColor = Color.Red;
                semaforR1J.BackColor = Color.Red;
            }
            else if(brojacR1 < 14 & citanjeZastavicaR1() == -1)
            {
                BrisanjeOznakaR1();
                semaforR1I.BackColor = Color.Red;
                semaforR1Z.BackColor = Color.Red;
                semaforR1S.BackColor = Color.Yellow;
                semaforR1J.BackColor = Color.Yellow;
            }
            else if (brojacR1 >= 14 && citanjeZastavicaR1() == -1)
            {
                brojacR1 = 0;
            }
            else if ( citanjeZastavicaR1()> -1)
            {

                IspisNaLog("Raskrižje R1 prelazi na prioritetni rad.");
                //pali sva crvena i mičem oznake
                semaforR1I.BackColor = Color.Red;
                semaforR1Z.BackColor = Color.Red; 
                semaforR1S.BackColor = Color.Red;
                semaforR1J.BackColor = Color.Red;
                //odredi od kud dolazi vozilo i upali zeleno
                

                if (citanjeZastavicaR1() == 0)
                {
                    
                    semaforR1I.BackColor = Color.LightGreen;
                    labelR1I.Show();
                    
                }
                else if (citanjeZastavicaR1() == 1)
                {
                    semaforR1S.BackColor = Color.LightGreen;
                    labelR1S.Show();
                }
                else if (citanjeZastavicaR1() == 2)
                {
                    semaforR1Z.BackColor = Color.LightGreen;
                    labelR1Z.Show();
                }
                else
                {
                    semaforR1J.BackColor = Color.LightGreen;
                    labelR1J.Show();
                }


            }

        }

        private void timerR2_Tick(object sender, EventArgs e)
        {
            brojacR2++;
            if (brojacR2 < 5 && citanjeZastavicaR2() == -1)
            {
                BrisanjeOznakaR2();
                semaforR2I.BackColor = Color.Red;
                semaforR2Z.BackColor = Color.Red;
                semaforR2S.BackColor = Color.LightGreen;
                semaforR2J.BackColor = Color.LightGreen;
            }
            else if (brojacR2 < 7 && citanjeZastavicaR2() == -1)
            {
                BrisanjeOznakaR2();
                semaforR2I.BackColor = Color.Yellow;
                semaforR2Z.BackColor = Color.Yellow;
                semaforR2S.BackColor = Color.Red;
                semaforR2J.BackColor = Color.Red;
            }
            else if (brojacR2 < 12 && citanjeZastavicaR2() == -1)
            {
                BrisanjeOznakaR2();
                semaforR2I.BackColor = Color.LightGreen;
                semaforR2Z.BackColor = Color.LightGreen;
                semaforR2S.BackColor = Color.Red;
                semaforR2J.BackColor = Color.Red;
            }
            else if (brojacR2 < 14 && citanjeZastavicaR2() == -1)
            {
                BrisanjeOznakaR2();
                semaforR2I.BackColor = Color.Red;
                semaforR2Z.BackColor = Color.Red;
                semaforR2S.BackColor = Color.Yellow;
                semaforR2J.BackColor = Color.Yellow;
            }
            else if (brojacR2 >= 14 && citanjeZastavicaR2() == -1)
            {
                brojacR2 = 0;
            }
            else if (citanjeZastavicaR2() > -1)
            {

                IspisNaLog("Raskrižje R2 prelazi na prioritetni rad.");

                //pali sva crvena



                semaforR2I.BackColor = Color.Red;
                semaforR2Z.BackColor = Color.Red;
                semaforR2S.BackColor = Color.Red;
                semaforR2J.BackColor = Color.Red;

                //odredi od kud dolazi vozilo i upali zeleno
                if (citanjeZastavicaR2() == 0)
                {
                    semaforR2S.BackColor = Color.LightGreen;
                    labelR2S.Show();
                }
                else if (citanjeZastavicaR2() == 1)
                {
                    semaforR2Z.BackColor = Color.LightGreen;
                    labelR2Z.Show();

                }
                else if (citanjeZastavicaR2() == 2)
                {
                    semaforR2J.BackColor = Color.LightGreen;
                    labelR2J.Show();
                }
                else
                {
                    semaforR2I.BackColor = Color.LightGreen;
                    labelR2I.Show();

                }

            }
        }

        private void timerR3_Tick(object sender, EventArgs e)
        {
            brojacR3++;
            if (brojacR3 < 9 && citanjeZastavicaR3() == -1)
            {
                BrisanjeOznakaR3();
                semaforR3I.BackColor = Color.Red;
                semaforR3Z.BackColor = Color.Red;
                semaforR3S.BackColor = Color.LightGreen;
                semaforR3J.BackColor = Color.LightGreen;
            }
            else if (brojacR3 < 12 && citanjeZastavicaR3() == -1)
            {
                BrisanjeOznakaR3();
                semaforR3I.BackColor = Color.Yellow;
                semaforR3Z.BackColor = Color.Yellow;
                semaforR3S.BackColor = Color.Red;
                semaforR3J.BackColor = Color.Red;
            }
            else if (brojacR3 < 18 && citanjeZastavicaR3() == -1)
            {
                BrisanjeOznakaR3();
                semaforR3I.BackColor = Color.LightGreen;
                semaforR3Z.BackColor = Color.LightGreen;
                semaforR3S.BackColor = Color.Red;
                semaforR3J.BackColor = Color.Red;
            }
            else if (brojacR3 < 20 && citanjeZastavicaR3() == -1)
            {
                BrisanjeOznakaR3();
                semaforR3I.BackColor = Color.Red;
                semaforR3Z.BackColor = Color.Red;
                semaforR3S.BackColor = Color.Yellow;
                semaforR3J.BackColor = Color.Yellow;
            }
            else if (brojacR3 >= 20 && citanjeZastavicaR3() == -1)
            {
                brojacR3 = 0;
            }
            else if (citanjeZastavicaR3() > -1)
            {

                IspisNaLog("Raskrižje R3 prelazi na prioritetni rad.");
                //pali sva crvena
                semaforR3I.BackColor = Color.Red;
                semaforR3Z.BackColor = Color.Red;
                semaforR3S.BackColor = Color.Red;
                semaforR3J.BackColor = Color.Red;
                //odredi od kud dolazi vozilo i upali zeleno
                if (citanjeZastavicaR3() == 0)
                {
                    semaforR3Z.BackColor = Color.LightGreen;
                    labelR3Z.Show();

                }
                else if (citanjeZastavicaR3() == 1)
                {
                    semaforR3J.BackColor = Color.LightGreen;
                    labelR3J.Show();

                }
                else if (citanjeZastavicaR3() == 2)
                {
                    semaforR3I.BackColor = Color.LightGreen;
                    labelR3I.Show();

                }
                else
                {
                    semaforR3S.BackColor = Color.LightGreen;
                    labelR3S.Show();

                }

            }
        }
    }
}
