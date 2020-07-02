using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTPromet
{
    public partial class InterfaceVozilaForm : Form
    {
        public InterfaceVozilaForm()
        {
            InitializeComponent();
            
        }
        int brojac = 0;
        List<int> ruta = new List<int>();
         




        private void button8_Click(object sender, EventArgs e)
        {
            pocetakTb.Clear();
            krajTb.Clear();
            tbRutaVozila.Clear();
            SpuštanjeZastavica();
        }

        private void SpuštanjeZastavica()
        {
            for (int i = 0; i < 12; i++)
            {
                PrometForm.Zastavice[i] = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pocetakTb.Text.ToString() == "") pocetakTb.Text = "A";
            else if (pocetakTb.Text.ToString()!="A" && krajTb.Text.ToString() == "") krajTb.Text = "A";
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (pocetakTb.Text.ToString() == "") pocetakTb.Text = "B";
            else if (pocetakTb.Text.ToString() != "B" && krajTb.Text.ToString() == "") krajTb.Text = "B";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (pocetakTb.Text.ToString() == "") pocetakTb.Text = "D";
            else if (pocetakTb.Text.ToString() != "D" && krajTb.Text.ToString() == "") krajTb.Text = "D";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pocetakTb.Text.ToString() == "") pocetakTb.Text = "G";
            else if (pocetakTb.Text.ToString() != "G" && krajTb.Text.ToString() == "") krajTb.Text = "G";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (pocetakTb.Text.ToString() == "") pocetakTb.Text = "J";
            else if (pocetakTb.Text.ToString() != "J" && krajTb.Text.ToString() == "") krajTb.Text = "J";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pocetakTb.Text.ToString() == "") pocetakTb.Text = "I";
            else if (pocetakTb.Text.ToString() != "I" && krajTb.Text.ToString() == "") krajTb.Text = "I";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pocetakTb.Text.ToString() == "") pocetakTb.Text = "H";
            else if (pocetakTb.Text.ToString() != "H" && krajTb.Text.ToString() == "") krajTb.Text = "H";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pocetakTb.Text.ToString() == "") pocetakTb.Text = "F";
            else if (pocetakTb.Text.ToString() != "F" && krajTb.Text.ToString() == "") krajTb.Text = "F";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pocetakTb.Text.ToString() == "") pocetakTb.Text = "C";
            else if (pocetakTb.Text.ToString() != "C" && krajTb.Text.ToString() == "") krajTb.Text = "C";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pocetakTb.Text.ToString() == "") pocetakTb.Text = "E";
            else if (pocetakTb.Text.ToString() != "E" && krajTb.Text.ToString() == "") krajTb.Text = "E";

        }

        private void InterfaceVozilaForm_Load(object sender, EventArgs e)
        {
            timerVozila.Interval = 1000;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        List<int> ceste = new List<int>();
        int pocetak;
        int kraj;


        private void IspisNaLog(string tekst)
        {
            LogForm.porukaNova = tekst;

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            

            if (pocetakTb.Text.ToString() == "" | krajTb.Text.ToString() == "")
            {
                MessageBox.Show("Nisu uneseni početak i kraj rute!");
            }
            else
            {
                startButton.Enabled = false;
                IspisNaLog("Uneseni su podaci ishodišta i odredišta: " + pocetakTb.Text + " i " + krajTb.Text);
                MessageBox.Show("Uneseni su podaci ishodišta i odredišta!");


                var listaPozicija = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
                tbRutaVozila.Clear();
                                
                pocetak = listaPozicija.IndexOf(pocetakTb.Text.ToString());
                ceste.Add(pocetak);

                kraj = listaPozicija.IndexOf(krajTb.Text.ToString());

                
                ruta = kreiranjeRute(pocetak, kraj);

                foreach (int item in ruta)
                {
                    tbRutaVozila.Text = tbRutaVozila.Text + item.ToString() + " ";
                }


                timerVozila.Start();
            }




        }

        

        //public void dodavanjeceste(int cesta)
        //{
        //    int brojacsusjednihcesti = 0;
        //    for (int i = 0; i < 9; i++)
        //    {
        //        if (rasporedpozicija[kraj, i] > 0) brojacsusjednihcesti++;
        //    }
        //    if (brojacsusjednihcesti > 3)
        //    {
        //        if (pocetak < kraj) ceste.add(kraj - 1);
        //    }
        //    else ceste.add(kraj);

        //}

        public List<int> kreiranjeRute(int pocetak, int kraj)
        {
            //slanje poruke
            //LogForm.porukaNova = "Pokretanje algoritma za kreiranje rute vozila.\r\n";
            

            List<int> listaSusjeda = new List<int>();
            List<int> listaCvorova = new List<int>();
            List<int> listaPozicijaMeđuRaskrižjima = new List<int>();

            int[,] rasporedPozicija = new int[10, 10] {
                {0,1,1,1,0,0,0,0,0,0},
                {1,0,1,1,0,0,0,0,0,0},
                {1,1,0,1,0,0,0,0,0,0},
                {1,1,1,0,2,2,2,0,0,0},
                {0,0,0,2,0,2,2,0,0,0},
                {0,0,0,2,2,0,2,0,0,0},
                {0,0,0,2,2,2,0,3,3,3},
                {0,0,0,0,0,0,3,0,3,3},
                {0,0,0,0,0,0,3,3,0,3},
                {0,0,0,0,0,0,3,3,3,0},
                };

            IspisNaLog("Pokretanje algoritma za kreiranje rute vozila.");


            for (int i = 0; i < 9; i++)
            {
                int xbrojac = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (rasporedPozicija[i, j] > 0) xbrojac++;
                }
                if (xbrojac > 3) listaPozicijaMeđuRaskrižjima.Add(i);
            }
            //MessageBox.Show(listaPozicijaMeđuRaskrižjima.Count.ToString());



            //ako je ruta kroz 1 čvor
            if (rasporedPozicija[pocetak, kraj] > 0)
            {
                listaCvorova.Add(rasporedPozicija[pocetak, kraj]);
                
                ceste.Add(kraj);
                

            }
            else
            {
                //ako je ruta kroz 2 čvora
                for (int i = 0; i < 10; i++)
                {
                    if (rasporedPozicija[pocetak, i] > 0) listaSusjeda.Add(i);
                }

                foreach (int susjed in listaSusjeda)
                {
                    if (rasporedPozicija[susjed, kraj] > 0)
                    {

                        //izracun vrijednosti za zastavice ako postoji cesta među raskrižjima

                        //kraj izracuna i stare naredbe
                        listaCvorova.Add(rasporedPozicija[pocetak, susjed]);
                        listaCvorova.Add(rasporedPozicija[susjed, kraj]);
                        ceste.Add(susjed);
                        ceste.Add(kraj);
                        break;
                    }
                }
                //ako je ruta kroz 3 čvora
                if (listaCvorova.Count == 0)
                {
                    foreach (int susjed in listaSusjeda)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (rasporedPozicija[susjed, i] > 0 && rasporedPozicija[i, kraj] > 0)
                            {
                                                            

                                listaCvorova.Add(rasporedPozicija[pocetak, susjed]);
                                listaCvorova.Add(rasporedPozicija[susjed, i]);
                                listaCvorova.Add(rasporedPozicija[i, kraj]);


                                ceste.Add(susjed);
                                ceste.Add(i);
                                ceste.Add(kraj);
                                break;
                            }


                        }
                    }
                }

            }
            return listaCvorova;
        }

        private void timerVozila_Tick(object sender, EventArgs e)
        {
            brojac++;
            if (brojac < 4)
            {
                tbTrenutnaPozicija.Text = ruta[0].ToString();
                SpuštanjeZastavica();

                if (ruta[0] == 3) PrometForm.Zastavice[ceste[0] + 2] = 1;
                else if (ruta[0] == 2) PrometForm.Zastavice[ceste[0] + 1] = 1;
                else PrometForm.Zastavice[ceste[0]] = 1;

                //MessageBox.Show("Pozicija" + ceste[0].ToString());
                //PrometForm.

            }
            else if (brojac < 9 && ruta.Count>1)
            {

                tbTrenutnaPozicija.Text = ruta[1].ToString();
                SpuštanjeZastavica();
                //staro
                //PrometForm.Zastavice[ceste[1]] = 1;

                if (ruta[1] == 3) PrometForm.Zastavice[ceste[1] + 2] = 1;
                else if (ruta[1] == 2) PrometForm.Zastavice[ceste[1] + 1] = 1;
                else PrometForm.Zastavice[ceste[1]] = 1;





                //MessageBox.Show("Pozicija" + ceste[1].ToString());


            }
            else if (brojac < 13 && ruta.Count > 2)
            {

                tbTrenutnaPozicija.Text = ruta[2].ToString();
                SpuštanjeZastavica();

                if (ruta[2] == 3) PrometForm.Zastavice[ceste[2] + 2] = 1;
                else if (ruta[2] == 2) PrometForm.Zastavice[ceste[2] + 1] = 1;
                else PrometForm.Zastavice[ceste[2]] = 1;


                //staro: PrometForm.Zastavice[ceste[2]] = 1;


                //MessageBox.Show("Pozicija" + ceste[2].ToString());

            }
            else
            {
                timerVozila.Stop();
                brojac = 0;
                SpuštanjeZastavica();


                //MessageBox.Show("Pozicija" + ceste.Last().ToString());
                //SpuštanjeZastavica();
                
                //PrometForm.Zastavice[ceste.Last()] = 1;
                MessageBox.Show("Vozilo je stiglo na odredište");
                IspisNaLog("Vozilo je stiglo na odredište \r\nSustav se vraća u neprioritetni način rada");
                //MessageBox.Show(PrometForm.Zastavice.Max().ToString());


                startButton.Enabled = true;
                tbRutaVozila.Clear();
                pocetakTb.Clear();
                krajTb.Clear();
                ceste.Clear();
                timerVozila.Stop();
                tbTrenutnaPozicija.Clear();

                SpuštanjeZastavica();
            }



        }
    }
}
