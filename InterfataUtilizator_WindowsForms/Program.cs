using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Librarie_Modele;
using NivellStocareDate; 

namespace InterfataUtilizator_WindowsForms
{
     static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forma1());
        }
    }
    public  class Forma1 : Form
    {
        // Declararea controalelor de tip Label
        private Label lblTitlu;
        private Label lblPunctStart;
        private Label lblDestinatie; 
        private Label lblOraStart; 
        private Label lblOraDestinatie;
        private Label lblData;
        private Label lblBilet;

        private TextBox txtStart;
        private TextBox txtDestinatie;
        private TextBox txtOraStart;
        private TextBox txtOraDestinatie;
        private TextBox txtData;
        
        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 50;
        private const int DIMENSIUNE_PAS_X = 170;

        private Button addBilet;
        public Forma1()
        {

            // Crearea și configurarea primului Label pentru titlu
             //setare proprietati
            this.Size = new System.Drawing.Size(500, 400);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "REDIMENSIONEAZA-MA";

            lblTitlu = new Label();
            lblTitlu.Text = "Bilete:";
            lblTitlu.Top = 20;  // Setarea poziției verticale a Label-ului
            lblTitlu.Left = 50; // Setarea poziției orizontale a Label-ulu 
            lblTitlu.Width = 200;
            lblTitlu.BackColor = Color.LightGreen;
           
            // Crearea și configurarea celui de-al doilea Label pentru nume

            lblPunctStart = new Label();
            lblPunctStart.Text = "Punct Start:";
            lblPunctStart.Top = 50;   // Setarea poziției verticale a Label-ului
            lblPunctStart.Left = 20;  // Setarea poziției orizontale a Label-ului
            lblPunctStart.BackColor = Color.LightBlue;
            
            txtStart = new TextBox();
            txtStart.Width = LATIME_CONTROL;
            txtStart.Left=DIMENSIUNE_PAS_X;
            txtStart.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtStart);

            lblDestinatie = new Label();
            lblDestinatie.Text = "Punct Destinatie:";
            lblDestinatie.Top = 80;
            lblDestinatie.Left = 20;
            lblDestinatie.BackColor = Color.LightBlue;

            txtDestinatie = new TextBox();
            txtDestinatie.Width = LATIME_CONTROL;
            txtDestinatie.Left = DIMENSIUNE_PAS_X;
            txtDestinatie.Top = DIMENSIUNE_PAS_Y+30;
            this.Controls.Add(txtDestinatie);

            //Crearea si configurarea etichetei pentru note

            lblOraStart = new Label();
            lblOraStart.Text = "Ora Start:";
            lblOraStart.Top = 110;
            lblOraStart.Left = 20;
            lblOraStart.BackColor = Color.LightBlue;

            txtOraStart = new TextBox();
            txtOraStart.Width = LATIME_CONTROL;
            txtOraStart.Left = DIMENSIUNE_PAS_X;
            txtOraStart.Top = DIMENSIUNE_PAS_Y + 60;
            this.Controls.Add(txtOraStart);


            lblOraDestinatie = new Label();
            lblOraDestinatie.Text = "Ora Destinatie:";
            lblOraDestinatie.Top = 140;
            lblOraDestinatie.Left = 20;
            lblOraDestinatie .BackColor = Color.LightBlue;

            txtOraDestinatie = new TextBox();
            txtOraDestinatie.Width = LATIME_CONTROL;
            txtOraDestinatie.Left = DIMENSIUNE_PAS_X;
            txtOraDestinatie.Top = DIMENSIUNE_PAS_Y + 90;
            this.Controls.Add(txtOraDestinatie);

            lblData = new Label();
            lblData.Text = "Data bilet:";
            lblData.Top = 170;
            lblData.Left = 20;
            lblData.BackColor = Color.LightBlue;

            txtData = new TextBox();
            txtData.Width = LATIME_CONTROL;
            txtData.Left = DIMENSIUNE_PAS_X;
            txtData.Top = DIMENSIUNE_PAS_Y + 120;
            this.Controls.Add(txtData);


            // Adăugarea controalelor de tip Label la formă
            this.Controls.Add(lblTitlu);
            this.Controls.Add(lblPunctStart);
            this.Controls.Add(lblDestinatie);
            this.Controls.Add(lblOraStart);
            this.Controls.Add(lblOraDestinatie);
            this.Controls.Add(lblData);

            addBilet=new Button();
            addBilet.Width= LATIME_CONTROL;
            addBilet.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 4 * DIMENSIUNE_PAS_Y);
            addBilet.Text = "Adauga bilet";

            addBilet.Click += OnButtonClicked;
            this.Controls.Add(addBilet);



            // Accesarea numelui fișierului din configurație
            string numeFisier = ConfigurationManager.AppSettings["NumeFisierB"];

            // Obținerea căii absolute a fișierului
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = Path.Combine(locatieFisierSolutie, numeFisier);

            // Inițializarea administratorului de studenți cu fișierul corespunzător
            AdministrareBilete_FisierText adminParticipanti = new AdministrareBilete_FisierText(caleCompletaFisier);

            // Obținerea listei de studenți
            int nrParticipanti = 0;
            Bilet[] bilete= adminParticipanti.GetBilete(out nrParticipanti);

            // Setarea proprietății Text a etichetei lblPunctStart la numele primului student
            if (nrParticipanti > 0)
            {
                lblPunctStart.Text = bilete[0].punctStart;
                lblDestinatie.Text = bilete[0].destinatie;
                lblDestinatie.Text = bilete[0].oraStart;
                lblPunctStart.Text = bilete[0].oraDest;

            }
            lblBilet = new Label();
            lblBilet.Width = LATIME_CONTROL * 2;
            lblBilet.Height = 50;
            lblBilet.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X / 2, 4 * DIMENSIUNE_PAS_Y+30);
            lblBilet.BackColor = Color.LightYellow;
            lblBilet.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblBilet);


        }
        private void OnButtonClicked(object sender, EventArgs e)
        {
            // obiectul *sender* este butonul btnCalculeaza
            // *e* reprezinta o lista de valori care se transmit la invocarea evenimentului Click al clasei Button
            // catre subscriber-ul curent care este forma FormularGeometrie 
            string ps = txtStart.Text;
            string pd = txtDestinatie.Text;
            string os = txtOraStart.Text;
            string od=txtOraDestinatie.Text;
            string data=txtData.Text;

            Bilet d = new Bilet(ps,pd,os,od,data);

            lblBilet.Text = "Studentul introdus este:  " + d.Info().ToString();

            AdministrareBilete_FisierText adminBilete = new AdministrareBilete_FisierText("Studenti.txt");
            adminBilete.AddBileteFisier(d);
        }
    }
    }
