using IPRLib.data;
using IPRLib.helper;
using IPRServer.server.model.client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRServer.server.model.account
{

    class SessionManager
    {

        // attributes
        private static List<Session> sessions = new List<Session>();

        
        // login
        public static Session createSession(int age, int weigth, string name, string gender)
        {

            load();

            Session clientData = Session.newSession(generateId(), age, weigth, name, gender);

            sessions.Add(clientData);

            save();

            return clientData;
        }

        private static int generateId()
        {

            int id = 0;

            foreach (Session client in sessions)
                if (client.id > id)
                    id = client.id;

            return (id + 1);
        }

        // methods
        public static List<string[]> getSessionNames()
        {

            load();

            List<string[]> names = new List<string[]>();

            foreach (Session session in sessions)
                names.Add(new string[2] { session.name, session.id.ToString() });

            return names;
        }

        public static Session getById(int id)
        {

            foreach (Session session in sessions)
                if (id == session.id)
                    return session;

            return null;
        }

        // file io
        public static void save()
        {

            if (File.Exists(Config.serverAccountPath) && sessions.Count() != 0)
                File.WriteAllText(Config.serverAccountPath, JsonConvert.SerializeObject(sessions));
        }

        private static void load()
        {

            if (File.Exists(Config.serverAccountPath) && sessions.Count() == 0)
                sessions = JsonConvert.DeserializeObject<List<Session>>(File.ReadAllText(Config.serverAccountPath));
        }

        public static void addVO2ToSession(Session session)
        {

            double workload = 0;
            foreach (Measurement measurement in session.measurements)
                workload += measurement.currentPower;

            workload /= session.measurements.Count();
            workload *= 6.12;

            foreach (Measurement measurement in session.measurements)
                if (session.gender == "Female")
                    measurement.vo2 = ((0.00212 * workload + 0.299) / (0.769 * measurement.bpm - 48.5) * 100) * correction(session.age);
                else
                    measurement.vo2 = ((0.00193 * workload + 0.326) / (0.769 * measurement.bpm - 56.1) * 100) * correction(session.age);
        }

        private static double correction(int age)
        {

            if (age <= 15) return 1.1 + (15 - age) * 0.01;
            else if (age <= 25) return 1.0 + (25 - age) * 0.01;
            else if (age <= 35) return 0.87 + (35 - age) * (0.013);
            else if (age <= 40) return 0.83 + (40 - age) * 0.008;
            else if (age <= 45) return 0.78 + (45 - age) * 0.01;
            else if (age <= 50) return 0.75 + (50 - age) * 0.006;
            else if (age <= 55) return 0.71 + (55 - age) * 0.008;
            else if (age <= 60) return 0.68 + (60 - age) * 0.006;
            else if (age <= 65) return 0.65 + (65 - age) * 0.006;
            else return 0.65 - (age - 65) * 0.006;
        }
    }
}

