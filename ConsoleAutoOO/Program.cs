namespace ConsoleAutoOO {

    internal class Program {

        static void Main(string[] args) {

            bool appRunning = true;
            while (appRunning) {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("ConsoleAutoOO \n");

                List<Auto> autos = [new Auto("BMW", "Z8", 4941, 400, 250, 500),
                                    new Auto("Alfa Romeo", "147", 1910, 150, 208, 305),
                                    new Auto("VW", "Golf VIII", 1968, 116, 202, 300),
                                    new Auto("Honda", "Civic XI", 1993, 143, 180, 186)];

                //for (int i = 0; i < autos.Count; i++) {
                //    Console.WriteLine(autos[i].ToString());
                //    Console.WriteLine();
                //}

                //Console.WriteLine("--------------------------------");
                //foreach (Auto auto in autos) {
                //    Console.WriteLine(auto.ToString());
                //    Console.WriteLine();
                //}
                //Console.WriteLine("--------------------------------");

                Console.WriteLine("{0,-16} {1,-16} {2,8} {3,6} {4,6} {5,6}",
                        "Hersteller",
                        "Modell",
                        "ccm",
                        "ps",
                        "km/h",
                        "nm");

                for (int i = 0; i < autos.Count; i++) {
                    //Console.WriteLine($"{autos[i].Hersteller,-10} {autos[i].Bezeichnung,-10} {autos[i].Hubraum,6} {autos[i].PS,4} {autos[i].Geschwindigkeit,4} {autos[i].Drehmoment,4}");
                    Console.WriteLine("{0,-16} {1,-16} {2,8} {3,6} {4,6} {5,6}", 
                            autos[i].Hersteller, 
                            autos[i].Bezeichnung, 
                            autos[i].Hubraum, 
                            autos[i].PS, 
                            autos[i].Geschwindigkeit, 
                            autos[i].Drehmoment);
                }

                //Auto auto1 = new Auto();
                //Console.WriteLine("auto1 parameterloser Konstruktor: \n" + auto1.ToString());

                //auto1.Hersteller = "Alfa Romeo";
                //auto1.Bezeichnung = "147";
                //auto1.Hubraum = 1900;
                //auto1.PS = 150;
                //auto1.Geschwindigkeit = 215;
                //auto1.Drehmoment = 2000;

                //Console.WriteLine("\nauto1:");
                //Console.WriteLine(auto1.ToString());

                //Auto auto2 = new Auto("BMW", "Dicke Karre", 4500, 390, 290, 6000);
                //Console.WriteLine("\nauto2:");
                //Console.WriteLine(auto2.ToString());

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
    }
}
