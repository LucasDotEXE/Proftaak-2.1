using Newtonsoft.Json;
using RHBase.helper;
using RHServer.server.model.client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHServer.server.model.account
{

    class AccountManager
    {

        // attributes
        private static List<ClientData> clients = new List<ClientData>();

        // login
        public static ClientData login(string name, string password, bool register = false)
        {

            load();

            foreach (ClientData client in clients)
                if (client.name == name && client.password == password)
                    return client;

            if (register)
            {

                clients.Add(ClientData.newClient(generateId(), name, password));
                return login(name, password);
            }

            return null;
        }

        private static int generateId()
        {

            int id = 0;

            foreach (ClientData client in clients)
                if (client.id > id)
                    id = client.id;

            return (id + 1);
        }

        // methods
        public static void writeClients()
        {

            foreach (ClientData client in clients)
            {

                Console.WriteLine(client);
            }
        }

        public static string getClients()
        {

            return JsonConvert.SerializeObject(clients);
        }

        // file io
        public static void save()
        {

            if (File.Exists(Config.serverAccountPath) && clients.Count() != 0)
                File.WriteAllText(Config.serverAccountPath, getClients());
        }

        private static void load()
        {

            if (File.Exists(Config.serverAccountPath) && clients.Count() == 0)
                clients = JsonConvert.DeserializeObject<List<ClientData>>(File.ReadAllText(Config.serverAccountPath));
        }
    }
}

