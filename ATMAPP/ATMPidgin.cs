
namespace ATMAPP
{
    internal class ATMPidgin : IActions, ILogin
    {
        private List<CardDetails> userList = new List<CardDetails>();
        private CardDetails account = new CardDetails();
        private CardDetails accountToTransfer = new CardDetails();

        public void Balance()
        {

            double balance = account.AccountBalance;
            Designs.LogInAnime();

            Console.WriteLine("\nYour money na " + balance);

        }
        public void Transfer()
        {
            try
            {
                Console.WriteLine();
                Designs.LogInAnime();
                Console.WriteLine("\nWetin be the person card number wey you wan send money to");
                string cardNum = Console.ReadLine();

                Console.WriteLine("How much you wan send give am?");

                double amount = Convert.ToDouble(Console.ReadLine());

                accountToTransfer = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);

                if (account.AccountBalance >= amount && accountToTransfer != null)
                {
                    accountToTransfer.AccountBalance += amount;

                    account.AccountBalance -= amount;
                    Designs.LogInAnime();
                    Console.WriteLine($"\nYour transfer to {accountToTransfer.FullName} been go well. \nYour money come remain: {account.AccountBalance}");
                }
                else
                {
                    Designs.LogInAnime();
                    Console.WriteLine("\nwe no sabi be person card or your money no reach");
                    Console.WriteLine($"Your money na {account.AccountBalance}");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void Deposit()
        {

            Console.WriteLine("Put money for here");
            try
            {
                double deposit = Convert.ToDouble(Console.ReadLine());

                account.AccountBalance += deposit;

                Designs.LogInAnime();
                Console.WriteLine($"\nYour money come be = {account.AccountBalance}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Withdraw()
        {
            Console.WriteLine("How much you wan comot?");

            try
            {

                double withdrawal = Convert.ToDouble(Console.ReadLine());

                if (account.AccountBalance < withdrawal)
                {
                    Designs.LogInAnime();
                    Console.WriteLine("\nYour money no reach");
                    Console.WriteLine($"Your money na: {account.AccountBalance}");
                }
                else
                {
                    account.AccountBalance -= withdrawal;
                    Designs.LogInAnime();
                    Console.WriteLine($"\nYou don try. Your money na = {account.AccountBalance}");
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

            Console.WriteLine("\nPut the number for your card here");

            while (true)
            {
                string cardNum = Console.ReadLine();
                account = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);

                if (account != null) { break; }
                else { Console.WriteLine("We never see this card before"); }

            }

            Console.WriteLine("\nohya put your pin. or you press 0 to return to the main menu");



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

                        Console.WriteLine("\nYou don show " + account.FullName + ".");
                        Designs.LongLine();
                        Init();
                    }
                    else
                    {
                        Console.WriteLine("Do am again");
                    }

                    Designs.LongLine();
                }
                catch
                {
                    Console.WriteLine("We no understand wetin you put. Pins na number");
                }
            }

        }


        private void Init()
        {

            Console.WriteLine("\nYou don show!");
            Designs.PidginOptions();

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
                            Console.WriteLine("Put your pin or press 0 to return to the main menu");
                            return;
                        default:
                            Console.WriteLine("Choose something we go understand");
                            break;
                    }
                    Console.WriteLine("\nChoose one option abeg");
                    Designs.PidginOptions();
                }
                catch
                {
                    Console.WriteLine("E no work. Na only numbers wey whole you fit put between 0 - 3");


                }
            }

        }
    }
}
