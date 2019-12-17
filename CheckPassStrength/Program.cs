using System;

namespace CheckPassStrength
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\t\tVERIFICADOR SENHA FORTE\r\nDIGITE A SENHA: ");

            var key = Console.ReadLine();

            var checkPass = new CheckPass();

            var score = checkPass.GeneratePointPass(key);
            var strength = checkPass.GetStrengthPass(key);

            Console.WriteLine("Senha {0} - Pontos {1}", strength, score);
        }
    }
}
