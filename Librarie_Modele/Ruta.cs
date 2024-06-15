using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarie_Modele
{
    public class Ruta
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int PUNCTSTART = 0;
        private const int DESTINATIE = 1;
        private const int ORASTART = 2;
        private const int ORADEST = 3;
       
        public string punctStart { get; set; }
        public string destinatie { get; set; }
        public string oraStart { get; set; }
        public string oraDest { get; set; }
        public Ruta()
        {
            punctStart = string.Empty;
            destinatie = string.Empty;
            oraStart = string.Empty;
            oraDest = string.Empty;
        }
        public Ruta(string _punctStart, string _destinatie, string _oraStart, string _oraDest)
        {
            punctStart = _punctStart; ;
            destinatie = _destinatie;
            oraStart = _oraStart;
            oraDest = _oraDest;
        }

        public Ruta(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.punctStart = dateFisier[PUNCTSTART];
            this.destinatie = dateFisier[DESTINATIE];
            this.oraStart = dateFisier[ORASTART];
            this.oraDest = dateFisier[ORADEST];
        }

        public string Info()
        {
            if (punctStart != string.Empty)
            {
                return $"Punct Start: {punctStart} \nDestinatie: {destinatie} \nOra inceput: {oraStart} \nOra Destinatie : {oraDest}";
            }
            else
                return $"Nu exist ruta";
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (punctStart ?? " NECUNOSCUT "),
                (destinatie ?? " NECUNOSCUT "),
                (oraStart ?? "NECUNOSCUT"), (oraDest ?? "NECUNOSCUT"));

            return obiectStudentPentruFisier;
        }
    }
}