using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Librarie_Modele
{
    public class Bilet
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int PUNCTSTART = 0;
        private const int DESTINATIE = 1;
        private const int ORASTART = 2;
        private const int ORADEST = 3;
        private const int DATA = 4;
        public string punctStart { get; set; }
        public string destinatie { get; set; }
        public string oraStart { get; set; }
        public string oraDest { get; set; }
        public string data { get; set; }

        public Bilet()
        {
            punctStart = string.Empty;
            destinatie = string.Empty;
            oraStart = string.Empty;
            oraDest = string.Empty;
            data = string.Empty;
        }
        public Bilet(string _punctStart, string _destinatie, string _oraStart, string _oraDest, string _data)
        {
            punctStart = _punctStart; ;
            destinatie = _destinatie;
            oraDest = _oraDest;
            oraStart = _oraStart;
            data = _data;
        }
        public Bilet(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.punctStart = dateFisier[PUNCTSTART];
            this.destinatie = dateFisier[DESTINATIE];
            this.oraStart = dateFisier[ORASTART];
            this.oraDest = dateFisier[ORADEST];
            this.data = dateFisier[DATA];   
        }
        public string Info()
        {
            if (punctStart != string.Empty)
            {
                return $"Punct Start: {punctStart} \nDestinatie: {destinatie} \nOra inceput: {oraStart} \nOra Destinatie : {oraDest} \nData: {data}";

            }
            else
                return $"Nu exist ruta";
        }

        public static Bilet[] CautareDupaPunctStart(Bilet[] bilete, string punctStartCautat)
        {
            int count = 0;

            foreach (Bilet bilet in bilete)
            {
                if (bilet.punctStart.Equals(punctStartCautat, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }

            Bilet[] bileteGasite = new Bilet[count];
            int index = 0;

            foreach (Bilet bilet in bilete)
            {
                if (bilet.punctStart.Equals(punctStartCautat, StringComparison.OrdinalIgnoreCase))
                {
                    bileteGasite[index] = bilet;
                    index++;
                }
            }
            return bileteGasite;
        }
        public static Bilet[] CautareDupaDestinatie(Bilet[] bilete, string destinatie)
        {
            int count = 0;

            foreach (Bilet bilet in bilete)
            {
                if (bilet.punctStart.Equals(destinatie, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }
            Bilet[] bileteGasite = new Bilet[count];
            int index = 0;

            foreach (Bilet bilet in bilete)
            {
                if (bilet.punctStart.Equals(destinatie, StringComparison.OrdinalIgnoreCase))
                {
                    bileteGasite[index] = bilet;
                    index++;
                }
            }
            return bileteGasite;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (punctStart ?? " NECUNOSCUT "),
                (destinatie ?? " NECUNOSCUT "),
                (oraStart ?? "NECUNOSCUT"), (oraDest ?? "NECUNOSCUT"), (data??"NECUNISCUT"));

            return obiectStudentPentruFisier;
        }
    }
}




