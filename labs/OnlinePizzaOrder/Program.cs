//Carlos vargas

using System;

namespace OnlinePizzaOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var done = false;
            do
            {
                switch (DisplayMenu())
                {
                    case Command.Add: newPizza(); break;
                    case Command.Display: DisplayOrder(); break;
                    case Command.Quit: done = true; break;
                };
            } while (!done);
        }

        private static void DisplayOrder()
        {
            if (String.IsNullOrEmpty(customerName))
            {
                Console.WriteLine("\nNo Orders Available\n");
                return;
            }
            Console.WriteLine("\nTotal: ");
            Console.WriteLine(customerName);
            Console.WriteLine(pizzaSize);
            Console.WriteLine(pizzaMeats);
            Console.WriteLine(pizzaVegetables);
            Console.WriteLine(pizzaSauce);
            Console.WriteLine(pizzaCheese);
            Console.WriteLine(pizzaDelivery);

            double total = pizzaSize + pizzaMeats + pizzaVegetables + pizzaSauce + pizzaCheese + pizzaDelivery;

            Console.WriteLine("TOTAL: \n");
            Console.WriteLine("---------------");
            Console.WriteLine(total);

        }
        enum Command
        {
            Quit = 0,
            Add = 1,
            Display = 2,
        }
        private static Command DisplayMenu()
        {
            do
            {
                Console.WriteLine("WELCOME TO MY FIRST PIZZERIA! :D\n");
                Console.WriteLine("C): Create new Order");
                Console.WriteLine("D): Display Order");
                Console.WriteLine("Q): Quit");


                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "c": return Command.Add;
                    case "d": return Command.Display;
                    case "q": return Command.Quit;

                    default: Console.WriteLine("Invalid option"); break;
                };
            } while (true);
        }

        static string customerName;
        static double pizzaSize;
        static double pizzaMeats;
        static double pizzaVegetables;
        static double pizzaSauce;
        static double pizzaCheese;
        static double pizzaDelivery;
        

        static void newPizza()
        {
            customerName = ReadName("\nENTER CUSTOMER NAME:", true);
            pizzaSize = ReadSize("\nSELECT PIZZA SIZE:\n");
            pizzaMeats = ReadMeats("SELECT MEATS: $0.75 extra each topping \n");
            pizzaVegetables = ReadVegetables("\nSELECT VEGETABLES: $0.50 extra each topping \n");
            pizzaSauce = ReadSauce("\nSELECT SAUSE:\n");
            pizzaCheese = ReadCheese("SELECT CHEESE:\n");
            pizzaDelivery = ReadDelivery("PICK UP OR DELIVERY?:\n");
            
        }
        private static string ReadName(string message, bool required)
        {
            Console.Write(message);
            do
            {
                string value = Console.ReadLine();

                if (!String.IsNullOrEmpty(value) || !required)
                    return value;

                if (required)
                    Console.WriteLine("Value is required");
            } while (true);
        }
        private static double ReadSize(string message)
        {

            Console.Write(message);

            double small = 5.00;
            double medium = 6.25;
            double large = 8.75;

            Console.WriteLine($"\na): Small:{small:C}\n" +
                $"b): Medium:${medium}\n" +
                $"c): Large:${large}\n");

            Console.WriteLine("Enter Choice: ");
            var choice1 = (Console.ReadLine());

            do
            {
                switch (choice1)
                {
                    case "a": return small;
                    case "b": return medium;
                    case "c": return large;

                    default: Console.WriteLine("Invalid option"); break;
                }; 
            } while (true);

        }
        private static double ReadMeats(string message)
        {
            Console.WriteLine(message);

            double totalMeats = 0;

            Console.WriteLine($"a) Bacon" +
                $"\nb) Ham" +
                $"\nc) Pepperoni" +
                $"\nd) Sausage\n");

                Console.WriteLine("Enter Choice: ");
                var choice2 = (Console.ReadLine());
                switch (choice2)
                {
                    case "a":
                        totalMeats += 0.75; break;
                    case "b":
                        totalMeats += 0.75; break;

                    case "c":
                        totalMeats += 0.75; break;

                    case "d":
                        totalMeats += 0.75; break;


                    default: Console.WriteLine("Invalid option"); break;
                }; return totalMeats;

            
        }
        private static double ReadVegetables(string message)
        {

            Console.WriteLine(message);


            double totalVegetables = 0;

            Console.WriteLine($"a) Black Olives" +
               $"\nb) Mushrooms" +
               $"\nc) Onions" +
               $"\nd) Peppers\n");

            Console.WriteLine("Enter Choice: ");
            var choice2 = (Console.ReadLine());
            switch (choice2)
            {
                case "a":
                    totalVegetables += 0.50; break;

                case "b":
                    totalVegetables += 0.50; break;

                case "c":
                    totalVegetables += 0.50; break;

                case "d":
                    totalVegetables += 0.50; break;


                default: Console.WriteLine("Invalid option"); break;
            }; return totalVegetables;
        }
        private static double ReadSauce(string message)
        {

            Console.Write(message);

            double traditional = 0.00;
            double garlic = 1.00;
            double oregano = 1.00;

            Console.WriteLine($"\na): Traditional:{traditional:C}\n" +
                $"b): Garlic:{garlic:C}\n" +
                $"c): Oregano:{oregano:C}\n");

            Console.WriteLine("Enter Choice: ");
            var choice4 = (Console.ReadLine());

            switch (choice4)
            {
                case "a": return traditional;
                case "b": return garlic;
                case "c": return oregano;

                default: Console.WriteLine("Invalid option"); break;
            }; return 0;

        }
        private static double ReadCheese(string message)
        {

            Console.Write(message);

            double regular = 0.00;
            double extra = 1.25;
  

            Console.WriteLine($"\na): Regular:{regular:C}\n" +
                $"b): Extra:${extra}\n");

            Console.WriteLine("Enter Choice: ");
            var choice4 = (Console.ReadLine());

            switch (choice4)
            {
                case "a": return regular;
                case "b": return extra;
               
                default: Console.WriteLine("Invalid option"); break;
            }; return 0;
        }
        private static double ReadDelivery(string message)
        {

            Console.Write(message);

            double takeOut = 0.00;
            double delivery = 2.50;
           


            Console.WriteLine($"\na): Take Out:${takeOut}\n" +
                $"b): Delivery Fee:{delivery:C}\n");

            Console.WriteLine("Enter Choice: ");
            var choice5 = (Console.ReadLine());

            switch (choice5)
            {
                case "a":
                    return takeOut;
                case "b": return delivery;

                default: Console.WriteLine("Invalid option"); break;
            }; return 0;
        }
    }     
}
    

