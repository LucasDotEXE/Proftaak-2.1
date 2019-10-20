using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RHLib.data
{
    public class Request
    {

        public string type;
        public List<Tuple<string, dynamic>> parameters;

        public static Request newRequest(string type = null)
        {

            Request request = new Request();
            request.type = type;
            request.parameters = new List<Tuple<string, dynamic>>();

            return request;
        }

        public dynamic get(string id)
        {

            foreach (Tuple<string, dynamic> parameter in this.parameters)
                if (parameter.Item1 == id)
                    return parameter.Item2;

            return null;
        }

        public void add(string id, dynamic data)
        {

            this.parameters.Add(new Tuple<string, dynamic>(id, data));
        }

        public void clearParams()
        {

            this.parameters = new List<Tuple<string, dynamic>>();
        }

        public override string ToString()
        {

            return JsonConvert.SerializeObject(this);
        }
    }
}
