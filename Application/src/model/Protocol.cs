using System;

namespace Application.src.model
{
    class Protocol
    {

        // ToDo - add all the correct fields contained in the bytes!
        public string serviceName
        { get; set; }
        public double speed
        { get; set; }
        public double heartrate
        { get; set; }
        public double distance
        { get; set; }
        public int acumilatedPower
        { get; set; }
        public int currentPower
        { get; set; }
        public Protocol(string serviceName, byte[] bytes)
        {
            this.serviceName = serviceName;
            switch (BitConverter.ToInt32(bytes, 4))
            {
                case 0x10:
                    speed = BitConverter.ToDouble(bytes, 9) + BitConverter.ToDouble(bytes, 8);
                    distance = BitConverter.ToDouble(bytes, 7);
                    break;
                case 0x14: break;
                case 0x19:
                    acumilatedPower = BitConverter.ToInt32(bytes, 8) + BitConverter.ToInt32(bytes, 7);
                    currentPower = BitConverter.ToInt32(bytes, 10) + BitConverter.ToInt32(bytes, 9);
                    break;
            }
            // ToDo - add the decription of the bytes!
        }
        public void updateProtocol(byte[] bytes)
        {
            switch (BitConverter.ToInt32(bytes, 4))
            {
                case 0x10:
                    speed = BitConverter.ToDouble(bytes, 9) + BitConverter.ToDouble(bytes, 8);
                    distance = BitConverter.ToDouble(bytes, 7);
                    break;
                case 0x14: break;
                case 0x19:
                    acumilatedPower = BitConverter.ToInt32(bytes, 8) + BitConverter.ToInt32(bytes, 7);
                    currentPower = BitConverter.ToInt32(bytes, 10) + BitConverter.ToInt32(bytes, 9);
                    break;
            }
            // ToDo - add the decription of the bytes!
        }
    }

}
