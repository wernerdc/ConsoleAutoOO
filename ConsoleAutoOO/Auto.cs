using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAutoOO {
    
    internal class Auto {

        public string Hersteller;
        public string Bezeichnung;
        public int Hubraum;
        public double PS;


        public Auto(string hersteller, string bezeichnung, int hubraum, double ps) {
            Hersteller = hersteller;
            Bezeichnung = bezeichnung;
            Hubraum = hubraum;
            PS = ps;
        }

        public Auto() : this("Unbekannt", "Unbekannt", 0, 0) { 
        
        }

        public double KW() {
            return PS * 0.74;
        }

        public override string ToString() {
            string str = "Hersteller: " + Hersteller +
                         "\nBezeichnung: " + Bezeichnung +
                         "\nHubraum: " + Hubraum +
                         "\nPS: " + PS;
            return str;
        }
    }
}
