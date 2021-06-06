using System;

namespace bands_repository_csharp.Services
{
    public class Validations
    {
        public void WaitPressKey()
        {
            Console.WriteLine("Press a key to return.");
            Console.ReadKey();
        }
    }
}