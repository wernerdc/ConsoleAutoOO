using System.Xml.Serialization;

namespace ConsoleAutoOO 
{
    internal class Program 
    {
        // XML-Serializer
        static XmlSerializer xml = new XmlSerializer(typeof(List<Auto>));

        static void Main(string[] args) 
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("ConsoleAutoOO \n");

            // liste mit beispiel-daten
            List<Auto> autos = [new Auto("BMW", "Z8", 4941, 400, 250, 500),
                                new Auto("Alfa Romeo", "147", 1910, 150, 208, 305),
                                new Auto("VW", "Golf VIII", 1968, 116, 202, 300),
                                new Auto("Honda", "Civic XI", 1993, 143, 180, 186)];

            bool appRunning = true;
            while (appRunning) 
            {
                
                string option = GetMenuOptionFromConsole();
                switch (option) 
                {
                    case "a":
                        ShowAutos(autos); 
                        break;
                    case "h":
                        autos.Add(AddNewAuto());
                        break;
                    case "l":
                        autos = AutosEinlesen();
                        break;
                    case "s":
                        AutosSpeichern(autos);
                        break;
                    default:
                        break;
                }

                Console.Write("\nProgramm beenden (e)? ");
                try 
                {
                    string exitApp = Console.ReadLine();
                    if (exitApp.ToUpper() == "E") {
                        appRunning = false;
                    }
                } 
                catch 
                {
                    // no error message, just keep going and repeat the app
                }
                // overwrite exit message if app did not quit before
                Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top - 1);
            }
        }

        public static string GetMenuOptionFromConsole() 
        {
            string menuOption = "";
            bool validOption = false;
            while (!validOption) 
            {
                try 
                {
                    Console.Write("Autos (A)nzeigen, Auto (H)inzufügen, Autos (L)aden, Autos (S)peichern: ");
                    menuOption = Console.ReadLine().ToLower();
                    if (menuOption == "a" || menuOption == "h" || menuOption == "l" || menuOption == "s") 
                    {
                        validOption = true;
                    }
                    else 
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Ungültige Eingabe! Nur a, h oder s sind erlaubt");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                catch 
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Ungültige Eingabe! Nur a, h oder s sind erlaubt");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            return menuOption;
        }
        
        public static string GetNewAutoDataFromConsole(string beschribung, bool doubleType) 
        {
            string newData = "";
            bool validInput = false;
            while (!validInput) 
            {
                try 
                {
                    Console.Write(beschribung);
                    newData = Console.ReadLine();

                    // teste typ-umwandlung wenn doubleType true ist
                    if (doubleType) 
                    {
                        int.Parse(newData);
                    }
                    validInput = true;
                }
                catch 
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Ungültige Eingabe!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            return newData;
        }

        public static Auto AddNewAuto() 
        {
            string hersteller = GetNewAutoDataFromConsole("Hersteller: ", false);
            string bezeichnung = GetNewAutoDataFromConsole("Bezeichnung: ", false);
            
            // int.Parse wird in GetNewAutoDataFromConsole("", true) überprüft 
            double hubraum = double.Parse(GetNewAutoDataFromConsole("Hubraum: ", true));
            double ps = double.Parse(GetNewAutoDataFromConsole("PS: ", true));
            double speed = double.Parse(GetNewAutoDataFromConsole("Höchstgeschwindigkeit: ", true));
            double drehmoment = double.Parse(GetNewAutoDataFromConsole("Drehmoment: ", true));

            return new Auto(hersteller, bezeichnung, hubraum, ps, speed, drehmoment);
        }

        public static void ShowAutos(List<Auto> autos) 
        {
            Console.WriteLine("{0,-16} {1,-16} {2,8:N0} {3,6:N0} {4,6:N0} {5,6:N0}",
                            "Hersteller",
                            "Modell",
                            "ccm",
                            "ps",
                            "km/h",
                            "nm");

            for (int i = 0; i < autos.Count; i++) 
            {
                Console.WriteLine("{0,-16} {1,-16} {2,8:N0} {3,6:N0} {4,6:N0} {5,6:N0}",
                        autos[i].Hersteller,
                        autos[i].Bezeichnung,
                        autos[i].Hubraum,
                        autos[i].PS,
                        autos[i].Geschwindigkeit,
                        autos[i].Drehmoment);
            }
        }

        public static void AutosSpeichern(List<Auto> autoListe)
        {
            StreamWriter streamWriter = new StreamWriter("Autos.xml");
            xml.Serialize(streamWriter, autoListe);
            streamWriter.Close();
            Console.WriteLine("Anzahl Autos gespeichert: " + autoListe.Count);
        }

        public static List<Auto> AutosEinlesen()
        {
            List<Auto> autoListe = new List<Auto>();
            try
            {
                StreamReader streamReader = new StreamReader("Autos.xml");
                autoListe = (List<Auto>)xml.Deserialize(streamReader);
                streamReader.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler beim Einlesen der Autos.xml");
            }
            Console.WriteLine("Anzahl Autos eingelesen: " + autoListe.Count);

            return autoListe;
        }
    }
}
