using System;

namespace StateDesignPattern
{
    public interface IATMState
    {
        void InsertDebitCard();
        void EjectDebitCard();
        void EnterPin();
        void WithdrawMoney();
    }

    public class DebitCardNotInsertedState : IATMState
    {
        public void InsertDebitCard()
        {
            Console.WriteLine("DebitCard Inserted");
        }
        public void EjectDebitCard()
        {
            Console.WriteLine("You cannot eject the Debit CardNo, as no Debit Card in ATM Machine slot");
        }
        public void EnterPin()
        {
            Console.WriteLine("You cannot enter the pin, as No Debit Card in ATM Machine slot");
        }
        public void WithdrawMoney()
        {
            Console.WriteLine("You cannot withdraw money, as No Debit Card in ATM Machine slot");
        }
    }

    public class DebitCardInsertedState : IATMState
    {
        public void InsertDebitCard()
        {
            Console.WriteLine("You cannot insert the Debit Card, as the Debit card is already there ");
        }
        public void EjectDebitCard()
        {
            Console.WriteLine("Debit Card is ejected");
        }
        public void EnterPin()
        {
            Console.WriteLine("Pin number has been entered correctly");
        }
        public void WithdrawMoney()
        {
            Console.WriteLine("Money has been withdrawn");
        }
    }

    public class ATMMachine : IATMState
    {
        public IATMState AtmMachineState { get; set; }
        public ATMMachine()
        {
            AtmMachineState = new DebitCardNotInsertedState();
        }
        public void InsertDebitCard()
        {
            AtmMachineState.InsertDebitCard();
            // Kart daxil olundu

            if (AtmMachineState is DebitCardNotInsertedState)
            {
                AtmMachineState = new DebitCardInsertedState();
                Console.WriteLine("ATM Machine internal state has been moved to : "
                                + AtmMachineState.GetType().Name);
            }
        }
        public void EjectDebitCard()
        {
            AtmMachineState.EjectDebitCard();
            // Kart cixarildi

            if (AtmMachineState is DebitCardInsertedState)
            {
                AtmMachineState = new DebitCardNotInsertedState();
                Console.WriteLine("ATM Machine internal state has been moved to : "
                                + AtmMachineState.GetType().Name);
            }
        }
        public void EnterPin()
        {
            AtmMachineState.EnterPin();
        }
        public void WithdrawMoney()
        {
            AtmMachineState.WithdrawMoney();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // State hal hazirda --> DebitCardNotInsertedState
            ATMMachine atmMachine = new ATMMachine();
            Console.WriteLine("ATM Machine Current state : "
                            + atmMachine.AtmMachineState.GetType().Name);
            Console.WriteLine();
            atmMachine.EnterPin();
            atmMachine.WithdrawMoney();
            atmMachine.EjectDebitCard();
            atmMachine.InsertDebitCard();
            Console.WriteLine();
            // State hal hazirda --> DebitCardInsertedState
            Console.WriteLine("ATM Machine Current state : "
                            + atmMachine.AtmMachineState.GetType().Name);
            Console.WriteLine();
            atmMachine.EnterPin();
            atmMachine.WithdrawMoney();
            atmMachine.InsertDebitCard();
            atmMachine.EjectDebitCard();
            Console.WriteLine("");
            // State hal hazirda --> DebitCardNotInsertedState
            Console.WriteLine("ATM Machine Current state : "
                            + atmMachine.AtmMachineState.GetType().Name);
            Console.Read();
        }
    }
}
