using Librarie_Modele;
using System;
using System.IO;

namespace NivellStocareDate
{
    public class AdministrareBilete_FisierText
    {
        private const int NR_MAX_BILETE = 50;
        private string numeFisier;

        public AdministrareBilete_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddBileteFisier(Bilet bilete)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(bilete.ConversieLaSir_PentruFisier());
            }
        }

        public Bilet[] GetBilete(out int nrBilete)
        {
            Bilet[] bilete = new Bilet[NR_MAX_BILETE];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrBilete = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    bilete[nrBilete++] = new Bilet(linieFisier);
                }
            }

            return bilete;
        }
    }
}
