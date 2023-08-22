using System;
using Microsoft.Extensions.Configuration;
using RazorLight;

namespace SSTIExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a template expression: ");
            string templateExpression = Console.ReadLine();

            string template = $"Hello, @(Model.{templateExpression})!";
            string result = RenderTemplate(template, new { Name = "User" });

            Console.WriteLine("Rendered template:");
            Console.WriteLine(result);
        }

        static string RenderTemplate(string template, object model)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().Build();
            IRazorLightEngine engine = EngineFactory.CreatePhysical(configuration);
            
            return engine.CompileRenderAsync("templateKey", template, model).Result;
        }
    }
}
