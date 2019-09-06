using Application.src.model;

namespace Test
{
    class testMain
    {
        static void Main(string[] args)
        {
            byte[] bytes = { 0xa4, 0x09, 0x4e, 0x05, 0x10, 0x19, 0xa4, 0x69, 0x00, 0x00, 0xff, 0x24, 0xf9 };
            Protocol protocol = new Protocol("test", bytes);
            byte[] bytes2 = { 0xa4, 0x09, 0x4e, 0x05, 0x19, 0xf4, 0x00, 0xa5, 0x0a, 0x00, 0x60, 0x20, 0xe4 };
            protocol.updateProtocol(bytes2);
            System.Console.WriteLine($"speed: {protocol.speed}, distance: {protocol.distance}, acumulatedPower: {protocol.acumilatedPower}, current power: {protocol.acumilatedPower}");
        }
    }
}
