using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarie_Modele;
namespace NivellStocareDate
{
    public class Admin_Rute
    {

        private const int NR_MAX_RUTE = 50;
        private Ruta[] rute;
        private int nrRute;

        public Admin_Rute()
        {
            rute = new Ruta[NR_MAX_RUTE];
            nrRute = 0;
        }

        public void AddRuta(Ruta rutee)
        { 
            rute[nrRute] = rutee;
            nrRute++;
        }

        public Ruta[] GetRute(out int nrRute)
        {
            nrRute = this.nrRute;
            return rute;
        }
    }
}
