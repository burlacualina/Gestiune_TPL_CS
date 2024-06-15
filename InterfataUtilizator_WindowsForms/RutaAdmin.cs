using Librarie_Modele;
using NivellStocareDate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class RutaAdmin : Form
    {
        IStocareDataRuta adminrute;
        private System.Windows.Forms.Label[] lblsPunctStart;
        private System.Windows.Forms.Label[] lblsDestinatie;
        private System.Windows.Forms.Label[] lblsOraStart;
        private System.Windows.Forms.Label[] lblsOraDestinatie;

        private const int LATIME_CONTROL = 100;
        private const int OFFSET_X = 50; // Mută tabelul mai la dreapta
        private const int DIMENSIUNE_PAS_X = 150; // Reduce distanța dintre coloane
        private const int DIMENSIUNE_PAS_Y = 30;

        public RutaAdmin()
        {
            InitializeComponent();
            adminrute = StocareFactory.GetStocareDataRute();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ResetareControaleRuta()
        {
            // Resetează proprietățile clasei Ruta
            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;

            // Resetează label-ul pentru afișarea mesajului de eroare
            label6.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validarea datelor introduse
            bool allGood = true;

            // Verificarea câmpurilor
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.ForeColor = Color.Red;
                allGood = false;
            }
            else if (textBox2.Text.Length > 15)
            {
                textBox2.ForeColor = Color.Red;
                allGood = false;
            }
            else
            {
                textBox2.ForeColor = Color.Black;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.ForeColor = Color.Red;
                allGood = false;
            }
            else if (textBox3.Text.Length > 15)
            {
                textBox3.ForeColor = Color.Red;
                allGood = false;
            }
            else
            {
                textBox3.ForeColor = Color.Black;
            }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.ForeColor = Color.Red;
                allGood = false;
            }
            else
            {
                textBox4.ForeColor = Color.Black;
            }

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.ForeColor = Color.Red;
                allGood = false;
            }
            else
            {
                textBox5.ForeColor = Color.Black;
            }

            // Dacă toate câmpurile sunt valide, adaugă ruta în fișier
            if (allGood)
            {
                Ruta rute = new Ruta(
                    textBox2.Text,
                    textBox3.Text,
                    textBox4.Text,
                    textBox5.Text
                );

                adminrute.AddRutaFisier(rute);

                label6.Text = "Ruta adăugata cu succes!";
                label6.ForeColor = Color.Green;
            }
            else
            {
                label6.Text = "Informații introduse incorect!";
                label6.ForeColor = Color.Red;
            }
            ResetareControaleRuta();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AfiseazaRute();
        }

        private void AfiseazaRute()
        {
            // Asigură-te că `adminRuta` este inițializat
            if (adminrute == null)
            {
                MessageBox.Show("AdminRuta nu este inițializat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Elimină etichetele existente, dacă există
            if (lblsPunctStart != null)
            {
                foreach (System.Windows.Forms.Label lbl in lblsPunctStart) this.Controls.Remove(lbl);
                foreach (System.Windows.Forms.Label lbl in lblsDestinatie) this.Controls.Remove(lbl);
                foreach (System.Windows.Forms.Label lbl in lblsOraStart) this.Controls.Remove(lbl);
                foreach (System.Windows.Forms.Label lbl in lblsOraDestinatie) this.Controls.Remove(lbl);
            }

            List<Ruta> rute = adminrute.GetRutaFisier();
            if (rute == null || rute.Count == 0)
            {
                MessageBox.Show("Nu există rute de afișat!", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int nrRute = rute.Count;
            lblsPunctStart = new System.Windows.Forms.Label[nrRute];
            lblsDestinatie = new System.Windows.Forms.Label[nrRute];
            lblsOraStart = new System.Windows.Forms.Label[nrRute];
            lblsOraDestinatie = new System.Windows.Forms.Label[nrRute];

            int i = 0;
            foreach (Ruta ruta in rute)
            {
                // adaugare control de tip Label pentru punctul de start al rutei
                lblsPunctStart[i] = new System.Windows.Forms.Label();
                lblsPunctStart[i].Width = LATIME_CONTROL;
                lblsPunctStart[i].Text = ruta.punctStart;
                lblsPunctStart[i].Left = OFFSET_X;
                lblsPunctStart[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPunctStart[i]);

                // adaugare control de tip Label pentru destinația rutei
                lblsDestinatie[i] = new System.Windows.Forms.Label();
                lblsDestinatie[i].Width = LATIME_CONTROL;
                lblsDestinatie[i].Text = ruta.destinatie;
                lblsDestinatie[i].Left = OFFSET_X + DIMENSIUNE_PAS_X;
                lblsDestinatie[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsDestinatie[i]);

                // adaugare control de tip Label pentru ora de start a rutei
                lblsOraStart[i] = new System.Windows.Forms.Label();
                lblsOraStart[i].Width = LATIME_CONTROL;
                lblsOraStart[i].Text = ruta.oraStart;
                lblsOraStart[i].Left = OFFSET_X + 2 * DIMENSIUNE_PAS_X;
                lblsOraStart[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsOraStart[i]);

                // adaugare control de tip Label pentru ora de destinație a rutei
                lblsOraDestinatie[i] = new System.Windows.Forms.Label();
                lblsOraDestinatie[i].Width = LATIME_CONTROL;
                lblsOraDestinatie[i].Text = ruta.oraDest;
                lblsOraDestinatie[i].Left = OFFSET_X + 3 * DIMENSIUNE_PAS_X;
                lblsOraDestinatie[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsOraDestinatie[i]);

                i++;
            }
        }
    }
}
