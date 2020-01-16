using RHLib.data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHLib.data
{
    public class Session
    {

        public int id { get; set; }
        public int age { get; set; }
        public int weight { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public List<Measurement> measurements { get; set; }

        public static Session newSession(int id, int age, int weigth, string name, string gender)
        {

            Session client = new Session();

            client.id = id;
            client.age = age;
            client.name = name;
            client.weight = weigth;
            client.gender = gender;
            client.measurements = new List<Measurement>();

            return client;
        }

        public override string ToString()
        {

            return JsonConvert.SerializeObject(this);
        }
    }
}
