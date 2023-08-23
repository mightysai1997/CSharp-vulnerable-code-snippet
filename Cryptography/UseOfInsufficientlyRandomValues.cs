using System;

class Program
{
    static void Main()
    {
        var random = new Random();             // Sensitive use of Random
        byte[] data = new byte[16];
        random.NextBytes(data);
        return BitConverter.ToString(data);   
    }
}
