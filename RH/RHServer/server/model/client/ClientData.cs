using RHLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHServer.server.model.client
{
    class ClientData
    {

        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public List<Measurement> measurements { get; set; }

        public static ClientData newClient(int id, string name, string password)
        {

            ClientData client = new ClientData();

            client.id = id;
            client.name = name;
            client.password = password;
            client.measurements = new List<Measurement>();

            return client;
        }

        public override string ToString()
        {

            return String.Format(
                "id: {0}|name: {1}|password: {2}|protocols: {3}",
                this.id, this.name, this.password, this.measurements
            );
        }
    }
}
