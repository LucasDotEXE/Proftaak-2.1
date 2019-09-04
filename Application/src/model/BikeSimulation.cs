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
        public IProgram observer
        { get; }

        public List<string[]> protocols;
        public int iterator;

        // constructor
        public BikeSimulation(IProgram observer)
        {

            this.observer = observer;
            this.iterator = 0;

            this.setProtocols();
        }

        // methods
        public async void startConnection()
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

            )); 
        }

        private void setProtocols()
        {

            this.protocols = new List<string[]>();
            this.protocols.Add(new string[] { "", "", "" });
            this.protocols.Add(new string[] { "", "", "" });
            this.protocols.Add(new string[] { "", "", "" });
            this.protocols.Add(new string[] { "", "", "" });
            this.protocols.Add(new string[] { "", "", "" });
            this.protocols.Add(new string[] { "", "", "" });
        }
    }
}
