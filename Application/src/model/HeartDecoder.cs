using System;
using System.Linq;

class Heartdecoder : observing.Observer<byte[]>
{

    private bool HeartRateValueTypeIs16 { get; set; } // 0 = UINT8 and 1 = UINT16
    private bool SensorContactSupportNetwork { get; set; } //0=NotSupported 1=Supported
    private bool SensorContactSupportLocal { get; set; } //0=NotSupported 1=Supported
    private bool EnergyExpandedIncluded { get; set; } //0=LeftOut 1=Included
    private bool RRIntervalIncluded { get; set; } //0=LeftOut 1=Included
    private int BPM { get; set; } //Heartbeats per minute
    private int EnergyExpanded { get; set; } // Energy Expanded in Joules
    private String name { get; set; }
    private int TotalEnergyExpanded { get; set; }

    public Heartdecoder(String name)
    {
        HeartRateValueTypeIs16 = false;
        SensorContactSupportNetwork = false;
        SensorContactSupportLocal = false;
        EnergyExpandedIncluded = false;
        RRIntervalIncluded = false;
        BPM = 0;
        EnergyExpanded = 0;
        TotalEnergyExpanded = 0;
        this.name = name;
    }

    private void updateDataTemp(byte[] data)
    {
        int[] bv = boolsplitter(hex2binary(data));
        HeartRateValueTypeIs16 = Convert.ToBoolean(bv[0]);
        SensorContactSupportLocal = Convert.ToBoolean(bv[1]);
        SensorContactSupportNetwork = Convert.ToBoolean(bv[2]);
        EnergyExpandedIncluded = Convert.ToBoolean(bv[3]);
        RRIntervalIncluded = Convert.ToBoolean(bv[4]);
        BPM = data[1];
        if (EnergyExpandedIncluded)
        {
            EnergyExpanded = data[2];
            TotalEnergyExpanded = TotalEnergyExpanded + data[2];
        }
        //Console.WriteLine(BPM);
    }
     

    public static string ByteArrayToString(byte[] data)
    {
        return BitConverter.ToString(data).Replace("-", "");
    }


    public static String ToBinary(Byte[] data)
    {
        return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
    }

    private string hex2binary(byte[] data)
    {

        string stringbyte = ByteArrayToString(data);
        Console.WriteLine(stringbyte);
        return Convert.ToString(Convert.ToInt32(stringbyte.Substring(0, 2), 16), 2);
    }

    private static int[] boolsplitter(string binvalue)
    {
        int[] vals = new int[binvalue.Length];
        for (int i = 0; i < binvalue.Length; i++)
        {
            vals[i] = Convert.ToInt32(binvalue.Substring(i, 1));
        }
        return vals;
    }

    public override void update(byte[] content)
    {
        updateDataTemp(content);
        System.Console.WriteLine($"BPM: {BPM}, EnergieExpanded: {EnergyExpanded}");
    }

}