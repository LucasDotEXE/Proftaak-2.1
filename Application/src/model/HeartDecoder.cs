using System;
using System.Linq;

class Heartdecoder : observing.Observer<byte[]>
{
    private bool HeartRateValueTypeIs16 { get; set; } //0 = UINT8 and 1 = UINT16
    private bool SensorContactSupportNetwork { get; set; } //0=NotSupported 1=Supported
    private bool SensorContactSupportLocal { get; set; } //0=NotSupported 1=Supported
    private bool EnergyExpandedIncluded { get; set; } //0=LeftOut 1=Included
    private bool RRIntervalIncluded { get; set; } //0=LeftOut 1=Included
    private int BPM { get; set; } //Heartbeats per minute
    private int EnergyExpanded { get; set; } // Energy Expanded in Joules
    private String name { get; set; }

    public Heartdecoder(String name)
    {
        HeartRateValueTypeIs16 = false;
        SensorContactSupportNetwork = false;
        SensorContactSupportLocal = false;
        EnergyExpandedIncluded = false;
        RRIntervalIncluded = false;
        BPM = 0;
        EnergyExpanded = 0;
        this.name = name;
    }

    public void updateData(byte[] data)
    {
        var binary = ToBinary(data);
        String[] split = binary.Split();
        String boolvals = split[0];
        //ADJUSTS THE BOOLEAN VALUES FOR THE DATA LOAD
        if (boolvals[0].Equals("0"))
        {
            HeartRateValueTypeIs16 = false;
        }
        else if (boolvals[0].Equals("1"))
        {
            HeartRateValueTypeIs16 = true;
        }

        if (boolvals[1].Equals("0"))
        {
            SensorContactSupportNetwork = false;
        }
        else if (boolvals[1].Equals("1"))
        {
            SensorContactSupportNetwork = true;
        }

        if (boolvals[2].Equals("0"))
        {
            SensorContactSupportLocal = false;
        }
        else if (boolvals[2].Equals("1"))
        {
            SensorContactSupportLocal = true;
        }

        if (boolvals[3].Equals("0"))
        {
            EnergyExpandedIncluded = false;
        }
        else if (boolvals[3].Equals("1"))
        {
            EnergyExpandedIncluded = true;
        }

        if (boolvals[4].Equals("0"))
        {
            RRIntervalIncluded = false;
        }
        else if (boolvals[4].Equals("1"))
        {
            RRIntervalIncluded = true;
        }

        String fullString = BitConverter.ToString(data);
        String[] dataStringArray = fullString.Split();
        BPM = int.Parse(dataStringArray[1], System.Globalization.NumberStyles.HexNumber);
        EnergyExpanded = int.Parse(dataStringArray[2], System.Globalization.NumberStyles.HexNumber);

    }

    public static String ToBinary(Byte[] data)
    {
        return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
    }

    public override void update(byte[] content)
    {
        updateData(content);
    }
}