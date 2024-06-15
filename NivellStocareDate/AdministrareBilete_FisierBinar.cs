using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Librarie_Modele;
using System.Threading.Tasks;
using System.IO;

namespace NivellStocareDate
{
    public class AdministrareBilete_FisierBinar : IStocareDataBilet
    {
        private const int ID_PRIMUL_BILET = 1;
        private const int INCREMENT = 1;
        string NumeFisierB { get; set; }

        public AdministrareBilete_FisierBinar(string numeFisier)
        {
            NumeFisierB = numeFisier;
            Stream sBinFile = File.Open(NumeFisierB, FileMode.OpenOrCreate);
            sBinFile.Close();
        }

        public void AddBilet(Bilet bilet)
        {
            try
            {
                BinaryFormatter b = new BinaryFormatter();
                using (Stream sBinFile = File.Open(NumeFisierB, FileMode.Append, FileAccess.Write))
                {
                    b.Serialize(sBinFile, bilet);
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public List<Bilet> GetBilete()
        {
            List<Bilet> bilete = new List<Bilet>();
            try
            {
                BinaryFormatter b = new BinaryFormatter();
                using (Stream sBinFile = File.Open(NumeFisierB, FileMode.Open))
                {
                    while (sBinFile.Position < sBinFile.Length)
                    {
                        bilete.Add((Bilet)b.Deserialize(sBinFile));
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return bilete;
        }
        public List<Bilet> GetBiletPunctStart(string punctStart)
        {
            List<Bilet> bilete = new List<Bilet>();

            using (FileStream fileStream = new FileStream(NumeFisierB, FileMode.Open))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);

                while (fileStream.Position < fileStream.Length)
                {
                    // Citirea unui obiect Bilet din fișierul binar
                    Bilet bilet = new Bilet();
                    bilet.punctStart = binaryReader.ReadString();
                    // Alte proprietăți ale obiectului Bilet ar trebui citite în funcție de structura fișierului binar

                    // Verificarea punctului de start și adăugarea în listă, dacă se potrivește
                    if (bilet.punctStart.Equals(punctStart))
                    {
                        bilete.Add(bilet);
                    }
                }

                binaryReader.Close();
            }

            return bilete;
        }

    }
}
