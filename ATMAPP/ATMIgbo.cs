
namespace ATMAPP
{
    internal class ATMIgbo : ATMEnglish
    {
        protected override void Balance()
        {
            Console.Clear();
            double balance = account.AccountBalance;
            Designs.LogInAnime();

            Console.WriteLine("\nEgo gi bu " + balance);

        }
        protected override void Transfer()
        {
            try
            {
                Console.Clear();
                Console.WriteLine();
                Designs.LogInAnime();
                Console.WriteLine("\nKedu number di na card onye ichoro inye ego?");
                string cardNum = Console.ReadLine();

                Console.WriteLine("Ego one k'ichoro inye onye a?");

                double amount = Convert.ToDouble(Console.ReadLine());

                accountToTransfer = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);
                if (amount < 100)
                {
                    Console.WriteLine("\nigaro etinyenwo ego ntakiri");
                }

                if (accountToTransfer == null)
                {
                    Console.WriteLine("Anyi amaro akant a");
                }

                if (account.AccountBalance >= amount && accountToTransfer != null)
                {
                    accountToTransfer.AccountBalance += amount;

                    account.AccountBalance -= amount;
                    Designs.LogInAnime();
                    Console.WriteLine($"\n Ego etinyere {accountToTransfer.FullName} gara ofuma. \nEgo gi bu: {account.AccountBalance}");
                }
                else
                {
                    Designs.LogInAnime();
                    Console.WriteLine("\nAnyi amaro card ahu maobu n'ego gi ezuro");
                    Console.WriteLine($"Ego gi putara {account.AccountBalance}");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        protected virtual void Deposit()
        {
            Console.Clear();
            Console.WriteLine("Tinye ego");
            try
            {
                double deposit = Convert.ToDouble(Console.ReadLine());

                account.AccountBalance += deposit;

                Designs.LogInAnime();
                Console.WriteLine($"\nUgbua, ego gi bu = {account.AccountBalance}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        protected virtual void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("Ego one k'ichoro iweta?");

            try
            {

                double withdrawal = Convert.ToDouble(Console.ReadLine());
                if (withdrawal < 100)
                {
                    Console.WriteLine($"imaro ewepu {withdrawal}");
                    Console.WriteLine("weta 100 maobu nke kaririya");
                }

                if (account.AccountBalance < withdrawal)
                {
                    Designs.LogInAnime();
                    Console.WriteLine("\nEgo gi ezuro");
                    Console.WriteLine($"Ego gi bu: {account.AccountBalance}");
                }
                else
                {
                    account.AccountBalance -= withdrawal;
                    Designs.LogInAnime();
                    Console.WriteLine($"\nDaalu. Ego gi bu = {account.AccountBalance}");
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
            userList.Add(new CardDetails("James", "1236786890", 2341, 4000, false));

            Console.WriteLine();
            Designs.LongLine();

            Console.WriteLine("\nTinye Number gi");

            while (true)
            {
                try
                {
                    string cardNum = Console.ReadLine();
                    account = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);
                    if (account.IsLocked == true)
                    {
                        Console.WriteLine($"Akant gi kpochiri akpochi. Ga bank gi ka idozie ye");
                        Environment.Exit(0);
                    }
                    if (account != null) { break; }


                }
                catch
                {
                    Console.WriteLine("Anyi amaro akwukwo gi");
                }
            }

            



            while (true)
            {
                try
                {
                    Console.WriteLine("\nTinye pin gi. Tinye 0 maka inaghachi");
                    int pin = Convert.ToInt32(Console.ReadLine());

                    if (account.TotalLogin == 3)
                    {
                        Console.WriteLine($"Akpochigo akant gi. Itinyere pin n'adiro mma {account.TotalLogin}.");
                        Environment.Exit(0);
                    }
                    if (pin == 0)
                    {
                        Designs.LanguageOptions();
                        break;
                    }

                    if (account.CardPin == pin)
                    {

                        Console.WriteLine("\nNno " + account.FullName + ".");
                        Designs.LongLine();
                        Init();
                    }
                    else
                    {
                        Console.WriteLine("Meghariaya");
                    }

                    Designs.LongLine();
                }
                catch
                {
                    Console.WriteLine("Pins bu numbers");
                }
            }

        }


        protected override void Init()
        {

            Console.WriteLine("\nNno!");
            Designs.IgboOptions();

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
                            Console.WriteLine("Tinye pin maobu itinye 0 maka inaghachi");
                            return;
                        default:
                            Console.WriteLine("Tinye nke di mma");
                            break;
                    }
                    Console.WriteLine("\nTinye nke di mma");
                    Designs.IgboOptions();
                }
                catch
                {
                    Console.WriteLine("Ogaro. Tinye numbers 0 - 4");


                }
            }

        }
    }
}
