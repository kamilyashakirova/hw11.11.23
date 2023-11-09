using System;
class Account
{
    private static int lastaccount = 0;

    public int accountnumber { get; private set; }
    public decimal Balance { get; private set; }
    public string accounttype { get; private set; }

    public Account()
    {
        generate();
    }

    public Account(decimal balance)
    {
        generate();
        Balance = balance;
    }

    public Account(string accountType)
    {
        generate();
        accounttype = accountType;
    }

    public Account(decimal balance, string accountType)
    {
        generate();
        Balance = balance;
        accounttype = accountType;
    }

    private void generate()
    {
        accountnumber = ++lastaccount;
    }
    /// <summary>
    /// положить money
    /// </summary>
    /// <param name="amount"></param>
    public void givememoney(decimal amount)
    {
        if (amount >= 0)
        {
            Balance += amount;
        }
        else
        {
            Console.WriteLine("ошибка");
        }
    }
    /// <summary>
    /// снять money
    /// </summary>
    /// <param name="amount"></param>
    public void takemymoney(decimal amount)
    {
        if (amount <= Balance && amount >= 0)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("нет денег!");
        }
    }
    /// <summary>
    /// перевод 
    /// </summary>
    /// <param name="destinationAccount"></param>
    /// <param name="amount"></param>
    public void Transfer(Account destinationAccount, decimal amount)
    {
        if (amount <= Balance)
        {
            takemymoney(amount);
            destinationAccount.givememoney(amount);
        }
        else
        {
            Console.WriteLine("нет денег!");
        }
    }
    public void PrintInfo()
    {
        Console.WriteLine("номер счёта: " + accountnumber);
        Console.WriteLine("баланс: " + Balance);
        Console.WriteLine("тип: " + accounttype);
    }
}
