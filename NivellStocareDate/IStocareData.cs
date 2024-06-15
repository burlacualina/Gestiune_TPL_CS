using Librarie_Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivellStocareDate
{
   public interface IStocareDataBilet
    {
        void AddBilet(Bilet bilete);
        List<Bilet> GetBilete();
        List<Bilet> GetBiletPunctStart(string punctStart);
        //bool UpdateBilet(Biletb);
    }
}
