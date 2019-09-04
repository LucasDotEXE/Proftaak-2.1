using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using observing;

namespace Simulators
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer bikePrinter = new Printer("Bike Printer");
            Printer heartPrinter = new Printer("HeartRate Printer");

            testSim bikeSim = new testSim();
            testSim heartSim = new testSim();


            bikeSim.subscibe(bikePrinter);
            heartSim.subscibe(heartPrinter);

            bikeSim.turnOn(2);
            heartSim.turnOn(4);


            Console.ReadLine();
        }
    }

    class testSim : Simulator
    {
        protected override string generateData()
        {
            return "it works";
        }
    }

    class BikeSimulator : Simulator
    {
        protected override string generateData()
        {

        }

        private String dataToString()
        {

        }
    }

    class HeartSimulator : Simulator
    {
        protected override string generateData()
        {

        }
    }

    class Printer : Observer<String>
    {
        private String printerName;

        public Printer(string printerName)
        {
            this.printerName = printerName;
        }

        public override void update(string content)
        {
            Console.WriteLine($"{printerName} prints: " + content);
        }
    }

    abstract class Simulator : Subject<String>
    {
        private Timer timer;
        abstract protected String generateData();

        public void turnOn(int sec)
        {
            timer = new System.Timers.Timer(sec * 1000);

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e) => base.update(generateData());


    }
}

namespace observing
{
    abstract class Observer<T>
    {
        abstract public void update(T content);
    }

    abstract class Subject<T>
    {
        List<Observer<T>> observers;

        protected Subject()
        {
            observers = new List<Observer<T>>();
        }

        public void update(T content)
        {
            foreach (Observer<T> observer in observers)
            {
                observer.update(content);
            }
        }

        public void subscibe(Observer<T> observer)
        {
            observers.Add(observer);
        }
    }
}
