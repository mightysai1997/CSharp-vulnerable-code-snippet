using System;
using System.Security.Cryptography;

class ExampleClass
{
    public void ExampleMethod(int toExclusive)
    {
        var sensitiveVariable = RandomNumberGenerator.GetInt32(toExclusive);
    }
}
