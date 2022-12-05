

namespace ATMAPP
{
    internal class CardDetails
    {
        public string CardNumber { get; set; }
        public int CardPin { get; set; }
        public string FullName { get; set; }
        public double AccountBalance { get; set; }
        public bool IsLocked { get; set; }
        public int TotalLogin { get; set; }

        public CardDetails()
        {

        }

        public CardDetails(double accountBalance)
        {
            AccountBalance = accountBalance;
        }

        public CardDetails(string fullName, string cardNumber, int cardPin,  double accountBalance, bool isLocked)
        {
            CardNumber = cardNumber;
            CardPin = cardPin;
            FullName = fullName;
            AccountBalance = accountBalance;
            IsLocked = isLocked;
           
        }
    }
}
