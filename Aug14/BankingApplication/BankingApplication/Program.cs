using System;
using System.Globalization;

class Sample
{
    static void Main()
    {
        Console.WriteLine("*******ijdio bank*********");
        Console.WriteLine("::Login Page::");

        string userName = null, password = null;

        Console.Write("User name :");
        userName = Console.ReadLine();

        if (userName.Trim() != "")
        {
            Console.Write("Password : ");
            password = Console.ReadLine();
        }

        if (userName == "system" && password == "manager")
        {
            int mainMenuChoice = -1;

            do
            {
                Console.WriteLine("\n ::Main Menu :: \n");
                Console.WriteLine("1.Customers");
                Console.WriteLine("2.Accounts");
                Console.WriteLine("3.Funds transfer");
                Console.WriteLine("4.Funds Transfer Statement");
                Console.WriteLine("5.Account Statement");
                Console.WriteLine("0.Exit");

                Console.WriteLine("Enter Choice : ");
                mainMenuChoice = int.Parse(Console.ReadLine());

                switch (mainMenuChoice)
                {
                    case 1:
                        CustomerMenu();// Display customer menu
                        break;
                    case 2: //TO DO : Display accounts menu
                        break;
                    case 3: //TO DO : Display funds transfer menu
                        break;
                    case 4: //TO DO : Display funds transfer statement menu
                        break;
                    case 5: //TO DO : Display account statement menu
                        break;
                }
            } while (mainMenuChoice != 0);
        }
        else
        {
            Console.WriteLine("Invalid username or password");
        }
        Console.WriteLine("Thank you ! visit again");
    }

    static void CustomerMenu()
    {
        int customerMenuChoice = -1;
        do
        {
            Console.WriteLine("\n:::Customer menu :::\n");
            Console.WriteLine("1.Add Customer");
            Console.WriteLine("2.Delete Customer");
            Console.WriteLine("3.Update Customer");
            Console.WriteLine("4.View Customer");
            Console.WriteLine("0.Back to Main Menu");

            Console.Write("Enter choice :");
            customerMenuChoice = int.Parse(Console.ReadLine());
        } while (customerMenuChoice != 0);
    }

    static void AccountMenu()
    {
        int accountMenuChoice = -1;
        do
        {
            Console.WriteLine("\n:::Customer menu :::\n");
            Console.WriteLine("1.Add Account");
            Console.WriteLine("2.Delete Account");
            Console.WriteLine("3.Update Account");
            Console.WriteLine("4.View Account");
            Console.WriteLine("0.Back to Main Menu");

            Console.Write("Enter choice :");
            accountMenuChoice = int.Parse(Console.ReadLine());
        } while (accountMenuChoice != 0);
    }
}