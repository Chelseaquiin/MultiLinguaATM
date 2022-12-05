using System.Security.Cryptography.X509Certificates;

namespace ATMAPP
{
    internal class ATM
    {


        public ATMEnglish english { get; set; } = new ATMEnglish();
        public ATMIgbo igbo { get; set; } = new ATMIgbo();
        public ATMPidgin pidgin { get; set; } = new ATMPidgin();




        public void Initialize()
        {


            english.AddAccountLocked(HandleAccountLocked);
            english.AddTransferSuccessful(HandleTransferSuccessful);
            english.AddLoginSucceeded(HandleLoginSucceeded);
            english.AddAccountTobeLockedSoon(HandleAccountTobeLockedSoon);
            english.AddLowAccountBalance(HandleLowAccountBalance);

            Console.WriteLine("--------------Welcome to my MultiLingual ATM--------------");
            Designs.LanguageOptions();

            while (true)
            {
                try
                {
                    int userInput = Convert.ToInt32(Console.ReadLine());


                    switch (userInput)
                    {
                        case 1:
                            english.Start();
                            break;
                        case 2:
                            igbo.Start();
                            break;
                        case 3:
                            pidgin.Start();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Select a valid Option");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid. You can only choose whole numbers between 0 -3");

                }

            }

        }
          public  static void HandleAccountLocked(string message)
            {
                Console.WriteLine("=> {0}", message);
            }
          public  static void HandleAccountTobeLockedSoon(string message)
            {
                Console.WriteLine("=> {0}", message);
            }
          public  static void HandleLoginSucceeded(string message)
            {
                Console.WriteLine("=> {0}", message);
            }
          public  static void HandleLowAccountBalance(string message)

            {
                Console.WriteLine("=> {0}", message);
            }
          public  static void HandleTransferSuccessful(string message)
            {
                Console.WriteLine("=> {0}", message);
            }
        }
    }




