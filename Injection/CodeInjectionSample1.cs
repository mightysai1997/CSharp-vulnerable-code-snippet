using System;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

class Program
{
    static void Main()
    {
        Console.Write("Enter a class name: ");
        string className = Console.ReadLine();

        string maliciousCode = @"
            using System;
            namespace MaliciousCode
            {
                class " + className + @"
                {
                    public static void MaliciousMethod()
                    {
                        Console.WriteLine(""Malicious method executed!"");
                    }
                }
            }";

        CSharpCodeProvider provider = new CSharpCodeProvider();
        CompilerParameters parameters = new CompilerParameters();
        parameters.GenerateExecutable = false;
        parameters.GenerateInMemory = true;

        CompilerResults results = provider.CompileAssemblyFromSource(parameters, maliciousCode);

        if (!results.Errors.HasErrors)
        {
            Type type = results.CompiledAssembly.GetType("MaliciousCode." + className);
            var method = type.GetMethod("MaliciousMethod");
            method.Invoke(null, null);
        }
        else
        {
            Console.WriteLine("Code compilation failed:");
            foreach (CompilerError error in results.Errors)
            {
                Console.WriteLine(error.ErrorText);
            }
        }
    }
}
