using System.Globalization;

namespace Function_Task
{
    internal class Program
    {

        static public void DisplayMenu()
        {
            Console.WriteLine("======== Function Task System ========");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Today's Greeting.");
            Console.WriteLine("2. Star Border.");
            Console.WriteLine("3. Random Motivational Quote.");
            Console.WriteLine("4. Personalised Invoice Header.");
            Console.WriteLine("5. Number Pattern Printer.");
            Console.WriteLine("6. Word Frequency Analyser.");
            Console.WriteLine("7. Temperature Converter.");
            Console.WriteLine("8. Password Strength Checker.");
            Console.WriteLine("9. Simple Statistics Calculator.");
            Console.WriteLine("10. Session Timer.");
            Console.WriteLine("11. Magic Number Generator.");
            Console.WriteLine("12. Inspirational Day Message.");
            Console.WriteLine("13. Flexible Discount Calculator.");
            Console.WriteLine("14. Configurable Report Header.");
            Console.WriteLine("15. Smart Product Search.");
            Console.WriteLine("16. Exit.");
        }
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {

                DisplayMenu();

                Console.WriteLine("Please select an option: ");

                int option = 0;

                try
                {
                    option = int.Parse(Console.ReadLine());
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Invalid input. Please choose a number from 1 to 16.");
                }

                switch (option)
                {

                    case 1:

                        PrintDailyGreeting();

                        break;

                    case 2:

                        PrintStarBorder();

                        break;

                    case 3:



                        break;

                    case 4:

                        Console.WriteLine("Enter customer name: ");
                        string customerName = Console.ReadLine();

                        Console.WriteLine("Enter invoiceDate: ");
                        string invoiceDate = Console.ReadLine();

                        PrintInvoiceHeader(customerName, invoiceDate);

                        break;

                    case 5:

                        Console.WriteLine("Enter number of rows for the pattern: ");
                        int rows = int.Parse(Console.ReadLine());

                        PrintNumberPattern(rows);

                        break;

                    case 6:
                        break;

                    case 7:

                        Console.WriteLine("Enter temperature value: ");
                        double value = double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter unit of temperature (C, F, K): ");
                        string fromUnit = Console.ReadLine();

                        Console.WriteLine("Enter unit to convert to (C, F, K): ");
                        string toUnit = Console.ReadLine();

                        Console.WriteLine("The converted temperature is: " + ConvertTemperature(value, fromUnit, toUnit));

                        break;

                    case 8:

                        Console.WriteLine("Enter your password to check Strength  : ");
                        string password = Console.ReadLine();

                        Console.WriteLine("Password strength: " + GetPasswordStrength(password));

                        break;

                    case 9:
                        break;

                    case 10:

                        GetSessionInfo();

                        break;

                    case 11:
                        break;

                    case 12:
                        break;

                    case 13:

                        Console.WriteLine("Do you want to enter multiple prices? (yes/no): ");

                        string multiplePricesInput = Console.ReadLine();

                        if (multiplePricesInput.ToLower() == "yes")
                        {
                            Console.WriteLine("Enter prices separated by commas: ");
                            string pricesInput = Console.ReadLine();
                            string[] pricesArray = pricesInput.Split(',');
                            double[] prices = Array.ConvertAll(pricesArray, double.Parse);

                            Console.WriteLine("Enter discount percent: ");
                            double discountPrice = double.Parse(Console.ReadLine());

                            double[] discountedPrices = CalculateDiscount(prices, discountPrice);
                            Console.WriteLine("The final prices after discount are: " + string.Join(", ", discountedPrices));
                        }


                        else if (multiplePricesInput.ToLower() == "no")
                        {
                            Console.WriteLine("Enter price: ");
                            double price = double.Parse(Console.ReadLine());

                            Console.WriteLine("Enter discount percent: ");
                            double discountPercent = double.Parse(Console.ReadLine());

                            Console.WriteLine("Enter max cap (optional, press Enter to skip): ");
                            string maxCapInput = Console.ReadLine();

                            Console.WriteLine("The final price after discount is: " + (string.IsNullOrWhiteSpace(maxCapInput) ? CalculateDiscount(price, discountPercent) : CalculateDiscount(price, discountPercent, double.Parse(maxCapInput))));
                        }

                        break;

                    case 14:
                        break;

                    case 15:
                        break;

                    case 16:
                        exit = true;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose a number from 1 to 16.");
                        break;

                }

                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static public void PrintDailyGreeting() // case1
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
            Console.WriteLine("Good morning, Trainee!" + ", current date: " + currentDate.ToString("dd/MM/yyyy") + ", current time: " + currentTime.ToString("hh:mm tt") + ". Let's code something great today!");

        }

