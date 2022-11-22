namespace ATMAPP
{
    internal class ATM
    {


        public ATMEnglish english { get; set; } = new ATMEnglish();
        public ATMIgbo igbo { get; set; } = new ATMIgbo();
        public ATMPidgin pidgin { get; set; } = new ATMPidgin();




        public void Initialize()
        {

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
                            english.LogIn();
                            break;
                        case 2:
                            igbo.LogIn();
                            break;
                        case 3:
                            pidgin.LogIn();
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
    }



}
