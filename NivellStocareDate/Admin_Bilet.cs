using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarie_Modele;
namespace NivellStocareDate
{
    public class Admin_Bilet
    {

        private const int NR_MAX_BILETE = 50;
        private Bilet[] bilete;
        private int nrBilete;

        public Admin_Bilet()
        {
            bilete = new Bilet[NR_MAX_BILETE];
            nrBilete = 0;
        }

        public void AddBilet(Bilet Bilete)
        {
            bilete[nrBilete] = Bilete;
            nrBilete++;
        }

        public Bilet[] GetBilet(out int nrBilete)
        {
            nrBilete = this.nrBilete;
            return bilete;
        }

    }
}
