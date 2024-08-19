namespace ConsoleAutoOO {

    internal class Program {

        static void Main(string[] args) {

            bool appRunning = true;
            while (appRunning) {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("ConsoleAutoOO \n");

                Auto auto1 = new Auto();
                Console.WriteLine("auto1 parameterloser Konstruktor: \n" + auto1.ToString());

                auto1.Hersteller = "Alfa Romeo";
                auto1.Bezeichnung = "147";
                auto1.Hubraum = 1900;
                auto1.PS = 150;
                auto1.Geschwindigkeit = 215;
                auto1.Drehmoment = 2000;

                Console.WriteLine("\nauto1:");
                Console.WriteLine(auto1.ToString());

                Auto auto2 = new Auto("BMW", "Dicke Karre", 4500, 390, 290, 6000);
                Console.WriteLine("\nauto2:");
                Console.WriteLine(auto2.ToString());

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
