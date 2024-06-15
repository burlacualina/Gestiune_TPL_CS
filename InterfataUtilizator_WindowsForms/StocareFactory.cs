using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

using NivellStocareDate;
namespace InterfataUtilizator_WindowsForms
{
    public static class StocareFactory
    {
        private const string FORMAT_SALVARE = "FormatSalvare";
        private const string NUME_FISIER = "NumeFisierB";
        private const string NUME_FISIERR = "NumeFisierR";
        public static IStocareDataBilet GetStocareData()
        {
            string formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            string numeFisier = ConfigurationManager.AppSettings[NUME_FISIER];
            string locatieFisierSolutie=Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            if(formatSalvare !=null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "bin":
                        return new AdministrareBilete_FisierBinar(caleCompletaFisier + "." + formatSalvare);
                    case "txt":
                        return new AdministrareBilete_FisierText(caleCompletaFisier+ "."+formatSalvare);
                }
            }
            return null;
        }

        public static IStocareDataRuta GetStocareDataRute()
        {
            string formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            string numeFisier = ConfigurationManager.AppSettings[NUME_FISIERR];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "bin":
                        return new AdministrareRute_FisierBinar(caleCompletaFisier + "." + formatSalvare);
                    case "txt":
                        return new AdministrareRute_FisierText(caleCompletaFisier + "." + formatSalvare);  
                }
            }
            return null;
        }
    }
}
