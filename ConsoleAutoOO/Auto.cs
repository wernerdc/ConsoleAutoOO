﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAutoOO {
    
    internal class Auto {

        private string _hersteller;
        private string _bezeichnung;
        private int _hubraum;
        private int _ps;
        private int _maxSpeed;
        private int _maxDrehmoment;

        public Auto(string hersteller, string bezeichnung, int hubraum, int ps, int maxSpeed, int maxDrehmoment) {
            _hersteller = hersteller;
            _bezeichnung = bezeichnung;
            _hubraum = hubraum;
            _ps = ps;
            _maxSpeed = maxSpeed;
            _maxDrehmoment = maxDrehmoment;
        }

        public Auto() : this("Unbekannt", "Unbekannt", 0, 0, 0, 0) { 
        
        }

        public double KW() {
            return _ps * 0.74;
        }

        public override string ToString() {
            string str = "Hersteller: " + _hersteller +
                         "\nBezeichnung: " + _bezeichnung +
                         "\nHubraum: " + _hubraum +
                         "\nPS: " + _ps +
                         "\nHöchstgeschwindigkeit: " + _maxSpeed +
                         "\nDrehmoment: " + _maxDrehmoment;
            return str;
        }

        public string Hersteller {
            get => _hersteller;
            set => _hersteller = value;
        }

        public string Bezeichnung {
            get => _bezeichnung;
            set => _bezeichnung = value;
        }

        public int Hubraum {
            get => _hubraum; 
            set => _hubraum = value;
        }

        public int PS {
            get => _ps; 
            set => _ps = value;
        }

        public int Geschwindigkeit {
            get => _maxSpeed; 
            set => _maxSpeed = value;
        }

        public int Drehmoment { 
            get => _maxDrehmoment;  
            set => _maxDrehmoment = value;
        }
    }
}
