using Librarie_Modele;
using System;
using System.Collections.Generic;
using System.IO;

namespace NivellStocareDate
{
    public class AdministrareBilete_FisierText:IStocareDataBilet
    {
        private const int NR_MAX_BILETE = 50;
        private string numeFisierB;

        public AdministrareBilete_FisierText(string numeFisierB)
        {
            this.numeFisierB = numeFisierB;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisierB, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddBilet(Bilet bilete)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierB, true))
            {
                streamWriterFisierText.WriteLine(bilete.ConversieLaSir_PentruFisier());
            }
        }

        public List<Bilet> GetBilete()
        {
            List<Bilet> bilete = new List<Bilet>();

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisierB))
            {
                string linieFisier;

                // citeste cate o linie si creaza un obiect de tip Bilet
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    // Adaugă un mesaj de debug pentru a vedea fiecare linie citită
                    Console.WriteLine($"Linie citită din fișier: {linieFisier}");

                    try
                    {
                        bilete.Add(new Bilet(linieFisier));
                    }
                    catch (Exception ex)
                    {
                        // Adaugă un mesaj de debug pentru a vedea dacă apare vreo eroare la conversie
                        Console.WriteLine($"Eroare la conversia liniei: {ex.Message}");
                    }
                }
            }

            // Adaugă un mesaj de debug pentru a vedea numărul de bilete citite
            Console.WriteLine($"Număr de bilete citite: {bilete.Count}");

            return bilete;
        }
        public List<Bilet> GetBiletPunctStart(string punctStart)
{
    List<Bilet> bilete = new List<Bilet>();
    using (StreamReader streamReader = new StreamReader(numeFisierB))
    {
        string linieFisier;
        while ((linieFisier = streamReader.ReadLine()) != null)
        {
            Bilet bilet = new Bilet(linieFisier);
            if (bilet.punctStart==punctStart)
            {
                bilete.Add(bilet);
            }
        }
    }
    return bilete;
}

    }
}
