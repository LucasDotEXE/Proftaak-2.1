using observing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

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
    protected override byte[] generateData()
    {
        return "it works";
    }
}

class BikeSimulatorPower : Simulator
{
    protected override byte[] generateData()
    {
        throw new NotImplementedException();
    }

    private String dataToString()
    {
        throw new NotImplementedException();
    }
}
class BikeSimulatorSpeed : Simulator
{
    protected override byte[] generateData()
    {
        throw new NotImplementedException();
    }
}

class HeartSimulator : Simulator
{
    protected override byte[] generateData()
    {
        byte HeartRateValueTypeIs16 = 0;
        byte SensorContactSupportNetwork = 0;
        byte SensorContactSupportLocal = 0;
        byte EnergyExpandedIncluded = 0;
        byte RRIntervalIncluded = 0;


        int BPM = base.simulationData.effortCurve[base.simulationData.indexer] * 10 + 90;
        int EnergyExpanded = base.simulationData.effortCurve[base.simulationData.indexer] * 10 + 20;
        base.simulationData.indexer++;

        byte[] array = new byte[5] { 
            HeartRateValueTypeIs16,
            SensorContactSupportNetwork,
            SensorContactSupportLocal,
            EnergyExpandedIncluded,
            RRIntervalIncluded,
    };



        String boolvals = array.ToString();
        boolvals += " " + (BitConverter.GetBytes(BPM) + " " + BitConverter.GetBytes(EnergyExpanded));

        return Encoding.ASCII.GetBytes(boolvals); // kon geen anderen manier vinden om het naar string te krijgen
    }
}

class SimulationData
{
    public List<int> effortCurve { get;  } = new List<int> { 1, 1, 1, 2, 2, 3, 4 };
    public int indexer { get; set; } = 0;

    public SimulationData()
    {     }
}

class Printer : Observer<byte[]>
{
    private String printerName;

    public Printer(string printerName)
    {
        this.printerName = printerName;
    }

    public override void update(byte[] content)
    {
        Console.WriteLine($"{printerName} prints: " + content);
    }
}

abstract class Simulator : Subject<byte[]>
{
    private Timer timer;
    abstract protected byte[] generateData();
    protected SimulationData simulationData { get; } = new SimulationData();

    public void turnOn(int sec)
    {
        timer = new System.Timers.Timer(sec * 1000);
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e) => base.update(generateData());


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
