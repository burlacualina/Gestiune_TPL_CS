using Librarie_Modele;
using System;
using System.Collections.Generic;
using System.IO;

namespace NivellStocareDate
{
    public class AdministrareRute_FisierText :IStocareDataRuta
    {
        private string numeFisier;

        public AdministrareRute_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddRutaFisier(Ruta ruta)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(ruta.ConversieLaSir_PentruFisier());
            }
        }

        public List<Ruta> GetRutaFisier()
        {
            List<Ruta> rute = new List<Ruta>();

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                // citeste cate o linie si creaza un obiect de tip Ruta
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    // Adaugă un mesaj de debug pentru a vedea fiecare linie citită
                    Console.WriteLine($"Linie citită din fișier: {linieFisier}");

                    try
                    {
                        rute.Add(new Ruta(linieFisier));
                    }
                    catch (Exception ex)
                    {
                        // Adaugă un mesaj de debug pentru a vedea dacă apare vreo eroare la conversie
                        Console.WriteLine($"Eroare la conversia liniei: {ex.Message}");
                    }
                }
            }

            // Adaugă un mesaj de debug pentru a vedea numărul de rute citite
            Console.WriteLine($"Număr de rute citite: {rute.Count}");

            return rute;
        }
    }
}