        static public void PrintInvoiceHeader(string customerName, string invoiceDate = "") // case 4
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            customerName = textInfo.ToTitleCase(customerName.ToLower());

            if (string.IsNullOrWhiteSpace(invoiceDate))
            {
                invoiceDate = "Date not provided";
            }

            Console.WriteLine("INVOICE");
            Console.WriteLine("Customer: " + customerName + "\nDate: " + invoiceDate);
        }

        static public double ConvertTemperature(double value, string fromUnit, string toUnit) // case 7
        {
            fromUnit = fromUnit.ToUpper();
            toUnit = toUnit.ToUpper();

            double convertedValue;

            // Convert the input value to Celsius first

            switch (fromUnit)
            {
                case "C":

                    convertedValue = value;

                    break;

                case "F":

                    convertedValue = (value - 32) * 5 / 9;

                    break;

                case "K":

                    convertedValue = value - 273.15;

                    break;

                default:

                    return -999; // Invalid fromUnit, return an error value
            }

            // Now convert from Celsius to the desired output unit

            double finalValue;

            switch (toUnit)
            {
                case "C":

                    finalValue = convertedValue;

                    break;
                case "F":

                    finalValue = (convertedValue * 9 / 5) + 32;

                    break;
                case "K":

                    finalValue = convertedValue + 273.15;

                    break;

                default:

                    return -999; // Invalid toUnit, return an error value
            }

            return Math.Round(finalValue, 2); // Round to 2 decimal places 
        }

        static public string GetSessionInfo() // case 10
        {
            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);

            string sessionInfo;

            if (currentTime.Hour < 12)
            {
                sessionInfo = "Morning session. ";
            }

            else if (currentTime.Hour >= 12 && currentTime.Hour <= 17)
            {
                sessionInfo = "Afternoon session. ";
            }

            else
            {
                sessionInfo = "Evening session. ";
            }

            string Info = ("Today is " + currentDay + ", " + currentDate.ToString("MMMM dd, yyyy") + ", current hour: " + currentTime.ToString("HH:mm") + "-" + sessionInfo); // return type is string, so we need to concatenate all the information into a single string to return it.

            return Info;

        }

        static public double CalculateDiscount(double price, double discountPercent) // case 13 (price and discount percent only)
        {
            double discountAmount = price * (discountPercent / 100);
            double finalPrice = price - discountAmount;

            return Math.Round(finalPrice, 3); // Round to 3 decimal places
        }

        static public double CalculateDiscount(double price, double discountPercent, double maxCap) //case 13 (price, discount percent and max cap)
        {
            double discountAmount = price * (discountPercent / 100);
            double finalPrice = price - discountAmount;

            if (discountAmount > maxCap)
            {
                finalPrice = price - maxCap;
            }

            return Math.Round(finalPrice, 3);
        }

        static public double[] CalculateDiscount(double[] prices, double discountPercent) //case 13 (price array and discount percent)
        {
            double[] discountedPrices = new double[prices.Length];

            for (int i = 0; i < prices.Length; i++)
            {
                discountedPrices[i] = Math.Round(prices[i] - (prices[i] * (discountPercent / 100)), 3);
            }

            return discountedPrices;
        }

        static public void PrintStarBorder() // case 2
        {
            int rows = 40;
            for (int i = 0; i < rows; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine("\n Welcome to C# Functions!\n");

            int row = 40;
            for (int i = 0; i < row; i++)
            {
                Console.Write("*");
            }

        }

        static public void PrintNumberPattern(int rows) // case 5 
        {
            int row = rows;

            for (int i = 1; i <= row; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }

                Console.WriteLine();
            }

        }

        static public string GetPasswordStrength(string password) // case 8
        {
            int Rating = 0;
            if (password.Length >= 8)
                Rating++;

            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[A-Z]"))
                Rating++;

            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[0-9]"))
                Rating++;

            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[! @ # $ % ^ & *]"))
                Rating++;

           
            if (Rating == 0 || Rating == 1)
                return "Weak";
                   

                   
            else if (Rating == 3 || Rating == 2)
                return "Moderate";


            else
                return "Strong";
                    



        }

    }
}
