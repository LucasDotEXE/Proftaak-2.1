using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.src.model
{
    class Protocol
    {

        // ToDo - add all the correct fields contained in the bytes!
        public double speed
        { get; }
        public double heartrate
        { get; }   
        public double distance
        { get; }
        public int acumilatedPower
        { get; }
        public int currentPower
        { get; }
        public Protocol(byte[] bytes)
        {

            switch (BitConverter.ToInt32( bytes,4))
            {
                case 0x10:
                    speed = BitConverter.ToDouble(bytes,9) + BitConverter.ToDouble(bytes, 8);
                    distance = BitConverter.ToDouble(bytes, 7);
                    break;
                case 0x14:  break; 
                case 0x19:
                    acumilatedPower= BitConverter.ToInt32(bytes,8) + BitConverter.ToInt32(bytes, 7);
                    currentPower = BitConverter.ToInt32(bytes, 10) + BitConverter.ToInt32(bytes, 9);
                    break; 
            }

            // ToDo - add the decription of the bytes!
        }
    }
}
