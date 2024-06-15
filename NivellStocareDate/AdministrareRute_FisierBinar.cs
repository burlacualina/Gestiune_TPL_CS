using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Librarie_Modele;
using System.Threading.Tasks;
using System.IO;

namespace NivellStocareDate
{
    public class AdministrareRute_FisierBinar : IStocareDataRuta
    {
        private const int ID_PRIMUL_RUTA = 1;
        private const int INCREMENT = 1;
        string NumeFisier { get; set; }

        public AdministrareRute_FisierBinar(string numeFisier)
        {
            NumeFisier = numeFisier;
            Stream sBinFile = File.Open(NumeFisier, FileMode.OpenOrCreate);
            sBinFile.Close();
        }

        public void AddRutaFisier(Ruta ruta)
        {
            try
            {
                BinaryFormatter b = new BinaryFormatter();
                using (Stream sBinFile = File.Open(NumeFisier, FileMode.Append, FileAccess.Write))
                {
                    b.Serialize(sBinFile, ruta);
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

        public List<Ruta> GetRutaFisier()
        {
            List<Ruta> rute = new List<Ruta>();
            try
            {
                BinaryFormatter b = new BinaryFormatter();
                using (Stream sBinFile = File.Open(NumeFisier, FileMode.Open))
                {
                    while (sBinFile.Position < sBinFile.Length)
                    {
                        rute.Add((Ruta)b.Deserialize(sBinFile));
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
            return rute;
        }
    }
}
