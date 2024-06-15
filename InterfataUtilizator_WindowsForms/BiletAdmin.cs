using Librarie_Modele;
using Librarie_Modele.Enumerari;
using NivellStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace InterfataUtilizator_WindowsForms
{
    public partial class BiletAdmin : Form

    {
       
        IStocareDataBilet adminBilet;

        private Label[] lblsPunctStart;
        private Label[] lblsDestinatie;
        private Label[] lblsOraStart;
        private Label[] lblsOraDestinatie;
        private Label[] lblsData;
        private Label[] lblsTipBilet;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 100;
        private const int OFFSET_X = 300;
        public BiletAdmin()
        {
            InitializeComponent();
            adminBilet = StocareFactory.GetStocareData();
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BiletAdmin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ResetareControaleBilet()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;

            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = false;

            label8.Text = string.Empty;
        }
        private void lstAfisare_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                if (listBox1.SelectedItem != null)
                {
                    Bilet biletSelectat = (Bilet)listBox1.SelectedItem;
                listBox1.Text = biletSelectat.punctStart;
                listBox1.Text = biletSelectat.destinatie;
                listBox1.Text = biletSelectat.oraStart;
                listBox1.Text = biletSelectat.oraDest;
                listBox1.Text = biletSelectat.data;
                }
       
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
          ///  List<Bilet> bilete = adminBilet.GetBilete();
            AfiseazaBilete();
         //   AfisareEvenimenteInControlListbox(evenimente);
           // AfisareEvenimenteInControlDataGridView(evenimente);
        }
        private void AfiseazaBilete()
        {
            // Asigură-te că `adminBilet` este inițializat
            if (adminBilet == null)
            {
                MessageBox.Show("AdminBilet nu este inițializat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Elimină etichetele existente, dacă există
            if (lblsPunctStart != null)
            {
                foreach (Label lbl in lblsPunctStart) this.Controls.Remove(lbl);
                foreach (Label lbl in lblsDestinatie) this.Controls.Remove(lbl);
                foreach (Label lbl in lblsOraStart) this.Controls.Remove(lbl);
                foreach (Label lbl in lblsOraDestinatie) this.Controls.Remove(lbl);
                foreach (Label lbl in lblsData) this.Controls.Remove(lbl);
                foreach (Label lbl in lblsTipBilet) this.Controls.Remove(lbl);
            }

            List<Bilet> bilete = adminBilet.GetBilete();
            if (bilete == null || bilete.Count == 0)
            {
                MessageBox.Show("Nu există bilete de afișat!", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int nrBilete = bilete.Count;
            lblsPunctStart = new Label[nrBilete];
            lblsDestinatie = new Label[nrBilete];
            lblsOraStart = new Label[nrBilete];
            lblsOraDestinatie = new Label[nrBilete];
            lblsData = new Label[nrBilete];
            lblsTipBilet = new Label[nrBilete];

            int i = 0;
            foreach (Bilet bilet in bilete)
            {
                // adaugare control de tip Label pentru punctul de start al biletului
                lblsPunctStart[i] = new Label();
                lblsPunctStart[i].Width = LATIME_CONTROL;
                lblsPunctStart[i].Text = bilet.punctStart;
                lblsPunctStart[i].Left = OFFSET_X + DIMENSIUNE_PAS_X;
                lblsPunctStart[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPunctStart[i]);

                // adaugare control de tip Label pentru destinația biletului
                lblsDestinatie[i] = new Label();
                lblsDestinatie[i].Width = LATIME_CONTROL;
                lblsDestinatie[i].Text = bilet.destinatie;
                lblsDestinatie[i].Left = OFFSET_X + 2 * DIMENSIUNE_PAS_X;
                lblsDestinatie[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsDestinatie[i]);

                // adaugare control de tip Label pentru ora de start a biletului
                lblsOraStart[i] = new Label();
                lblsOraStart[i].Width = LATIME_CONTROL;
                lblsOraStart[i].Text = bilet.oraStart;
                lblsOraStart[i].Left = OFFSET_X + 3 * DIMENSIUNE_PAS_X;
                lblsOraStart[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsOraStart[i]);

                // adaugare control de tip Label pentru ora de destinație a biletului
                lblsOraDestinatie[i] = new Label();
                lblsOraDestinatie[i].Width = LATIME_CONTROL;
                lblsOraDestinatie[i].Text = bilet.oraDest;
                lblsOraDestinatie[i].Left = OFFSET_X + 4 * DIMENSIUNE_PAS_X;
                lblsOraDestinatie[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsOraDestinatie[i]);

                // adaugare control de tip Label pentru data biletului
                lblsData[i] = new Label();
                lblsData[i].Width = LATIME_CONTROL;
                lblsData[i].Text = bilet.data;
                lblsData[i].Left = OFFSET_X + 5 * DIMENSIUNE_PAS_X;
                lblsData[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsData[i]);

                // adaugare control de tip Label pentru tipul biletului
                lblsTipBilet[i] = new Label();
                lblsTipBilet[i].Width = LATIME_CONTROL;
                lblsTipBilet[i].Text = bilet.tip.ToString();
                lblsTipBilet[i].Left = OFFSET_X + 6 * DIMENSIUNE_PAS_X;
                lblsTipBilet[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsTipBilet[i]);

                i++;
            }
        }



        private TipBilet GetTipBiletSelectat()
    {
        if (radioButton1.Checked)
            return TipBilet.Bilet;
        if (radioButton2.Checked)
            return TipBilet.Abonament_Zi;
        if (radioButton3.Checked)
            return TipBilet.Abonament_Luna;

        return TipBilet.Bilet; // Sau alege alt tip implicit, în funcție de necesități
    }
    private void button1_Click(object sender, EventArgs e)
        {
            // Validarea datelor introduse
            bool allGood = true;

            // Verificarea câmpurilor
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.ForeColor = Color.Red;
                allGood = false;
            }
            else if (textBox1.Text.Length > 15)
            {
                textBox1.ForeColor = Color.Red;
                allGood = false;
            }
            else
            {
                textBox1.ForeColor = Color.Black;
            }

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


            // Dacă toate câmpurile sunt valide, adaugă biletul în fișier
            if (allGood)
            {  
                Bilet bilet = new Bilet(
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    textBox4.Text,
                    textBox5.Text
                );

                TipBilet tipSelectat = GetTipBiletSelectat();
                bilet.tip = tipSelectat;

        
                adminBilet.AddBilet(bilet);

                label8.Text = "Bilet adăugat cu succes!";
                label8.ForeColor = Color.Green;
            }
            else
            {
                label8.Text = "Informații introduse incorect!";
                label8.ForeColor = Color.Red;
            }
            ResetareControaleBilet();
        }
  
        private void button3_Click(object sender, EventArgs e)
        {
            string punctStart = textBox6.Text.Trim();
            if (string.IsNullOrEmpty(punctStart))
            {
                label10.Text = "Introduceti punctul de start al evenimentului!";
                label10.ForeColor = Color.Red;
                return;
            }

            List<Bilet> bileteGasite = adminBilet.GetBiletPunctStart(punctStart);
            if (bileteGasite == null || bileteGasite.Count == 0)
            {
                label10.Text = "Nu a fost găsit niciun eveniment cu acest punct de start!";
                label10.ForeColor = Color.Red;
                return;
            }

            AfiseazaBilete(bileteGasite);
        }

        private void AfiseazaBilete(List<Bilet> bilete)
        {
            listBox1.Items.Clear();
            foreach (Bilet bilet in bilete)
            {
                listBox1.Items.Add($"{bilet.punctStart} - {bilet.destinatie}");
            }

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("PunctStart");
            dataTable.Columns.Add("Destinatie");
            dataTable.Columns.Add("OraStart");
            dataTable.Columns.Add("OraDest");
            dataTable.Columns.Add("Data");

            foreach (Bilet bilet in bilete)
            {
                dataTable.Rows.Add(bilet.punctStart, bilet.destinatie, bilet.oraStart, bilet.oraDest, bilet.data);
            }

            dataGridView1.DataSource = dataTable;
        }


    }
}
