using System;
using System.Collections.Generic;
using System.Linq;
using Librarie_Modele;
using NivellStocareDate;
using System.Configuration;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Proiect_TPL
{
    class Program
    {
        static void Main()
        {
            Ruta ruta = new Ruta();
            int nrRute1 = 0;
            Admin_Rute adminRute = new Admin_Rute();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdministrareRute_FisierText adminrute = new AdministrareRute_FisierText(numeFisier);
            string optiune;

            Bilet bilet = new Bilet();
            int nrBilet1 = 0;
            Admin_Bilet adminBilet = new Admin_Bilet();
            string numeFisierB = ConfigurationManager.AppSettings["NumeFisierB"];
            AdministrareBilete_FisierText adminBilete = new AdministrareBilete_FisierText(numeFisierB);

            do
            {

                Console.WriteLine("\nR-Rute -- B-Bilet");
                Console.WriteLine("Introduceti optiunea: ");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "R":

                        string optiuneR;
                        do
                        {

                            Console.WriteLine("C. Citire informatii rute de la tastatura");
                            Console.WriteLine("I. Afisarea informatiilor citite de la consola");
                            Console.WriteLine("A. Afisare rute din fisier");
                            Console.WriteLine("S. Salvare ruta in vector de obiecte");
                            Console.WriteLine("SF.Salvare date in fisier ");
                            Console.WriteLine("N. Cautare dupa destinatie");
                            Console.WriteLine("B:Cutare dupa punct start");
                            Console.WriteLine("Alegeti o optiune pentru ruta:");
                            optiuneR = Console.ReadLine();
                            switch (optiuneR.ToUpper())
                            {
                                case "C":
                                    
                                    ruta = Citire_Ruta();
                                    break;
                                case "I":
                                    Ruta[] ruteeee = adminRute.GetRute(out nrRute1);
                                    AfisareRute(ruteeee,nrRute1);
                                    break;
                                case "A":
                                    Ruta[] rutee = adminrute.GetRutaFisier(out nrRute1);
                                    AfisareRute(rutee, nrRute1);
                                    break;
                                case "S":
                                    adminRute.AddRuta(ruta);
                                    nrRute1++;
                                    break;
                                case "SF":
                                    adminrute.AddRutaFisier(ruta);
                                    break;
                                case "B":
                                    Ruta[] rute1 = adminrute.GetRutaFisier(out nrRute1);
                                    CautareDupaStartR(rute1, nrRute1);
                                    break;
                                case "N":
                                    Ruta[] rute2 = adminrute.GetRutaFisier(out nrRute1);
                                    CautareDupaDestinatieR(rute2, nrRute1);
                                    break;
                            }
                        } while (optiuneR.ToUpper() != "X");
                        if (optiuneR.ToUpper() != "X")
                        {
                            Console.WriteLine("Introduceti optiunea: ");
                            Console.ReadKey();
                        }
                        break;
                    case "B":
                        string optiuneB;
                        do
                        {
                            Console.WriteLine("C. Citire informatii bilet de la tastatura");
                            Console.WriteLine("I. Afisarea informatiilor introduse de la consola");
                            Console.WriteLine("A. Afisare bilete din fisier");
                            Console.WriteLine("S. Salvare bilet in vector de obiecte");
                            Console.WriteLine("SF.Salvare date in fisier ");
                            Console.WriteLine("N. Cautare dupa destinatie");
                            Console.WriteLine("B:Cutare dupa punct start");
                            Console.WriteLine("Introduceti optiunea la bilet: ");
                            optiuneB = Console.ReadLine();
                            switch (optiuneB.ToUpper())
                            {

                                case "C":
                                    bilet = Citire_Bilet();
                                    break;
                                case "I":
                                    Bilet[] bilete = adminBilet.GetBilet(out nrBilet1);
                                    Afisare_Bilet(bilete);
                                    break;
                                case "A":
                                    Bilet[] biletee = adminBilete.GetBilete(out nrBilet1);
                                    AfisareBilete(biletee, nrBilet1);
                                    break;
                                case "S":
                                    adminBilet.AddBilet(bilet);
                                    nrRute1++;
                                    break;
                                case "SF":
                                    adminBilete.AddBileteFisier(bilet);
                                    break;
                                case "B":
                                    Bilet[] bilet1 = adminBilete.GetBilete(out nrBilet1);
                                    CautareDupaStart(bilet1, nrBilet1);
                                    break;
                                case "N":
                                    Bilet[] bilet2 = adminBilete.GetBilete(out nrBilet1);
                                    CautareDupaDestinatie(bilet2, nrBilet1);
                                    break;
                            }

                        } while (optiuneB.ToUpper() != "X");
                        if (optiuneB.ToUpper() != "X")
                        {
                            Console.WriteLine("Introduceti optiunea: ");
                            Console.ReadKey();
                        }
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiunea nu exista!");
                        break;

                }
            } while (optiune.ToUpper() != "X");
            Console.WriteLine("Introduecti optinunea: ");
            Console.ReadKey();
        }


        public static Bilet Citire_Bilet()
        {
            Console.WriteLine("INTRODUCETI DATELE: ");
            Console.WriteLine("punctStart, destinatie,oraStart, oraDest");
            string _punctStart = Console.ReadLine();
            string _destinatie = Console.ReadLine();
            string _oraStart = Console.ReadLine();
            string _oraDest = Console.ReadLine();
            string _data = Console.ReadLine();

            Console.WriteLine("Finalizare citire");

            Bilet bilete = new Bilet(_punctStart, _destinatie, _oraStart, _oraDest,_data);
            return bilete;

        }

        public static void Afisare_Bilet(Bilet[] bilete)
        {
            Console.WriteLine("Biletele introduse sunt:");
            foreach (Bilet bilet in bilete)
            {
                Console.WriteLine($"Punct start: {bilet.punctStart}, Destinatie: {bilet.destinatie}, Ora start: {bilet.oraStart}, Ora destinatie: {bilet.oraDest}, Data: {bilet.data}");
            }
        }

        public static Ruta Citire_Ruta()
        {
            Console.WriteLine("INTRODUCETI DATELE: ");
            Console.WriteLine("punctStart, destinatie,oraStart, oraDest");
            string _punctStart = Console.ReadLine();
            string _destinatie = Console.ReadLine();
            string _oraStart = Console.ReadLine();
            string _oraDest = Console.ReadLine();
            Console.WriteLine("Finalizare citire");

            Ruta rute = new Ruta(_punctStart, _destinatie, _oraStart, _oraDest);
            return rute;

        }
        public static void Afisare_Ruta(Ruta ruta)
        {
            string infoRuta = string.Format("Ruta care are punct start {0} si punct de final {1} , incepe la ora {2} si se incheie la ora {3}",
                ruta.punctStart ?? "NECUNOSCUT",
                ruta.destinatie ?? "NECUNOSCUT",
                ruta.oraStart ?? "NECUNOSCUT",
                ruta.oraDest ?? "NECUNOSCUT");
            Console.WriteLine(infoRuta);
        }
        public static void CautareDupaStartR(Ruta[] rute, int nrRute)
        { int ok = 0;
            Console.WriteLine("\nIntroduceti punctul de start : ");
            string Start = Console.ReadLine();
            for (int contor = 0; contor < nrRute; contor++)
            {
                if (Start == rute[contor].punctStart)
                {
                    Console.WriteLine($"Ruta {rute[contor].punctStart} - {rute[contor].destinatie} a fost gasita");
                    ok = 1;
                }
            }
            if(ok==0)
            Console.WriteLine($"Punctul de start cu denumirea {Start} nu a fost gasit!!");
        }
        public static void CautareDupaStart(Bilet[] bilete, int nrBilete)
        { int ok = 0;
            Console.WriteLine("\nIntroduceti punctul de start : ");
            string Start = Console.ReadLine();
            for (int contor = 0; contor < nrBilete; contor++)
            {
                if (Start == bilete[contor].punctStart)
                {
                    Console.WriteLine($"Ruta {bilete[contor].punctStart} - {bilete[contor].destinatie} a fost gasita");
                    ok = 1;
                }
            }
            if (ok==0)  
            Console.WriteLine($"Punctul de start cu denumirea {Start} nu a fost gasit!!");

            
        }
        public static void CautareDupaDestinatieR(Ruta[] rute, int nrRute)
        {
            Console.WriteLine("\nIntroduceti desttinatia: ");
            string Destinatie = Console.ReadLine();
            int ok = 0;
            for (int contor = 0; contor < nrRute; contor++)
            {
                if (Destinatie == rute[contor].destinatie)
                {
                    Console.WriteLine($"Ruta {rute[contor].punctStart} - {rute[contor].destinatie} a fost gasita");
                    ok = 1;
                }
            }
            if (ok==0)
                    Console.WriteLine($"Destinatia  cu denumirea {Destinatie} nu a fost gasita!!");

            
        }

        //de mutat in administrare 
        public static void CautareDupaDestinatie(Bilet[] bilete, int nrBilete)
        {
            int ok = 0;
            Console.WriteLine("\nIntroduceti desttinatia: ");
            string Destinatie = Console.ReadLine();
            for (int contor = 0; contor < nrBilete; contor++)
            {
                if (Destinatie == bilete[contor].destinatie)
                {
                    Console.WriteLine($"Ruta {bilete[contor].punctStart} - {bilete[contor].destinatie} a fost gasita");
                    ok = 1;
                }
            }
            if (ok == 0)
                Console.WriteLine($"Destinatia  cu denumirea {Destinatie} nu a fost gasit!!");


        }
        public static void AfisareRute(Ruta[] rute, int nrRute)
        {
            Console.WriteLine("Rutele  sunt:");
            for (int contor = 0; contor < nrRute; contor++)
            {
                string infoRute = rute[contor].Info();
                Console.WriteLine(infoRute);
            }
        }
        public static void AfisareBilete(Bilet[] bilete, int nrBilete)
        {
            Console.WriteLine("Bilete  sunt:");
            for (int contor = 0; contor < nrBilete; contor++)
            {
                string infoBilet = bilete[contor].Info();
                Console.WriteLine(infoBilet);
            }
        }

    }
}