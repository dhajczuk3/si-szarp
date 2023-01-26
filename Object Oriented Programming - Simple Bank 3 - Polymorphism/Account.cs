using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace SimpleBank
{
    public abstract class Account
    {
        //class variable
        public static long num = 1;

        //instance variables
        private long number;
        private decimal balance;
        List<Transaction> transactions;


        public string getStatement()
        {
            transactions.Reverse();
            string strout = "Account: " + this.ToString() + "\n";
            foreach (Transaction t in transactions)
            {
                strout = strout + t + "\n";
            }
            transactions.Reverse();
            return strout;


        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
        }


        public long Number
        {
            get
            {
                return number;
            }
        }
        public Account()
        {
            
            balance = 0;
            IncrementNum();
        }

        public Account(decimal amount)
        {
            balance = amount;
        }


        public override string ToString()
        {
            string strout;
            strout = string.Format("Account num: {0}", number);
            strout = strout + string.Format(" Balance:{0:c}", balance);
            return strout;

        }

        public void credit(decimal amount)
        {

            balance = balance + amount;
            transactions.Add(new CreditTransaction(balance, amount));

        }

        virtual public void debit(decimal debit)
        {

            balance = balance - debit;

        }

        private void IncrementNum()
        {
            number = ++num;
        }
        public class CreditAccount : Account
        {
            private decimal ODLimit;
            public CreditAccount(decimal amount) : base(amount)
            {
                ODLimit = 100;
                transactions = new List<Transaction>();
            }
            public CreditAccount() : base()
            {
                ODLimit = 100;
                IncrementNum();
                transactions = new List<Transaction>();
            }

            public CreditAccount(decimal amount, decimal limit) : base(amount)
            {
                ODLimit = limit;
            }
            public override string ToString()
            {
                string strout;
                strout = "Credit account \n" + base.ToString();
                strout = strout + string.Format("\n OD Limit:{0:c}", ODLimit);
                return strout;
            }


            new public void debit(decimal amount)
            {
                balance = balance - amount;
                transactions.Add(new DebitTransaction(balance, amount));
            }



        }

        public class DepositAccount : Account
        {
            //instance variables
            private double rate;

            //PROPERTIES
            public double Rate
            {
                get { return rate; }
                set { rate = value; }
            }

            //CONSTRUCTORS

            public DepositAccount(decimal amount) : base(amount)
            {
                rate = 0.0;
                transactions = new List<Transaction>();
            }
            public DepositAccount() : base()
            {
                rate = 0.0;
                IncrementNum();
                transactions = new List<Transaction>();
            }

            public DepositAccount(decimal amount, double rt) : base(amount)
            {
                rate = rt;
            }

            public override string ToString()
            {
                string strout;
                strout = base.ToString();
                strout = strout + string.Format("\n Rate:{0:f2}", rate);
                return strout;
            }
            new public void debit(decimal amount)
            {
                if (amount > balance)
                {
                    throw new Exception("Insufficient funds - Transaction Cancelled");
                }
                else
                {
                    balance = balance - amount;
                }
            }

            public void addInterest()
            {
                balance = balance + (balance * (decimal)rate / 100);
            }
        }
    }
    public abstract class Transaction
    {
        private DateTime date;
        private decimal amount;
        private decimal cbalance;

        public decimal Amount
        {
            get { return amount; }
        }
        public decimal Balance
        {
            get { return cbalance; }
        }
        public DateTime Date
        {
            get { return date; }
        }

        public Transaction(decimal b, decimal a)
        {
            amount = a;
            cbalance = b;
            date = DateTime.Now;
        }

        public override string ToString()
        {
            string strout = date.ToShortDateString();
            strout = strout + "\t" + date.ToShortTimeString();
            return strout;
        }

    }

    public class CreditTransaction : Transaction
    {
        public CreditTransaction(decimal b, decimal a)
             : base(b, a)
        {
            //note how simply uses base
        }

        public override string ToString()
        {
            string strout;
            strout = base.ToString();
            strout = strout + string.Format("\t\t{0:c}\t{1:c}", Amount, Balance);
            return strout;
        }
    }

    public class DebitTransaction : Transaction
    {
        public DebitTransaction(decimal b, decimal a)
             : base(b, a)
        {
            //note how simply uses base
        }

        public override string ToString()
        {
            string strout;
            strout = base.ToString();
            strout = strout + string.Format("\t{0:c}\t\t{1:c}", Amount, Balance);

            return strout;
        }
    }





}




