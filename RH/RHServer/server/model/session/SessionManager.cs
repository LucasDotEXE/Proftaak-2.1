using Newtonsoft.Json;
using RHLib.data;
using RHLib.helper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace RHServer.server.model.account
{

    class SessionManager
    {

        // attributes
        private static SessionManager instance;

        private List<Session> sessions = new List<Session>();
        private bool isSaving = false;

        // instance
        private SessionManager()
        {

            this.load();
        }

        public static SessionManager getInstance()
        {

            if (instance == null)
                instance = new SessionManager();

            return instance;
        }

        // login
        public Session createSession(int age, int weigth, string name, string gender)
        {

            Session clientData = Session.newSession(generateId(), age, weigth, name, gender);

            sessions.Add(clientData);

            save();

            return clientData;
        }

        private int generateId()
        {

            int id = 0;

            foreach (Session client in sessions)
                if (client.id > id)
                    id = client.id;

            return (id + 1);
        }

        // methods
        public List<string[]> getSessionNames()
        {

            List<string[]> names = new List<string[]>();

            foreach (Session session in sessions)
                names.Add(new string[2] { session.name, session.id.ToString() });

            return names;
        }

        public Session getById(int id)
        {

            foreach (Session session in sessions)
                if (id == session.id)
                    return session;

            return null;
        }

        // file io
        public void save()
        {

            if (File.Exists(Config.serverAccountPath) && sessions.Count() != 0 && !this.isSaving)
            {

                this.isSaving = true;
                new Thread(new ThreadStart(this.saving)).Start();
            }    
        }

        private void saving()
        {

            File.WriteAllText(Config.serverAccountPath, JsonConvert.SerializeObject(sessions));
            this.isSaving = false;
        }

        private void load()
        {

            if (File.Exists(Config.serverAccountPath) && sessions.Count() == 0)
                sessions = JsonConvert.DeserializeObject<List<Session>>(File.ReadAllText(Config.serverAccountPath));
        }

        public void addVO2ToSession(Session session)
        {

            double workload = this.getWorkLoad(session);
            double bpm = -1;

            foreach (Measurement measurement in session.measurements)
            {

                if (measurement.bpm != -1)
                    bpm = measurement.bpm;

                if (bpm != -1)
                    if (session.gender == "Female")
                        measurement.vo2 = ((0.00212 * workload + 0.299) / (0.769 * measurement.bpm - 48.5) * 100) * this.correction(session.age);
                    else
                        measurement.vo2 = ((0.00193 * workload + 0.326) / (0.769 * measurement.bpm - 56.1) * 100) * this.correction(session.age);
            }
        }

        private double getWorkLoad(Session session)
        {

            double power = -1;
            double workload = 0;

            foreach (Measurement measurement in session.measurements)
            {

                if (measurement.currentPower != -1)
                    power = measurement.currentPower;

                if (power != -1)
                    workload += power;
            }
            
            return ((workload / session.measurements.Count()) * 6.12);
        }

        private double correction(int age)
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

