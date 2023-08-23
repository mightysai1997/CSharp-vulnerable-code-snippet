public static unsafe int? InjectAndRunX86ASM(this Func<int> del, byte[] asm)
{
    if (del != null)
    {
        fixed (byte* ptr = &asm[0])
        {
            FieldInfo _methodPtr = typeof(Delegate).GetField("_methodPtr", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo _methodPtrAux = typeof(Delegate).GetField("_methodPtrAux", BindingFlags.NonPublic | BindingFlags.Instance);

            _methodPtr.SetValue(del, ptr);
            _methodPtrAux.SetValue(del, ptr);

            return del();using System.CodeDom.Compiler;

public class ExampleController : Controller
{
    public void Run(string message)
    {
        const string code = @"
            using System;
            public class MyClass
            {
                public void MyMethod()
                {
                    Console.WriteLine(""" + message + @""");
                }
            }
        ";

        var provider = CodeDomProvider.CreateProvider("CSharp");
        var compilerParameters = new CompilerParameters { ReferencedAssemblies = { "System.dll", "System.Runtime.dll" } };
        var compilerResults = provider.CompileAssemblyFromSource(compilerParameters, code);
        object myInstance = compilerResults.CompiledAssembly.CreateInstance("MyClass");
        myInstance.GetType().GetMethod("MyMethod").Invoke(myInstance, new object[0]);
    }
}
        }
    }
    else
    {
        return null;
    }
}
