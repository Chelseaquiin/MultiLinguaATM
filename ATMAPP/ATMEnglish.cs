namespace ATMAPP
{
    internal class ATMEnglish : IActions, ILogin
    {
        private List<CardDetails> userList = new List<CardDetails>();
        private CardDetails account = new CardDetails();
        private CardDetails accountToTransfer = new CardDetails();
        public void Balance()
        {

            double balance = account.AccountBalance;
            Designs.LogInAnime();

            Console.WriteLine("\nBalance " + balance);

        }
        public void Transfer()
        {
            try
            {
                Console.WriteLine();
                Designs.LogInAnime();
                Console.WriteLine("\nAccount to transfer to");
                string cardNum = Console.ReadLine();

                Console.WriteLine("How much do you want to transfer?");

                double amount = Convert.ToDouble(Console.ReadLine());

                accountToTransfer = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);

                if (account.AccountBalance >= amount && accountToTransfer != null)
                {
                    accountToTransfer.AccountBalance += amount;

                    account.AccountBalance -= amount;
                    Designs.LogInAnime();
                    Console.WriteLine($"\nTransfer to {accountToTransfer.FullName} was successful. \nYour Balance is: {account.AccountBalance}");
                }
                else
                {
                    Designs.LogInAnime();
                    Console.WriteLine("\ncard not recognized or Insufficient funds");
                    Console.WriteLine($"Balance {account.AccountBalance}");
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void Deposit()
        {

            Console.WriteLine("Deposit some cash");
            try
            {   
                double deposit = Convert.ToDouble(Console.ReadLine());
                Designs.LogInAnime();

                account.AccountBalance += deposit;

                Designs.LogInAnime();
                Console.WriteLine($"\nYour current Balance = {account.AccountBalance}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Withdraw()
        {
            Console.WriteLine("How much do you want to withdraw?");

            try
            {
              

                double withdrawal = Convert.ToDouble(Console.ReadLine());
                Designs.LogInAnime();

                if (account.AccountBalance < withdrawal)
                {
                    Designs.LogInAnime();
                    Console.WriteLine("\nInsufficient Balance");
                    Console.WriteLine($"Balance: {account.AccountBalance}");
                }
                else
                {
                    account.AccountBalance -= withdrawal;
                    Designs.LogInAnime();
                    Console.WriteLine($"\nThank you. Current Balance = {account.AccountBalance}");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LogIn()
        {

            userList.Add(new CardDetails("Amaka", "1234567890", 1234, 5000));
            userList.Add(new CardDetails("Jude", "1236786890", 1234, 4300));
            userList.Add(new CardDetails("Ada", "12367800009", 1234, 4700));
            userList.Add(new CardDetails("James", "1236786890", 2341, 4000));

            Console.WriteLine();
            Designs.LongLine();

            Console.WriteLine("\nPlease enter your card Number");

            while (true)
            {
                string cardNum = Console.ReadLine();
                account = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);

                if (account != null) 
                {
                    break;
                }
                else 
                { 
                    Console.WriteLine("card not recognized"); 
                }

            }

            Console.WriteLine("\nPlease enter your pin. Press 0 to return to the main menu");



            while (true)
            {
                try
                {
                    int pin = Convert.ToInt32(Console.ReadLine());


                    if (pin == 0)
                    {
                        Designs.LanguageOptions();
                        break;
                    }

                    if (account.CardPin == pin)
                    {

                        Console.WriteLine("\nHello " + account.FullName + ".");
                        Designs.LongLine();
                        Init();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Pin. Try again");
                    }

                    Designs.LongLine();
                }
                catch
                {
                    Console.WriteLine("Pins are numbers");
                }
            }

        }


        private void Init()
        {

            Console.WriteLine("\nWelcome!");
            Designs.Options();

            while (true)
            {
                try
                {

                    int userInput = Convert.ToInt32(Console.ReadLine());
                    switch (userInput)
                    {
                        case 1:
                            Deposit();
                            break;
                        case 2:
                            Withdraw();
                            break;
                        case 3:
                            Balance();
                            break;
                        case 4:
                            Transfer();
                            break;
                        case 0:
                            Console.WriteLine("Insert pin or press 0 to return to the main menu");
                            return;
                        default:
                            Console.WriteLine("Select a valid option");
                            break;
                    }
                    Console.WriteLine("\nSelect an option");
                    Designs.Options();
                }
                catch
                {
                    Console.WriteLine("Invalid. You can only choose whole numbers between 0 - 3");


                }
            }

        }
    }
}







