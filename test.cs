using System;
using System.Xml;

class Program
{
    static void Main()
    {
        // Create an XmlDocument
        XmlDocument doc = new XmlDocument();

        // Create the XML declaration
        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
        doc.AppendChild(xmlDeclaration);

        // Create the root element <configuration>
        XmlElement configurationElement = doc.CreateElement("configuration");
        doc.AppendChild(configurationElement);

        // Create the <system.web> element
        XmlElement systemWebElement = doc.CreateElement("system.web");
        configurationElement.AppendChild(systemWebElement);

        // Create the <compilation> element with attributes
        XmlElement compilationElement = doc.CreateElement("compilation");
        compilationElement.SetAttribute("defaultLanguage", "c#");

        #if DEBUG
            // Log the fact that we are in debug mode (you can add more sophisticated logging)
            Console.WriteLine("Application is running in debug mode. Ensure sensitive information is handled appropriately.");
            compilationElement.SetAttribute("debug", "true");
        #else
            // In release mode, do not include debug information
            compilationElement.SetAttribute("debug", "false");
        #endif

        systemWebElement.AppendChild(compilationElement);

        // Add more elements or attributes as needed

        // Save the XmlDocument to a file or use it as needed
        doc.Save("web.config");

        Console.WriteLine("web.config file generated successfully.");
    }
}
