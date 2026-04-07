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

                        Console.WriteLine("Enter customer name: ");
                        string customerName = Console.ReadLine();

                        Console.WriteLine("Enter invoiceDate: ");
                        string invoiceDate = Console.ReadLine();

                        PrintInvoiceHeader(customerName, invoiceDate);

                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        break;

                    case 10:
                        break;

                    case 11:
                        break;

                    case 12:
                        break;

                    case 13:
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

        static public void PrintDailyGreeting()
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
            Console.WriteLine("Good morning, Trainee!" + ", current date: " + currentDate.ToString("dd/MM/yyyy") + ", current time: " + currentTime.ToString("hh:mm tt") + ". Let's code something great today!");

        }

        static public void PrintInvoiceHeader(string customerName, string invoiceDate = "")
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
    }
}
