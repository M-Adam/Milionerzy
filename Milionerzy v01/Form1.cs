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

namespace Milionerzy_v01
{
    public partial class Form1 : Form
    {
        private int ktore = 0, naIle=0, wynik=0;
        private long kasa = 0,gwarant=0;
        private string nazwaPlikuZPytaniami = "quiz1.txt";
        private string nazwaPlikuZWynikami = "wyniki.txt";
        private char odp;
        private char udzielonaOdp;
        private bool czyIdziemyDalej = true;
        

        public Form1()
        {
            InitializeComponent();
        }

        public int ZliczPytania()
        {
            int ilosc = 0;
            try
            {
                using (StreamReader sr = new StreamReader(nazwaPlikuZPytaniami))
                {
                    for (int i = 0; sr.ReadLine()!=null; i++)
                    {
                        ilosc++;
                    }
                   return ilosc/6;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Nie udało się wczytać pliku\nBłąd: " + e.Message,
                    this.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return 0;
            }
        }

        

        

        public string PobierzTresc(string nazwaPliku, char co)
        {
            try
            {
                using (StreamReader sr = new StreamReader(nazwaPlikuZPytaniami,Encoding.Default, true))
                {
                    int pytCzyOdp=0;
                    switch (co)
                    {
                        case 'P':
                            pytCzyOdp = 0;
                            break;
                        case 'A':
                            pytCzyOdp = 1;
                            break;
                        case 'B':
                            pytCzyOdp = 2;
                            break;
                        case 'C':
                            pytCzyOdp = 3;
                            break;
                        case 'D':
                            pytCzyOdp = 4;
                            break;
                        case 'O':
                            pytCzyOdp = 5;
                            break;
                    }
                    for (int i = 0; i < (ktore*6)+pytCzyOdp; i++)
                    {
                        sr.ReadLine();
                    }
                    string tresc = sr.ReadLine();
                    
                    return tresc;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Nie udało się wczytać pliku\nBłąd: "+e.Message,
                    this.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        private void wylaczRadio()
        {
           

            radioButtonA.Enabled = false;
            radioButtonB.Enabled = false;
            radioButtonD.Enabled = false;
            radioButtonC.Enabled = false;
        }

        private void wlaczRadio()
        {
            radioButtonA.Enabled = true;
            radioButtonB.Enabled = true;
            radioButtonD.Enabled = true;
            radioButtonC.Enabled = true; 
        }

        private void wyczyscRadio()
        {
            radioButtonA.Checked = false;
            radioButtonB.Checked = false;
            radioButtonC.Checked = false;
            radioButtonD.Checked = false;
        }

        private void wylaczTextBoxy()
        {
            textBoxA.Enabled = false;
            textBoxB.Enabled = false;
            textBoxC.Enabled = false;
            textBoxD.Enabled = false;
        }

        private void przywrocKolory()
        {
            textBoxA.BackColor = DefaultBackColor;
            textBoxB.BackColor = DefaultBackColor;
            textBoxC.BackColor = DefaultBackColor;
            textBoxD.BackColor = DefaultBackColor;
        }

        public void KoniecGry(bool czySamemu=false)
        {
            button1Pytanie.Enabled = false;
            button1sprawdz.Enabled = false;
            wyczyscRadio();
            wylaczRadio();
            przywrocKolory();
            wylaczTextBoxy();

            long wygrana;
            if (czySamemu) 
                wygrana = kasa;
            else 
                wygrana = gwarant;



            DialogResult dr = MessageBox.Show("Wygrałeś: " + wygrana.ToString() + "$" + "\nCzy chcesz spróbować ponownie?",
                "Koniec Gry",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            switch (dr)
            {
                case DialogResult.Yes:
                    Application.Restart();
                    break;
                case DialogResult.No:
                    Application.Exit();
                    break;
            }
        }

        private void nagrodaEnable()
        {
            switch (ktore)
            {
                case 0:
                    checkBox1.Enabled = true;
                    break;
                case 1:
                    checkBox2.Enabled = true;
                    break;
                case 2:
                    checkBox3.Enabled = true;
                    break;
                case 3:
                    checkBox4.Enabled = true;
                    break;
                case 4:
                    checkBox5.Enabled = true;
                    break;
                case 5:
                    checkBox6.Enabled = true;
                    break;
                case 6:
                    checkBox7.Enabled = true;
                    break;
                case 7:
                    checkBox8.Enabled = true;
                    break;
                case 8:
                    checkBox9.Enabled = true;
                    break;
                case 9:
                    checkBox10.Enabled = true;
                    break;
                case 10:
                    checkBox11.Enabled = true;
                    break;
                case 11:
                    checkBox12.Enabled = true;
                    break;
                case 12:
                    checkBox13.Enabled = true;
                    break;
                case 13:
                    checkBox14.Enabled = true;
                    break;
                case 14:
                    checkBox15.Enabled = true;
                    break;
            }
        }
        private void nagrodaChecked()
        {
            switch (ktore-1)
            {
                case 0:
                    checkBox1.Checked = true;
                    kasa = 100;
                    break;
                case 1:
                    checkBox2.Checked = true;
                    kasa = 200;
                    break;
                case 2:
                    checkBox3.Checked = true;
                    kasa = 300;
                    break;
                case 3:
                    checkBox4.Checked = true;
                    kasa = 500;
                    break;
                case 4:
                    checkBox5.Checked = true;
                    kasa = 1000;
                    gwarant = 1000;
                    break;
                case 5:
                    checkBox6.Checked = true;
                    kasa = 2000;
                    break;
                case 6:
                    checkBox7.Checked = true;
                    kasa = 4000;
                    break;
                case 7:
                    checkBox8.Checked = true;
                    kasa = 8000;
                    break;
                case 8:
                    checkBox9.Checked = true;
                    kasa = 16000;
                    break;
                case 9:
                    checkBox10.Checked = true;
                    kasa = 32000;
                    gwarant = 32000;
                    break;
                case 10:
                    checkBox11.Checked = true;
                    kasa = 64000;
                    break;
                case 11:
                    checkBox12.Checked = true;
                    kasa = 125000;
                    break;
                case 12:
                    checkBox13.Checked = true;
                    kasa = 250000;
                    break;
                case 13:
                    checkBox14.Checked = true;
                    kasa = 500000;
                    break;
                case 14:
                    checkBox15.Checked = true;
                    kasa = 1000000;
                    gwarant = 1000000;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ktore == 0)
            {
                naIle = ZliczPytania();
                podpowiedźToolStripMenuItem.Enabled = true;
                toolStripStatusLabel3.Text = nazwaPlikuZPytaniami;
            }
            if (ktore == 14)
            {
                KoniecGry();
            }
            button1sprawdz.Enabled = true;


            nagrodaEnable();
            przywrocKolory();
            wlaczRadio();
            wyczyscRadio();

            if (ktore < naIle)
            {
                richTextBox1.Text = PobierzTresc(nazwaPlikuZPytaniami, 'P');
                textBoxA.Text = PobierzTresc(nazwaPlikuZPytaniami, 'A');
                textBoxB.Text = PobierzTresc(nazwaPlikuZPytaniami, 'B');
                textBoxC.Text = PobierzTresc(nazwaPlikuZPytaniami, 'C');
                textBoxD.Text = PobierzTresc(nazwaPlikuZPytaniami, 'D');
                odp = PobierzTresc(nazwaPlikuZPytaniami, 'O').ToCharArray()[0];
                toolStripStatusLabel1.Text = "Pytanie " + (ktore + 1).ToString() + "/" + naIle.ToString();
                ktore++;
                button1Pytanie.Enabled = false;
                button1sprawdz.Enabled = false;
            }
            else
            {
                MessageBox.Show("Nie ma więcej pytań!", this.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                KoniecGry();
            }
        }

        private void button1sprawdz_Click(object sender, EventArgs e)
        {
            switch (odp)
            {
                case 'A':
                    if (radioButtonA.Checked)
                    {
                        textBoxA.BackColor = Color.Chartreuse;
                        wynik++;
                        
                    }
                    else
                    {
                        
                        czyIdziemyDalej = false;
                    }
                    break;
                case 'B':
                    if (radioButtonB.Checked)
                    {
                        textBoxB.BackColor = Color.Chartreuse;
                        wynik++;
                    }
                    else
                    {
                        
                        czyIdziemyDalej = false;
                    }
                    break;
                case 'C':
                    if (radioButtonC.Checked)
                    {
                        textBoxC.BackColor = Color.Chartreuse;
                        wynik++;
                        
                    }
                    else
                    {
                        
                        czyIdziemyDalej = false;
                    }
                    break;
                case 'D':
                    if (radioButtonD.Checked)
                    {
                        textBoxD.BackColor = Color.Chartreuse;
                        wynik++;
                    }
                    else
                    {
                       
                        czyIdziemyDalej = false;
                        
                    }
                    break;
            }
            toolStripStatusLabel1.Text = "Punkty: " + wynik.ToString();
            button1Pytanie.Enabled = true;
            button1sprawdz.Enabled = false;
            
            if (!czyIdziemyDalej)
            {
                MessageBox.Show("Zła odpowiedź!", this.Text,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Stop);
                KoniecGry();
            }
            else
            {
                nagrodaChecked();
            }

        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KoniecGry(true);
        }

        private void jeszczeRazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void podpowiedźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Poprawna odpowiedź: " + odp.ToString(),"Podpowiedź",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            podpowiedźToolStripMenuItem.Enabled = false;
        }

        private void radioButtonA_B_C_D_Click(object sender, EventArgs e)
        {
            button1sprawdz.Enabled = true;
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(nazwaPlikuZPytaniami);
        }
      

        




    }
    public class C_Gracz
    {
        public string nick;
        public int wynik;
    }
}
