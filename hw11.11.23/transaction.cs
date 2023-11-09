using System;
public class BankTransaction
{
    public decimal amount { get; }
    public DateTime datetime { get; }
    public BankTransaction(decimal amount)
    {
        this.amount = amount;
        datetime = DateTime.Now;
    }
}

