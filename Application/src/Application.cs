using Application.src.model;
using System;

namespace Application.src
{
    class Application : observing.Observer<Protocol>
    {

        static void Main(string[] args)
        {
            Application thisApp = new Application();
            //IBike bike = new BikeSimulation(thisApp);
            //bike.startConnection();

            Simulator heartSimulator = new HeartSimulator();
            heartSimulator.subscibe(thisApp);
            Simulator bikeSimulatorPower = new BikeSimulatorPower();
            bikeSimulatorPower.subscibe(thisApp);
            Simulator bikeSimulatorSpeed = new BikeSimulatorSpeed();
            bikeSimulatorSpeed.subscibe(thisApp);

            heartSimulator.turnOn();
            bikeSimulatorPower.turnOn();
            bikeSimulatorSpeed.turnOn();

            Console.Read();
        }

        public override void update(Protocol content)
        {
            Console.WriteLine(content);
        }
    }
}
