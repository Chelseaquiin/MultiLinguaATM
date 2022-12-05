namespace ATMAPP
{
    internal class ATMEnglish
    {
        event Action<string> AccountLocked;
        event Action<string> AccountTobeLockedSoon;
        event Action<string> LoginSucceeded;
        event Action<string> LowAccountBalance;
        event Action<string> TransferSuccessful;

        protected List<CardDetails> userList = new List<CardDetails>();
        protected CardDetails account = new CardDetails();
        protected CardDetails accountToTransfer = new CardDetails();
        protected virtual void Balance()
        {
            Console.Clear();
            double balance = account.AccountBalance;
            Designs.LogInAnime();

            Console.WriteLine("\nBalance " + balance);

        }
        protected virtual void Transfer()
        {
            try
            {
                Console.Clear();
                Designs.LogInAnime();
                Console.WriteLine("\nAccount to transfer to");
                string cardNum = Console.ReadLine();


                Console.WriteLine("How much do you want to transfer?");

                double amount = Convert.ToDouble(Console.ReadLine());
                accountToTransfer = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);


                if (accountToTransfer == null)
                {
                    Console.WriteLine("Account not recognized");

                }

                if (amount < 100)
                {
                    Console.WriteLine("\nYou can't transfer less than 100 naira");
                }
               

               else if (account.AccountBalance >= amount && accountToTransfer != null)
                {
                    accountToTransfer.AccountBalance += amount;

                    account.AccountBalance -= amount;
                    Designs.LogInAnime();
                    OnTransferSuccessful($"\nTransfer to {accountToTransfer.FullName} was successful. \nYour Balance is: {account.AccountBalance}");

                }
                else
                {
                    Designs.LogInAnime();
                    Console.WriteLine($"\nInsufficient funds.\nBalance {account.AccountBalance}");
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
            Console.WriteLine("Deposit some cash");
            try
            {
                double deposit = Convert.ToDouble(Console.ReadLine());
                Designs.LogInAnime();

                if (deposit < 100)
                {
                    Console.WriteLine("You can't deposit less than 100");
                }
                else
                {
                    account.AccountBalance += deposit;

                    Designs.LogInAnime();
                    Console.WriteLine($"\nYour current Balance = {account.AccountBalance}");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        protected virtual void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("How much do you want to withdraw?");

            try
            {


                double withdrawal = Convert.ToDouble(Console.ReadLine());
                Designs.LogInAnime();

                if (withdrawal < 100)
                {
                    Console.WriteLine($"You can't withdraw {withdrawal}. \nSelect 100 and above");
 
                }
                else if (account.AccountBalance < withdrawal)
                {
                    Designs.LogInAnime();
                    OnLowAccountBalance($"\nInsufficient Balance \nBalance: {account.AccountBalance}");

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
        public void Start()
        {
            LogIn();
        }
        protected virtual void LogIn()
        {
            Console.Clear();
            userList.Add(new CardDetails("Amaka", "1234567890", 1234, 5000, false));
            userList.Add(new CardDetails("Jude", "1236786890", 1234, 4300, false));
            userList.Add(new CardDetails("Ada", "12367800009", 1234, 4700, false));
            userList.Add(new CardDetails("James", "1236786800", 2341, 4000, true));

            Console.WriteLine();
            Designs.LongLine();



            while (true)
            {
                try
                {
                    Console.WriteLine("\nPlease enter your card Number");
                    string cardNum = Console.ReadLine();
                    account = userList.FirstOrDefault<CardDetails>(a => a.CardNumber == cardNum);
                    if (account.IsLocked == true)
                    {
                        OnAccountLocked($"Your account is locked. Rectify this issue with your bank");
                        Environment.Exit(0);
                    }
                    if (account != null)
                    {
                        break;
                    }


                }
                catch
                {
                    Console.WriteLine("card not recognized");
                }



            }

            while (true)
            {
                try
                {
                    Console.WriteLine("\nPlease enter your pin or Press 0 to return");
                    int pin = Convert.ToInt32(Console.ReadLine());
                    if (account.TotalLogin == 3)
                    {
                        OnAccountLocked($"Your account has been locked. You inputed a wrong pin {account.TotalLogin} times.");
                        Environment.Exit(0);
                    }
                    if (pin == 0)
                    {
                        Designs.LanguageOptions();
                        break;
                    }

                    if (account.CardPin == pin)
                    {
                        OnLoginSucceeded($"\nHello {account.FullName} !");
                        Designs.LongLine();
                        Init();
                    }
                    else
                    {
                        OnAccountTobeLockedSoon("Incorrect pin. Your card will be locked after the 4th incorrect pin trial");
                        account.TotalLogin++;
                    }

                    Designs.LongLine();
                }
                catch
                {
                    Console.WriteLine("Pins are numbers");
                }


            }

        }


        protected virtual void Init()
        {
            Console.Clear();
            Console.WriteLine($"\nWelcome {account.FullName}!");
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
                    Console.WriteLine("Invalid. You can only choose whole numbers between 0 - 4");


                }
            }

        }
        public  void AddAccountLocked(Action<string> method)
        {
            AccountLocked+= method;
        }
        public void AddAccountTobeLockedSoon(Action<string> method)
        {
            AccountTobeLockedSoon += method;
        }
        public void AddLoginSucceeded(Action<string> method)
        {
            LoginSucceeded += method;
        }
        public void AddLowAccountBalance(Action<string> method)
        {
            LowAccountBalance += method;
        }
        public void AddTransferSuccessful(Action<string> method)
        {
            TransferSuccessful += method;
        }
        protected virtual void OnAccountLocked(string message)
        {
            AccountLocked?.Invoke(message);
        }
       protected virtual void OnAccountTobeLockedSoon(string message)
        {
            AccountTobeLockedSoon?.Invoke(message);
        }
        protected virtual void OnLoginSucceeded(string message)
        {
            LoginSucceeded?.Invoke(message);
        }
        protected virtual void OnLowAccountBalance(string message)
        {
            LowAccountBalance?.Invoke(message);
        }
        protected virtual void OnTransferSuccessful(string message)
        {
            TransferSuccessful?.Invoke(message);
        }
    }
}







