using System;
using System.Collections.Generic;

namespace Observer_State_StrategyDesignPatterns
{
    public interface IObserver
    {
        string UserName { get; set; }
        void Update(bool isAvailability);
    }

    public class CustomerObserver : IObserver
    {
        public string UserName { get; set; }

        public CustomerObserver(string userName, ISubject subject)
        {
            UserName = userName;
            subject.RegisterObserver(this);
        }


        public void Update(bool isAvailability)
        {
            if (isAvailability)
                Console.WriteLine("Hello " + UserName + ", Product is now available on Amazon");
        }
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class Subject : ISubject
    {
        public List<IObserver> observers = new List<IObserver>();

        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        private bool _isAvailability;

        public bool IsAvailability
        {
            get { return _isAvailability; }
            set
            {
                _isAvailability = value;
                if (value)
                {
                    Console.WriteLine("Availability changed from Out of Stock to Available.");
                    NotifyObservers();
                }
                else
                    Console.WriteLine("The product is not available in stock.");
            }
        }


        public Subject(string productName, double productPrice, bool isAvailability)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            IsAvailability = isAvailability;
        }

        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine("Observer Added : " + (/*(CustomerObserver)*/observer).UserName);
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            Console.WriteLine("Product Name :" + ProductName +
                              ", product Price : " + ProductPrice +
                              " is Now available. So notifying all Registered users ");
            Console.WriteLine();
            foreach (IObserver observer in observers)
            {
                observer.Update(IsAvailability);
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Subject Iphone = new Subject("Iphone 13", 2339.99, false);

            var customer1 = new CustomerObserver("Revan", Iphone);
            var customer2 = new CustomerObserver("Kamal", Iphone);
            var customer3 = new CustomerObserver("Sahil", Iphone);
            var customer4 = new CustomerObserver("Turan", Iphone);
            var customer5 = new CustomerObserver("Eli", Iphone);

            Console.WriteLine("\n******************************************************\n");


            Iphone.RemoveObserver(customer3);

            Iphone.IsAvailability = true;



        }
    }
}
