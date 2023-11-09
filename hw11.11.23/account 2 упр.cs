using System;
using System.Collections;
using System.Collections.Generic;
public class Bank
{
    private decimal _balance;
    private readonly Queue<BankTransaction> _transactions = new Queue<BankTransaction>();

    public decimal Balancee
    {
        get { return _balance; }
    }

    public void givemoney(decimal a)
    {
        _balance += a;
        var transaction = new BankTransaction(a);
        _transactions.Enqueue(transaction);
    }

    public void takemoney(decimal a)
    {
        if (a <= _balance)
        {
            _balance -= a;
            var transaction = new BankTransaction(-a);
            _transactions.Enqueue(transaction);
        }
        else
        {
            throw new InvalidOperationException("нет денег!");
        }
    }

    public IEnumerable history()
    {
        return _transactions.ToArray();
    }
}
