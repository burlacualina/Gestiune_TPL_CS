using Librarie_Modele;
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

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public class Forma1 : Form
        {
           
            private Label lblTitlu;
            private Label lblTitlu2;
            private Label lblPunctStart;
            private Label lblDestinatie;
            private Label lblOraStart;
            private Label lblOraDestinatie;
            private Label lblData;
            private Label lblBilet;
            private Label lblSalvare;
            private TextBox txtStart;
            private TextBox txtDestinatie;
            private TextBox txtOraStart;
            private TextBox txtOraDestinatie;
            private TextBox txtData;
            private Label lblRefresh;
            
            private const int LATIME_CONTROL = 150;
            private const int LUNGIME_CONTROL = 30;
            private const int DIMENSIUNE_PAS_Y = 50;
            private const int DIMENSIUNE_PAS_X = 170;
            AdministrareBilete_FisierText adminParticipanti;
            private Button addBilet;
            private Button btnRefresh;
            public Forma1()
            {

               
                this.Size = new System.Drawing.Size(1000, 400);
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new System.Drawing.Point(100, 100);
                this.Font = new Font("Arial", 9, FontStyle.Bold);
                this.ForeColor = Color.LimeGreen;
                this.Text = "REDIMENSIONEAZA-MA";

                lblTitlu = new Label();
                lblTitlu.Text = "Bilete:";
                lblTitlu.Top = 20;  
                lblTitlu.Left = DIMENSIUNE_PAS_X*3; 
                lblTitlu.Width = 200;
                lblTitlu.BackColor = Color.LightGreen;


                lblPunctStart = new Label();
                lblPunctStart.Text = "Punct Start:";
                lblPunctStart.Top = 50;  
                lblPunctStart.Left =DIMENSIUNE_PAS_X * 3;  
                lblPunctStart.BackColor = Color.LightBlue;

                txtStart = new TextBox();
                txtStart.Width = LATIME_CONTROL;
                txtStart.Left = DIMENSIUNE_PAS_X * 4;
                txtStart.Top = DIMENSIUNE_PAS_Y;
                this.Controls.Add(txtStart);

                lblDestinatie = new Label();
                lblDestinatie.Text = "Destinatie:";
                lblDestinatie.Top = 80;
                lblDestinatie.Left = DIMENSIUNE_PAS_X*3;
                lblDestinatie.BackColor = Color.LightBlue;

                txtDestinatie = new TextBox();
                txtDestinatie.Width = LATIME_CONTROL;
                txtDestinatie.Left = DIMENSIUNE_PAS_X * 4;
                txtDestinatie.Top = DIMENSIUNE_PAS_Y + 30;
                this.Controls.Add(txtDestinatie);

        

                lblOraStart = new Label();
                lblOraStart.Text = "Ora Start:";
                lblOraStart.Top = 110;
                lblOraStart.Left = DIMENSIUNE_PAS_X * 3;
                lblOraStart.BackColor = Color.LightBlue;

                txtOraStart = new TextBox();
                txtOraStart.Width = LATIME_CONTROL;
                txtOraStart.Left = DIMENSIUNE_PAS_X * 4;
                txtOraStart.Top = DIMENSIUNE_PAS_Y + 60;
                this.Controls.Add(txtOraStart);


                lblOraDestinatie = new Label();
                lblOraDestinatie.Text = "Ora Destinatie:";
                lblOraDestinatie.Top = 140;
                lblOraDestinatie.Left = DIMENSIUNE_PAS_X * 3;
                lblOraDestinatie.BackColor = Color.LightBlue;

                txtOraDestinatie = new TextBox();
                txtOraDestinatie.Width = LATIME_CONTROL;
                txtOraDestinatie.Left = DIMENSIUNE_PAS_X * 4;
                txtOraDestinatie.Top = DIMENSIUNE_PAS_Y + 90;
                this.Controls.Add(txtOraDestinatie);

                lblData = new Label();
                lblData.Text = "Data bilet:";
                lblData.Top = 170;
                lblData.Left = DIMENSIUNE_PAS_X * 3;
                lblData.BackColor = Color.LightBlue;

                txtData = new TextBox();
                txtData.Width = LATIME_CONTROL;
                txtData.Left = DIMENSIUNE_PAS_X * 4;
                txtData.Top = DIMENSIUNE_PAS_Y + 120;
                this.Controls.Add(txtData);

                this.Controls.Add(lblTitlu);
                this.Controls.Add(lblPunctStart);
                this.Controls.Add(lblDestinatie);
                this.Controls.Add(lblOraStart);
                this.Controls.Add(lblOraDestinatie);
                this.Controls.Add(lblData);

                addBilet = new Button();
                addBilet.Width = LATIME_CONTROL;
                addBilet.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X*3, 4 * DIMENSIUNE_PAS_Y);
                addBilet.Text = "Adauga bilet";

                addBilet.Click += OnButtonClicked;
                this.Controls.Add(addBilet);

                lblSalvare = new Label();
                lblSalvare.Width = LATIME_CONTROL * 2 + 100;
                lblSalvare.Height = 60;
                lblSalvare.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X * 3, 4 * DIMENSIUNE_PAS_Y + 30);
                lblSalvare.BackColor = Color.LightYellow;
                lblSalvare.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(lblSalvare);

               lblRefresh = new Label();
                lblRefresh.Width = LATIME_CONTROL*2;
                lblRefresh.Height = LUNGIME_CONTROL;
                lblRefresh.Left = DIMENSIUNE_PAS_X *3;
                lblRefresh.Top = DIMENSIUNE_PAS_Y * 6;
                lblRefresh.Text = "";
                lblRefresh.BackColor = Color.LightBlue;
                this.Controls.Add(lblRefresh); 

                btnRefresh = new Button();
                btnRefresh.Width = LATIME_CONTROL;
                btnRefresh.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X * 4, 4 * DIMENSIUNE_PAS_Y);
                btnRefresh.Text = "&Refresh";
                btnRefresh.Click += OnButton2Clicked;
                this.Controls.Add(btnRefresh);

                string numeFisier = ConfigurationManager.AppSettings["NumeFisierB"];


                 string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                
                string caleCompletaFisier = Path.Combine(locatieFisierSolutie, numeFisier);

              
                 adminParticipanti = new AdministrareBilete_FisierText(caleCompletaFisier);

                int nrParticipanti = 0;


                Bilet[] bilete = adminParticipanti.GetBilete(out nrParticipanti);

               
                if (nrParticipanti > 0)
                {
                    lblPunctStart.Text = bilete[0].punctStart;
                    lblDestinatie.Text = bilete[0].destinatie;
                    lblDestinatie.Text = bilete[0].oraStart;
                    lblPunctStart.Text = bilete[0].oraDest;

                }
              

                lblBilet = new Label();
                lblBilet.Width = LATIME_CONTROL * 2+100;
                lblBilet.Height = 60;
                lblBilet.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X *3, 4 * DIMENSIUNE_PAS_Y + 30);
                lblBilet.BackColor = Color.LightYellow;
                lblBilet.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(lblBilet);

                Afiseaza();
            }

            private void OnButton2Clicked(object sender, EventArgs e)
            {
                Afiseaza();
                lblRefresh.Text = "Bilete reincarcate";
            }
            private void OnButtonClicked(object sender, EventArgs e)
            {
                bool allGood = true;
                Bilet bilet = new Bilet(
                    txtStart.Text.ToString(),
                    txtDestinatie.Text.ToString(),
                    txtOraStart.Text.ToString(),
                    txtOraDestinatie.Text.ToString(),
                    txtData.Text.ToString()
                );

                if (txtStart.Text.ToString() == "" || txtStart.Text.ToString() == "!")
                {
                    txtStart.Text = "!";
                    txtStart.ForeColor = Color.Red;
                    allGood = false;
                }
                else if (txtStart.Text.Length > 15)
                {
                    txtStart.ForeColor = Color.Red;
                    allGood = false;
                }
                else
                {
                    txtStart.ForeColor = Color.Black;
                }

                if (txtDestinatie.Text.ToString() == "" || txtDestinatie.Text.ToString() == "!")
                {
                    txtDestinatie.Text = "!";
                    txtDestinatie.ForeColor = Color.Red;
                    allGood = false;
                }
                else if (txtDestinatie.Text.Length > 15)
                {
                    txtDestinatie.ForeColor = Color.Red;
                    allGood = false;
                }
                else
                {
                    txtDestinatie.ForeColor = Color.Black;
                }

                if (txtOraStart.Text.ToString() == "" || txtOraStart.Text.ToString() == "!")
                {
                    txtOraStart.Text = "!";
                    txtOraStart.ForeColor = Color.Red;
                    allGood = false;
                }
                else
                {
                    txtOraStart.ForeColor = Color.Black;
                }

                if (txtOraDestinatie.Text.ToString() == "" || txtOraDestinatie.Text.ToString() == "!")
                {
                    txtOraDestinatie.Text = "!";
                    txtOraDestinatie.ForeColor = Color.Red;
                    allGood = false;
                }
                else
                {
                    txtOraDestinatie.ForeColor = Color.Black;
                }

                if (txtData.Text.ToString() == "" || txtData.Text.ToString() == "!")
                {
                    txtData.Text = "!";
                    txtData.ForeColor = Color.Red;
                    allGood = false;
                }
                else
                {
                    txtData.ForeColor = Color.Black;
                }

                if (allGood)
                {
                    string numeFisier = ConfigurationManager.AppSettings["NumeFisierB"];

          
                    string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                    string caleCompletaFisier = Path.Combine(locatieFisierSolutie, numeFisier);

                    AdministrareBilete_FisierText adminBilete = new AdministrareBilete_FisierText(caleCompletaFisier);
                    adminBilete.AddBileteFisier(bilet);
                    lblSalvare.Text = "Bilet adaugat";
                    Afiseaza();
                }
                else
                {
                    lblSalvare.Text = "Informatii introduse incorect!!!";
                }

                
            }


            /* private void OnButtonClicked(object sender, EventArgs e)
             {

                 string ps = txtStart.Text;
                 string pd = txtDestinatie.Text;
                 string os = txtOraStart.Text;
                 string od = txtOraDestinatie.Text;
                 string data = txtData.Text;

                 Bilet d = new Bilet(ps, pd, os, od, data);

                 lblBilet.Text = "Date introduse :  " + d.Info().ToString();
                 string numeFisier = ConfigurationManager.AppSettings["NumeFisierB"];


                 string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                 string caleCompletaFisier = Path.Combine(locatieFisierSolutie, numeFisier);

                 AdministrareBilete_FisierText adminBilete = new AdministrareBilete_FisierText(caleCompletaFisier);
                 if (ps != string.Empty)
                     adminBilete.AddBileteFisier(d);
                 else
                     lblBilet.Text = "INTRODUCETI DATELE PENTRU BILET";
             }*/
            private void Afiseaza()
            {
                int nrBilete = 0;
                Bilet[] bilete = adminParticipanti.GetBilete(out nrBilete);

                lblTitlu2 = new Label();
                lblTitlu2.Width = LATIME_CONTROL;
                lblTitlu2.Height = LUNGIME_CONTROL;
                lblTitlu2.BackColor = Color.LightBlue;
                this.Controls.Add(lblTitlu2);

                lblTitlu = new Label();
                lblTitlu.Width = LATIME_CONTROL * 2;
                lblTitlu.Height = LUNGIME_CONTROL;
                lblTitlu.Left = DIMENSIUNE_PAS_X;
                lblTitlu.Text = "Bilete";
                lblTitlu.BackColor = Color.LightBlue;
                lblTitlu.ForeColor = Color.FromArgb(100, 83, 0, 92);
                this.Controls.Add(lblTitlu);

                lblPunctStart = new Label();
                lblPunctStart.Width = LATIME_CONTROL/2;
                lblPunctStart.Height = LUNGIME_CONTROL;
                lblPunctStart.Text = "Punct Start";
                lblPunctStart.Top = DIMENSIUNE_PAS_Y;
                lblPunctStart.BackColor = Color.LightGray;
                lblPunctStart.ForeColor = Color.FromArgb(100, 200, 0, 255);
                this.Controls.Add(lblPunctStart);

                lblDestinatie = new Label();
                lblDestinatie.Width = LATIME_CONTROL / 2;
                lblDestinatie.Height = LUNGIME_CONTROL;
                lblDestinatie.Text = "Destinatie";
                lblDestinatie.Left = DIMENSIUNE_PAS_X/2;
                lblDestinatie.Top = DIMENSIUNE_PAS_Y;
                lblDestinatie.BackColor = Color.LightGray;
                lblDestinatie.ForeColor = Color.FromArgb(100, 200, 0, 255);
                this.Controls.Add(lblDestinatie);

                lblOraStart = new Label();
                lblOraStart.Width = LATIME_CONTROL / 2;
                lblOraStart.Height = LUNGIME_CONTROL;
                lblOraStart.Text = "Ora plecare";
                lblOraStart.Left = DIMENSIUNE_PAS_X ;
                lblOraStart.Top = DIMENSIUNE_PAS_Y;
                lblOraStart.BackColor = Color.LightGray;
                lblOraStart.ForeColor = Color.FromArgb(100, 200, 0, 255);
                this.Controls.Add(lblOraStart);

                lblOraDestinatie = new Label();
                lblOraDestinatie.Width = LATIME_CONTROL / 2;
                lblOraDestinatie.Height = LUNGIME_CONTROL;
                lblOraDestinatie.Text = "Ora sosire";
                lblOraDestinatie.Left = DIMENSIUNE_PAS_X *2-85;
                lblOraDestinatie.Top = DIMENSIUNE_PAS_Y;
                lblOraDestinatie.BackColor = Color.LightGray;
                lblOraDestinatie.ForeColor = Color.FromArgb(100, 200, 0, 255);
                this.Controls.Add(lblOraDestinatie);

                lblData = new Label();
                lblData.Width = LATIME_CONTROL / 2;
                lblData.Height = LUNGIME_CONTROL;
                lblData.Text = "Data";
                lblData.Left = DIMENSIUNE_PAS_X * 2 ;
                lblData.Top = DIMENSIUNE_PAS_Y;
                lblData.BackColor = Color.LightGray;
                lblData.ForeColor = Color.FromArgb(100, 200, 0, 255);
                this.Controls.Add(lblData);

                for (int i = 0; i < nrBilete; i++)
                {
                    lblPunctStart = new Label();
                    lblPunctStart.Width = LATIME_CONTROL/2;
                    lblPunctStart.Height = LUNGIME_CONTROL;
                    lblPunctStart.Text = bilete[i].punctStart;
                    lblPunctStart.Top = DIMENSIUNE_PAS_Y * (i + 2);
                    lblPunctStart.BackColor = Color.LightGray;
                    lblPunctStart.ForeColor = Color.FromArgb(100, 255, 128, 255);
                    this.Controls.Add(lblPunctStart);

                    lblDestinatie = new Label();
                    lblDestinatie.Width = LATIME_CONTROL/2;
                    lblDestinatie.Height = LUNGIME_CONTROL;
                    lblDestinatie.Text = bilete[i].destinatie;
                    lblDestinatie.Left = DIMENSIUNE_PAS_X/2;
                    lblDestinatie.Top = DIMENSIUNE_PAS_Y * (i + 2);
                    lblDestinatie.BackColor = Color.LightGray;
                    lblDestinatie.ForeColor = Color.FromArgb(100, 255, 128, 255);
                    this.Controls.Add(lblDestinatie);

                    lblOraStart = new Label();
                    lblOraStart.Width = LATIME_CONTROL/2;
                    lblOraStart.Height = LUNGIME_CONTROL;
                    lblOraStart.Text = bilete[i].oraStart;
                    lblOraStart.Left = DIMENSIUNE_PAS_X ;
                    lblOraStart.Top = DIMENSIUNE_PAS_Y * (i + 2);
                    lblOraStart.BackColor = Color.LightGray;
                    lblOraStart.ForeColor = Color.FromArgb(100, 255, 128, 255);
                    this.Controls.Add(lblOraStart);

                    lblOraDestinatie = new Label();
                    lblOraDestinatie.Width = LATIME_CONTROL / 2;
                    lblOraDestinatie.Height = LUNGIME_CONTROL;
                    lblOraDestinatie.Text = bilete[i].oraDest;
                    lblOraDestinatie.Left = DIMENSIUNE_PAS_X * 2 - 85;
                    lblOraDestinatie.Top = DIMENSIUNE_PAS_Y * (i + 2);
                    lblOraDestinatie.BackColor = Color.LightGray;
                    lblOraDestinatie.ForeColor = Color.FromArgb(100, 255, 128, 255);
                    this.Controls.Add(lblOraDestinatie);

                    lblData = new Label();
                    lblData.Width = LATIME_CONTROL / 2;
                    lblData.Height = LUNGIME_CONTROL;
                    lblData.Text = bilete[i].data;
                    lblData.Left = DIMENSIUNE_PAS_X * 2;
                    lblData.Top = DIMENSIUNE_PAS_Y * (i + 2);
                    lblData.BackColor = Color.LightGray;
                    lblData.ForeColor = Color.FromArgb(100, 255, 128, 255);
                    this.Controls.Add(lblData);
                }
            }
        }
    }
}
