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
using static InterfataUtilizator_WindowsForms.Form1;
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
   
    }
