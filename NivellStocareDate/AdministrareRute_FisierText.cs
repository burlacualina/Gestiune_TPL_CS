using Librarie_Modele;
using System;
using System.IO;

namespace NivellStocareDate
{
    public class AdministrareRute_FisierText
    {
        private const int NR_MAX_RUTE = 50;
        private string numeFisier;

        public AdministrareRute_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddRutaFisier(Ruta rute)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(rute.ConversieLaSir_PentruFisier());
            }
        }

        public Ruta[] GetRutaFisier(out int nrRute)
        {
            Ruta[] rute = new Ruta[NR_MAX_RUTE];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrRute = 0;

                // citeste cate o linie si creaza un obiect de tip Ruta
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    rute[nrRute++] = new Ruta(linieFisier);
                }
            }

            return rute;
        }
    }
}
