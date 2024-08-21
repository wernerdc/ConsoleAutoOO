namespace ConsoleAutoOO {

    internal class Program {

        static void Main(string[] args) {

            List<Auto> autos = [new Auto("BMW", "Z8", 4941, 400, 250, 500),
                                    new Auto("Alfa Romeo", "147", 1910, 150, 208, 305),
                                    new Auto("VW", "Golf VIII", 1968, 116, 202, 300),
                                    new Auto("Honda", "Civic XI", 1993, 143, 180, 186)];

            bool appRunning = true;
            while (appRunning) {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("ConsoleAutoOO \n");
                

                string option = GetMenuOptionFromConsole();

                switch (option) {
                    case "a":
                        ShowAutos(autos); 
                        break;
                    case "h":
                        autos.Add(CreateNewAuto());
                        break;
                    case "s":
                        break;
                    default:
                        break;
                }


                Console.Write("\n\nProgramm beenden (e)? ");
                try {
                    string exitApp = Console.ReadLine();
                    if (exitApp.ToUpper() == "E") {
                        appRunning = false;
                    }
                } catch {
                    // no error message, just keep going and repeat the app
                }
            }
        }

        public static string GetMenuOptionFromConsole() {

            string menuOption = "";
            bool validOption = false;
            while (!validOption) {
                try {
                    Console.Write("Autos (a)nzeigen, Auto (h)inzufügen, Autos (s)peichern: ");
                    menuOption = Console.ReadLine().ToLower();
                    if (menuOption == "a" || menuOption == "h" || menuOption == "s") {
                        validOption = true;
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Ungültige Eingabe! Nur a, h oder s sind erlaubt");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                catch {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Ungültige Eingabe! Nur a, h oder s sind erlaubt");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            return menuOption;
        }
        
        public static string GetNewAutoDataFromConsole(string beschribung, bool intType) {

            string newData = "";
            bool validInput = false;
            while (!validInput) {
                try {
                    Console.Write(beschribung);
                    newData = Console.ReadLine();
                    if (intType) {
                        int.Parse(newData);
                    }
                    validInput = true;
                }
                catch {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Ungültige Eingabe!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            return newData;
        }

        public static Auto CreateNewAuto() {

            string hersteller = GetNewAutoDataFromConsole("Hersteller: ", false);
            string bezeichnung = GetNewAutoDataFromConsole("Bezeichnung: ", false);
            int hubraum = int.Parse(GetNewAutoDataFromConsole("Hubraum: ", true));
            int ps = int.Parse(GetNewAutoDataFromConsole("PS: ", true));
            int speed = int.Parse(GetNewAutoDataFromConsole("Höchstgeschwindigkeit: ", true));
            int drehmoment = int.Parse(GetNewAutoDataFromConsole("Drehmoment: ", true));

            return new Auto(hersteller, bezeichnung, hubraum, ps, speed, drehmoment);
        }

        public static void ShowAutos(List<Auto> autos) {

            Console.WriteLine("{0,-16} {1,-16} {2,8} {3,6} {4,6} {5,6}",
                            "Hersteller",
                            "Modell",
                            "ccm",
                            "ps",
                            "km/h",
                            "nm");

            for (int i = 0; i < autos.Count; i++) {
                Console.WriteLine("{0,-16} {1,-16} {2,8} {3,6} {4,6} {5,6}",
                        autos[i].Hersteller,
                        autos[i].Bezeichnung,
                        autos[i].Hubraum,
                        autos[i].PS,
                        autos[i].Geschwindigkeit,
                        autos[i].Drehmoment);
            }
        }
    }
}
