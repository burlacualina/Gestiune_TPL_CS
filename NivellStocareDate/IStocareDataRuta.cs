using Librarie_Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivellStocareDate
{
    public interface IStocareDataRuta
    {
        void AddRutaFisier(Ruta ruta);
        List<Ruta> GetRutaFisier();

        //bool UpdateBilet(Ruta b);
    }
}
