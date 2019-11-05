using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRClient.client.model
{

    static class InputChecker
    {

        public static string error;

        // create session
        public static bool checkSessionInput(int age, int weight, string name, string gender)
        {

            return (age != -1 && weight != -1 && name != null && gender != null);
        }

        public static int checkAge(string ageString)
        {

            try
            {

                int age = Convert.ToInt32(ageString);

                if (age < 0 || age > 125)
                    error = "Inpossible age";
                else
                    return age;
            }
            catch (Exception ignored)
            {

                error = "Age is not a number";
            }

            return -1;
        }

        public static int checkWeight(string weigthString)
        {

            try
            {

                int  weigth = Convert.ToInt32(weigthString);

                if (weigth < 0 || weigth > 500)
                    error = "Impossible weight";
                else
                    return weigth;
            }
            catch (Exception ignored)
            {

                error = "Weight is not a number";
            }

            return -1;
        }

        public static string checkName(string name)
        {

            if (name.Length > 20 || name.Length < 1)
                error = "Name is incorrect (longer than 0 shorter than 20)";
            else
                return name;

            return null;
        }

        public static string checkGender(string gender)
        {

            if (gender.Length > 20 || gender.Length < 1)
                error = "Gender is incorrect (longer than 0 shorter than 20)";
            else
                return gender;

            return null;
        }
    }
}
