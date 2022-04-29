public delegate void BalanceEventHandler(decimal theValue);

class PiggyBank
{
    public decimal bankBalance { get; set; }

    public event BalanceEventHandler balanceChanged;

    public decimal theBalance
    {
        set
        {
            bankBalance = value;
            balanceChanged(value);
        }
        get
        {
            return bankBalance;
        }
    }
}

class LambdaExample
{
    static void Main(string[] args)
    {
        PiggyBank bank = new PiggyBank();

        bank.balanceChanged += (amount) => Console.WriteLine("The Balance amount is {0}", amount);
        bank.balanceChanged += (amount) => { if (amount > 500.0m) Console.WriteLine("You reached your savings goal! You have {0} ", amount); };

        string str;
        do
        {
            Console.WriteLine("How much to deposit");
            str = Console.ReadLine();
            if (!str.Equals("exit"))
            {
                decimal newval = decimal.Parse(str);
                bank.theBalance += newval;
            }
        }
        while (!str.Equals("exit"));
    }
}