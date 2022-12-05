
namespace ATMAPP
{
    internal class ATMPidgin : ATMEnglish
    {
        protected override void Balance()
        {
            Console.Clear();
            double balance = account.AccountBalance;
            Designs.LogInAnime();

            Console.WriteLine("\nYour money na " + balance);

        }
        protected override void Transfer()
        {
            try
            {
                Console.Clear();
                Designs.LogInAnime();
                Console.WriteLine("\nWetin be the person card number wey you wan send money to");
                string cardNum = Console.ReadLine();

                Console.WriteLine("How much you wan send give am?");

                double amount = Convert.ToDouble(Console.ReadLine());

                accountToTransfer = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);
                if (amount < 100)
                {
                    Console.WriteLine("\nYou no fit transfer 100 naira or the one wey small pass am");
                }
                if (accountToTransfer == null)
                {
                    Console.WriteLine("We no sabi the account");
                }

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
                    Console.WriteLine($"\nYou no get money.\nYour money na {account.AccountBalance}");
                    
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        protected override void Deposit()
        {
            Console.Clear();
            Console.WriteLine("Put money for here");
            try
            {
                double deposit = Convert.ToDouble(Console.ReadLine());
                if (deposit < 100)
                {
                    Console.WriteLine("You no fit put 100");
                }
                else
                {
                    account.AccountBalance += deposit;

                    Designs.LogInAnime();
                    Console.WriteLine($"\nYour money come be = {account.AccountBalance}");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        protected override void Withdraw()
        {
            Console.WriteLine("How much you wan comot?");

            try
            {

                double withdrawal = Convert.ToDouble(Console.ReadLine());

                if (withdrawal < 100)
                {
                    Console.WriteLine($"You no fit withdraw {withdrawal}");
                    Console.WriteLine("Select 100 and above");
                }

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
        public void Start()
        {
            LogIn();
        }
        protected override void LogIn()
        {
            Console.Clear();
            userList.Add(new CardDetails("Amaka", "1234567890", 1234, 5000, false));
            userList.Add(new CardDetails("Jude", "1236786890", 1234, 4300, false));
            userList.Add(new CardDetails("Ada", "12367800009", 1234, 4700, false));
            userList.Add(new CardDetails("James", "1236786890", 2341, 4000, true));

            Console.WriteLine();
            Designs.LongLine();


            while (true)
            {
                try
                {
                    Console.WriteLine("\nPut the number for your card here");

                    string cardNum = Console.ReadLine();
                    account = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);

                    if (account.IsLocked == true)
                    {
                        Console.WriteLine($"Your account is locked. Rectify this issue with your bank");
                        Environment.Exit(0);
                    }

                    if (account != null) { break; }


                }
                catch
                {
                    Console.WriteLine("We never see this card before");
                }
            }



            while (true)
            {
                try
                {
                    Console.WriteLine("\nohya put your pin. or you press 0 to return to the main menu");

                    int pin = Convert.ToInt32(Console.ReadLine());
                    if (account.TotalLogin == 3)
                    {
                        Console.WriteLine($"Your account has been locked. You inputed a wrong pin {account.TotalLogin} times.");
                        Environment.Exit(0);
                    }

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


        protected override void Init()
        {
            Console.Clear();
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
                    Console.WriteLine("E no work. Na only numbers wey whole you fit put between 0 - 4");


                }
            }

        }
    }
}
