using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace DrRobo.Utils
{
    public class Util
    {
        public static T GetResource<T>(string resource)
        {
            if(Application.Current.Resources.TryGetValue(resource, out var obj))
                return (T)obj;

            return default(T);
        }

        public static bool ValidateCPF(string cpf)
        {
            if (cpf == null)
                return false;

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (string.IsNullOrEmpty(cpf))
                return false;

            int d1, d2;
            int sum = 0;
            string typed = "";
            string calculated = "";

            int[] weightOne = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] weightTwo = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] number = new int[11];

            if (cpf.Length != 11)
                return false;

            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            try
            {
                number[0] = Convert.ToInt32(cpf.Substring(0, 1));
                number[1] = Convert.ToInt32(cpf.Substring(1, 1));
                number[2] = Convert.ToInt32(cpf.Substring(2, 1));
                number[3] = Convert.ToInt32(cpf.Substring(3, 1));
                number[4] = Convert.ToInt32(cpf.Substring(4, 1));
                number[5] = Convert.ToInt32(cpf.Substring(5, 1));
                number[6] = Convert.ToInt32(cpf.Substring(6, 1));
                number[7] = Convert.ToInt32(cpf.Substring(7, 1));
                number[8] = Convert.ToInt32(cpf.Substring(8, 1));
                number[9] = Convert.ToInt32(cpf.Substring(9, 1));
                number[10] = Convert.ToInt32(cpf.Substring(10, 1));
            }
            catch
            {
                return false;
            }

            for (int i = 0; i <= weightOne.GetUpperBound(0); i++)
                sum += (weightOne[i] * Convert.ToInt32(number[i]));

            int rest = sum % 11;

            if (rest == 1 || rest == 0)
                d1 = 0;
            else
                d1 = 11 - rest;

            sum = 0;

            for (int i = 0; i <= weightTwo.GetUpperBound(0); i++)
                sum += (weightTwo[i] * Convert.ToInt32(number[i]));

            rest = sum % 11;
            if (rest == 1 || rest == 0)
                d2 = 0;
            else
                d2 = 11 - rest;

            calculated = d1.ToString() + d2.ToString();
            typed = number[9].ToString() + number[10].ToString();

            if (calculated == typed)
                return true;

            return false;
        }

        public bool ValidateEmail(string email)
        {
            Regex _email = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (_email.IsMatch(email))
                return true;

            return false;
        }

        public bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            if (new Regex(@"[0-9]").Match(name).Success)
                return true;

            if (new Regex(@"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""""_-]").Match(name).Success)
                return true;

            return false;
        }

        public static string ReplaceCPF(string cpf)
        {
           return cpf.Replace(".", "").Replace("-", "");
        }
    }
}