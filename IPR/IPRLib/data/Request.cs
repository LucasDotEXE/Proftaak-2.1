using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPRLib.data
{
    public class Request
    {

        public string type;
        public Dictionary<string, dynamic> parameters;

        public static Request newRequest(string type = null)
        {

            Request request = new Request();
            request.type = type;
            request.parameters = new Dictionary<string, dynamic>();

            return request;
        }

        public dynamic get(string id)
        {

            dynamic value;

            this.parameters.TryGetValue(id, out value);

            return value;
        }

        public void add(string id, dynamic data)
        {

            this.parameters.Add(id, data);
        }

        public void clearParams()
        {

            this.parameters = new Dictionary<string, dynamic>();
        }

        public override string ToString()
        {

            return JsonConvert.SerializeObject(this);
        }
    }
}
