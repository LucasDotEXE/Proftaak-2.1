using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.src.model
{
    class BikeSimulation : IBike
    {

        // atributes
        public IApplication observer
        { get; }

        public List<string[]> protocols;
        public int iterator;

        // constructor
        public BikeSimulation(IApplication observer)
        {

            this.observer = observer;
            this.iterator = 0;

            this.setProtocols();
        }

        // methods
        public async void startConnection()
        {

            new Thread(new ThreadStart(loop));
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

            this.observer.receiveProtocol(new Protocol(
                this.protocols.ElementAt(this.iterator)[0],
                new byte[] { 22, 45, 12 }
            )); 
        }

        private void setProtocols()
        {

            this.protocols = new List<string[]>();
            this.protocols.Add(new string[] { "", "" });
            this.protocols.Add(new string[] { "", "" });
            this.protocols.Add(new string[] { "", "" });
            this.protocols.Add(new string[] { "", "" });
            this.protocols.Add(new string[] { "", "" });
            this.protocols.Add(new string[] { "", "" });
        }
    }
}
