
namespace ATMAPP
{
    internal class ATMIgbo : IActions, ILogin
    {
        private List<CardDetails> userList = new List<CardDetails>();
        private CardDetails account = new CardDetails();

        public void Balance()
        {

            double balance = account.AccountBalance;
            Designs.LogInAnime();

            Console.WriteLine("\nBalance " + balance);

        }

        public void Deposit()
        {

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

        public void Withdraw()
        {
            Console.WriteLine("Ego one k'ichoro iweta?");

            try
            {

                double withdrawal = Convert.ToDouble(Console.ReadLine());

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

        public void LogIn()
        {

            userList.Add(new CardDetails("Amaka", "1234567890", 1234, 5000));
            userList.Add(new CardDetails("Jude", "1236786890", 1234, 4300));
            userList.Add(new CardDetails("Ada", "12367800009", 1234, 4700));
            userList.Add(new CardDetails("James", "1236786890", 2341, 4000));

            Console.WriteLine();
            Designs.LongLine();

            Console.WriteLine("\nTinye Number gi");

            while (true)
            {
                string cardNum = Console.ReadLine();
                account = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);

                if (account != null) { break; }
                else { Console.WriteLine("Anyi amaro akwukwo gi"); }

            }

            Console.WriteLine("\nTinye pin gi. Tinye 0 maka inaghachi");



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


        private void Init()
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
                    Console.WriteLine("Ogaro. Tinye numbers 0 - 3");


                }
            }

        }
    }
}
