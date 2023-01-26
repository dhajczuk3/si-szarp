using static SimpleBank.Account;

namespace SimpleBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //testAccount();
            //testDerived();
            //tester();
            Transactions();
        }

         /*static void testAccount()
        {

            Account acc1 = new Account();
            Account acc2 = new Account(300);

            Console.WriteLine("Account objects created");
            Console.WriteLine("acc1: " + acc1);
            Console.WriteLine("acc2: " + acc2);

            Console.WriteLine("Credit acc1 with 300");
            acc1.credit(300);
            Console.WriteLine("acc1: " + acc1);

            Console.WriteLine("debit acc1 200");
            acc1.debit(200);
            Console.WriteLine("acc1: " + acc1);

            Console.WriteLine("try to debit acc1 300 ");
            acc1.debit(300);
            Console.WriteLine("acc1: " + acc1);

            Console.ReadLine();
        }*/

        static void testDerived()
        {
            CreditAccount acc = new CreditAccount();
            DepositAccount acc1 = new DepositAccount();

            acc.credit(1000);
            acc1.credit(1000);
            Console.WriteLine(acc);
            Console.WriteLine(acc1);

            Console.ReadLine();
        }

        static void tester()
        {
            CreditAccount acc1;
            DepositAccount acc2;
            acc1 = new CreditAccount(100, 100);
            acc2 = new DepositAccount(1200, 2.0);

            Console.WriteLine("Current account acc1 created with £100 and £100 OD");
            Console.WriteLine(acc1);
            Console.WriteLine("Deposit account acc2 created with £1200 and 2.0 rate");
            Console.WriteLine(acc2);

            Console.WriteLine("withdraw 150 from credit account acc1");
            acc1.debit(150);
            Console.WriteLine(acc1);

            try
            {
                Console.WriteLine("Try withdraw 200 from credit account acc1");
                Console.WriteLine("expect error");

                acc1.debit(150);
                Console.WriteLine("no error " + acc1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("balance should be same as before");
                Console.WriteLine(acc1);
            }

            try
            {
                Console.WriteLine("Try withdraw 2000 from debit account acc2");
                Console.WriteLine("expect error");

                acc2.debit(2000);
                Console.WriteLine("no error " + acc2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("balance should be same as before");
                Console.WriteLine(acc2);
            }

            Console.WriteLine("testing apply interest");
            acc2.addInterest();
            Console.WriteLine(acc2);

            Console.ReadLine();
        }


        static void Transactions()
        {

            /*CreditTransaction ct = new CreditTransaction(200, 300);
            Console.WriteLine(ct);
            DebitTransaction dt = new DebitTransaction(800, 200);
            Console.WriteLine(dt);*/

            CreditAccount acc1;
            acc1 = new CreditAccount();
            acc1.credit(900);
            acc1.debit(100);
            acc1.debit(50);
            acc1.credit(25);
            acc1.debit(400);
            Console.WriteLine(acc1.getStatement());


            CreditAccount acc2;
            acc2 = new CreditAccount();
            acc2.credit(500);
            acc2.debit(300);
            acc2.debit(190);
            acc2.credit(200);
            acc2.debit(300);
            Console.WriteLine(acc2.getStatement());



            Console.ReadLine();
        }

    }
}