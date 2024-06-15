using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class MainIcon : Form
    {
        public MainIcon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                // La apăsarea butonului "Bilet", deschide formularul BiletAdmin
                BiletAdmin biletAdminForm = new BiletAdmin();
                biletAdminForm.Show();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RutaAdmin rutaAdmin=new RutaAdmin(); ;
            rutaAdmin.Show();
        }
    }
}
