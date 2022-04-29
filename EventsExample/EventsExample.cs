public delegate void BalanceEventHandler(decimal theValue);

class PiggyBank
{
    public decimal Balance { get; set; }
    public event BalanceEventHandler balanceChanged;

    public decimal theBalance
    {
        set
        {
            Balance = value;
            balanceChanged(value);
        }
        get
        {
            return Balance;
        }
    }
}

class BalanceLogger
{
    public void balanceLog(decimal amount)
    {
        Console.WriteLine("The balance amount is {0}", amount);
    }
}

class BalanceWatcher
{
    public void BalanceWatch(decimal amount)
    {
        if(amount > 500.0m)
        {
            Console.WriteLine("You have reached your savings goal {0}", amount);
        }
    }
}

class EventsExample
{
    static void Main(string[] args)
    {
        PiggyBank bank = new PiggyBank();
        BalanceLogger balanceLogger = new BalanceLogger();
        BalanceWatcher balanceWatcher = new BalanceWatcher();

        bank.balanceChanged += balanceLogger.balanceLog;
        bank.balanceChanged += balanceWatcher.BalanceWatch;

        string theStr;
        do
        {
            Console.WriteLine("How much to deposit?");

            theStr = Console.ReadLine();
            if (!theStr.Equals("exit"))
            {
                decimal newVal = decimal.Parse(theStr);

                bank.theBalance += newVal;
            }
        } while (!theStr.Equals("exit"));

    }
}


