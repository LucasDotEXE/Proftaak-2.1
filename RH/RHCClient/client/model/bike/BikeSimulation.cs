﻿using RHCClient.client.controller.interfaces;
using RHLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RHCClient.client.model.bike
{
    class BikeSimulation : IBike
    {

        // atributes
        public IApplication observer
        { get; }

        public List<Tuple<string, byte[]>> protocols;
        public int iterator;

        // constructor
        public BikeSimulation(IApplication observer)
        {

            this.observer = observer;
            this.iterator = 0;

            this.setProtocols();
        }

        // methods
        public void startConnection()
        {

            new Thread(new ThreadStart(loop)).Start();
        }

        private void loop()
        {

            while (true)
            {

                this.manageIterator();
                this.sendData();

                Thread.Sleep(1000);
            }
        }

        private void manageIterator()
        {

            this.iterator++;

            if (this.iterator == this.protocols.Count)
                this.iterator = 0; 
        }

        private void sendData()
        {

            this.observer.receiveMeasurement(Measurement.newMeasurement(
                this.protocols.ElementAt(this.iterator).Item1,
                this.protocols.ElementAt(this.iterator).Item2
            )); 
        }

        private void setProtocols()
        {

            this.protocols = new List<Tuple<string, byte[]>>();
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x10, 0x19, 0xA6, 0x6B, 0xB6, 0x02, 0xFF, 0x34, 0x5D }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x10, 0x19, 0xA8, 0x6C, 0xE9, 0x0C, 0xFF, 0x34, 0x05 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x19, 0x00, 0x24, 0x8E, 0x0C, 0x3E, 0x61, 0x30, 0x36 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x10, 0x19, 0xAA, 0x6E, 0xDD, 0x0E, 0xFF, 0x34, 0x33 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x19, 0x01, 0x31, 0x32, 0x0D, 0xA4, 0x60, 0x30, 0x04 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x10, 0x19, 0xAC, 0x71, 0x5C, 0x11, 0xFF, 0x34, 0xB4 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x19, 0x02, 0x37, 0xD3, 0x0D, 0xA1, 0x60, 0x33, 0xE6 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x10, 0x19, 0xAE, 0x73, 0x6C, 0x13, 0xFF, 0x34, 0x86 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x19, 0x03, 0x3A, 0x58, 0x0E, 0x85, 0x60, 0x33, 0x46 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x10, 0x19, 0xB0, 0x76, 0xCF, 0x15, 0xFF, 0x34, 0x38 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x50, 0xFF, 0xFF, 0x01, 0x59, 0x00, 0x54, 0x0B, 0xB1 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x50, 0xFF, 0xFF, 0x01, 0x59, 0x00, 0x54, 0x0B, 0xB1 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x19, 0x04, 0x43, 0x26, 0x0F, 0xCE, 0x60, 0x33, 0x0C }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x10, 0x19, 0xB4, 0x7C, 0x2C, 0x19, 0xFF, 0x34, 0xD9 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x19, 0x05, 0x48, 0xB9, 0x0F, 0x93, 0x60, 0x33, 0xC4 }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x19, 0x06, 0x4B, 0x5A, 0x10, 0xA1, 0x60, 0x33, 0x0A }));
            this.protocols.Add(new Tuple<string, byte[]>("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x10, 0x19, 0xB6, 0x7F, 0xB7, 0x19, 0xFF, 0x34, 0x43 }));
        }

        public void setResistance(int percentage)
        {
            throw new NotImplementedException();
        }
    }
}
