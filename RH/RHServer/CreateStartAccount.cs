using RHLib.data;
using RHServer.server.model.account;
using RHServer.server.model.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHServer
{
    public class CreateStartAccount
    {

        public CreateStartAccount()
        {

            AccountManager.login("kees", "1", true);
            AccountManager.login("henk", "2", true);
            ClientData clientData = AccountManager.login("bert", "3", true);
            clientData.measurements.Add(Measurement.newMeasurement("test", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x19, 0x04, 0x43, 0x26, 0x0F, 0xCE, 0x60, 0x33, 0x0C }));
            clientData.measurements.Add(Measurement.newMeasurement("test", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x10, 0x19, 0xB4, 0x7C, 0x2C, 0x19, 0xFF, 0x34, 0xD9 }));
            clientData.measurements.Add(Measurement.newMeasurement("test", new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x19, 0x04, 0x43, 0x26, 0x0F, 0xCE, 0x60, 0x33, 0x0C }));

            AccountManager.save();
        }
    }
}
