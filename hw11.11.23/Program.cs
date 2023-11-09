using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        //Упражнение 9.1. банковский счет
        Console.WriteLine("Упражнение 9.1. банковский счет\nсоздать конструктор для заполнения поля баланс, для заполнения поля тип банковского счета, для заполнения баланса и типа банковского счета. Каждый должен вызывать метод, генерирующий номер счета.");
        Account account1 = new Account();
        account1.givememoney(10334);
        account1.PrintInfo();
        Account account2 = new Account(98659);
        account2.PrintInfo();
        Account account3 = new Account("sberegatelnyi");
        account3.PrintInfo();
        Account account4 = new Account(27889, "checking");
        account4.PrintInfo();
        account1.Transfer(account2, 4568769959759698);
        account1.PrintInfo();
        account2.PrintInfo();
        Console.ReadLine();
        //Упражнение 9.2. cоздать новый класс BankTransaction, который будет хранить информацию обо всех банковских операциях.
        Console.WriteLine("Упражнение 9.2. Создать новый класс BankTransaction, который будет хранить информацию о всех банковских операциях.");
        Bank accountt = new Bank();
        accountt.givemoney(1234455677888);
        accountt.takemoney(7899909090009);
        foreach (BankTransaction transaction in accountt.history())
        {
            Console.WriteLine("when: {0}, how much money: {1}", transaction.datetime, transaction.amount);
        }
        //Упражнение 9.3. в классе банковский счет создать метод Dispose
        Console.WriteLine("Упражнение 9.3. в классе банковский счет создать метод Dispose");
        BankAccount account = new BankAccount(9875, "sberegatelnyi");
        account.give(476);
        account.take(868);
        Console.WriteLine("номер счёта: {0}", account.AccountNumber);
        Console.WriteLine($"баланс: {account.Balance:C}");
        Console.WriteLine("тип: {0}",account.Accounttype);
        BankAccount d = new BankAccount(1998, "сhecking");
        account.Transferr(d, 236);
        account.Dispose();
        //Домашнее задание 9.1. список песен
        List<Song> songs = new List<Song>();
        Song mySong = new Song();
        Song s1 = new Song("Пачка сигарет", "КИНО");
        Song s2 = new Song("Without me", "Eminem");
        Song s3 = new Song("Young, Wild & Free", "Snoop Dogg, Wiz Khalifa, Bruno Mars", s2);
        Song s4 = new Song("NO FUN", "Joji", s3);
        songs.Add(s1);
        songs.Add(s2);
        songs.Add(s3);
        songs.Add(s4);
        foreach (Song s in songs)
        {
            s.PrintInfo();
        }
        bool areequal = s1.Equals(s2);
        Console.WriteLine("Домашнее задание 9.1. список песен");
        Console.WriteLine("Пачка сигарет - КИНО");
        Console.WriteLine("Without me - Eminem");
        Console.WriteLine("Young, Wild & Free - Snoop Dogg, Wiz Khalifa, Bruno Mars");
        Console.WriteLine("NO FUN - Joji");
        Console.WriteLine("1 и 2 песни совпадают: " + areequal);
    }
}

