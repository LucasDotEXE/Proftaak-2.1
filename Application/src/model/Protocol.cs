namespace Application.src.model
{
    class Protocol : observing.Observer<byte[]>
    {

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
            this.updateProtocol(bytes);
        }

        public void updateProtocol(byte[] bytes)
        {
            
            switch (bytes[4])
            {
                case 0x10:
                    speed = bytes[9] + bytes[8];
                    distance = bytes[7];
                    break;
                case 0x14: break;
                case 0x19:
                    acumilatedPower = bytes[8] + bytes[7];
                    currentPower = bytes[10] + bytes[9];
                    break;
            }
        }

        public override void update(byte[] content)
        {

            updateProtocol(content);
        }

        public override string ToString()
        {

            return string.Format(
                "ServiceName: {0}\nSpeed: {1}\nHeartrate: {2}\nDistance: {3}\nAcumilatedPower: {4}\nCurrentPower: {5}\n",
                 serviceName, speed, heartrate, distance, acumilatedPower, currentPower
            );
        }
    }
}
