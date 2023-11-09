using System;
using System.IO;

public class BankAccount : IDisposable
{
    private static int nextnumber = 3264;

    private int accountnumber;
    private decimal balance;
    private string accounttype;

    private StreamWriter writer;
    public BankAccount()
    {
        generate();
        writer = new StreamWriter(@"C:\\Users\\user\\source\\repos\\hw11.11.23\\hw11.11.23\\bin\\Debug");
    }

    public BankAccount(decimal initialBalance)
    {
        generate();
        writer = new StreamWriter(@"C:\\Users\\user\\source\\repos\\hw11.11.23\\hw11.11.23\\bin\\Debug");
        balance = initialBalance;
    }

    public BankAccount(string type)
    {
        generate();
        writer = new StreamWriter(@"C:\\Users\\user\\source\\repos\\hw11.11.23\\hw11.11.23\\bin\\Debug");
        accounttype = type;
    }

    public BankAccount(decimal initialBalance, string type)
    {
        generate();
        writer = new StreamWriter(@"C:\\Users\\user\\source\\repos\\hw11.11.23\\hw11.11.23\\bin\\Debug");
        balance = initialBalance;
        accounttype = type;
    }

    private void generate()
    {
        accountnumber = nextnumber++;
    }

    public int AccountNumber
    {
        get { return accountnumber; }
    }

    public decimal Balance
    {
        get { return balance; }
    }

    public string Accounttype
    {
        get { return accounttype; }
    }

    public void give(decimal a)
    {
        if (a >= 0) 
        { 
            balance += a;
            writer.WriteLine($"переведено {a:C} на счёт #{accountnumber}");
        }

    }

    public void take(decimal a)
    {
        if (a>=0 && balance >= a)
        {
            balance -= a;
            writer.WriteLine($"снято {a:C} с счёта #{accountnumber}");
        }
        else
        {
            Console.WriteLine("нет денег!");
        }
    }

    public void Transferr(BankAccount d, decimal a)
    {
        if (balance >= a)
        {
            balance -= a;
            d.give(a); 
            writer.WriteLine($"переведено {a:C} из счёта №{accountnumber} на счёт №{d.AccountNumber}");
        }
        else
        {
            Console.WriteLine("нет денег!");
        }
    }

    public void Dispose()
    {
        writer.Flush();
        writer.Close();
        writer.Dispose();
        GC.SuppressFinalize(this);
    }
}