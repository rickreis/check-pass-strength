using System;
using System.Text.RegularExpressions;

namespace CheckPassStrength
{
    public class CheckPass
    {
        public int GeneratePointPass(string pass)
        {
            if (pass == null) return 0;

            return GetPointsLength(pass) + GetPointsLowerCase(pass) + GetPointsUpperCase(pass) + GetPointsDigits(pass) + GetPointsSimbols(pass) - GetPointsRepete(pass);
        }

        private int GetPointsLength(string pass) => Math.Min(10, pass.Length) * 7;

        private int GetPointsLowerCase(string pass)
        {
            int raw = pass.Length - Regex.Replace(pass, "[a-z]", "").Length;
            return Math.Min(2, raw) * 5;
        }

        private int GetPointsUpperCase(string pass)
        {
            int raw = pass.Length - Regex.Replace(pass, "[A-Z]", "").Length;
            return Math.Min(2, raw) * 5;
        }

        private int GetPointsDigits(string pass)
        {
            int raw = pass.Length - Regex.Replace(pass, "[0-9]", "").Length;
            return Math.Min(2, raw) * 6;
        }

        private int GetPointsSimbols(string pass)
        {
            int raw = Regex.Replace(pass, "[a-zA-Z0-9]", "").Length;
            return Math.Min(2, raw) * 5;
        }

        private int GetPointsRepete(string pass)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(\w)*.*\1");

            bool repete = regex.IsMatch(pass);

            return repete ? 30 : 0;
        }


        public StrengthPass GetStrengthPass(string pass)
        {
            int result = GeneratePointPass(pass);

            if (result < 50)
                return StrengthPass.Inaceitavel;
            else if (result < 60)
                return StrengthPass.Fraca;
            else if (result < 80)
                return StrengthPass.Aceitavel;
            else if (result < 100)
                return StrengthPass.Forte;
            else
                return StrengthPass.Segura;
        }
    }

    public enum StrengthPass
    {
        Inaceitavel,
        Fraca,
        Aceitavel,
        Forte,
        Segura
    }
}
