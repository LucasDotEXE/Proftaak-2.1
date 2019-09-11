using Application.src.model;
using System;


namespace Test
{
    class testMain
    {
        /*static void Main(string[] args)
        {
            /*
            BikeSimulatorPower power = new BikeSimulatorPower();
            BikeSimulatorSpeed speed = new BikeSimulatorSpeed();

            Protocol bikedecoder = new Protocol("test bike decode");
            power.subscibe(bikedecoder);
            speed.subscibe(bikedecoder);
            power.turnOn(1);
            speed.turnOn(1);
            
            HeartSimulator heartsim = new HeartSimulator();
            Heartdecoder heartDecoder = new Heartdecoder("test heard decode");

            heartsim.subscibe(heartDecoder);

            heartsim.turnOn(1);


            Console.ReadLine();
            /*
            byte[] bytes = { 0xa4, 0x09, 0x4e, 0x05, 0x10, 0x19, 0xa4, 0x69, 0xC6, 0x02, 0xff, 0x24, 0xf9 };
            Protocol protocol = new Protocol("test", bytes);
            System.Console.WriteLine(BitConverter.ToString(bytes));
            byte[] bytes2 = { 0xa4, 0x09, 0x4e, 0x05, 0x19, 0xf4, 0x00, 0xa5, 0x0a, 0x00, 0x60, 0x20, 0xe4 };
            protocol.updateProtocol(bytes2);

            System.Console.WriteLine($"speed: {protocol.speed}, distance: {protocol.distance}," +
                $" acumulatedPower: {protocol.acumilatedPower}," +
                $" current power: {protocol.currentPower}");
            System.Console.Read();
            
        }*/
    }
}
