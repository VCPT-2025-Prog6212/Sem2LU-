using System.Reflection;

namespace Reflection_App_Console_G1
{
    //Reflection is a powerful feature in .Net that allows for developers to 
    //inspect & manipulate the metadata of the assemblies at runtime
     class Program
    {
        static string path = "C:\\Users\\user\\Documents\\PROG6212\\PROG6212-Group1-2024-main\\Reflection_App_Console_G1\\Reflection_App_Console_G1\\bin\\Debug\\net8.0\\Reflection_App_Console_G1.dll";
        static void Main(string[] args)
        {
            try 
            { 
                //load the assembly from the specified path using the LoadFile method
                Assembly assembly = Assembly.LoadFile(path);

                //Types: Classes, interfaces, enums, structs & delegates
                //that will hold metadata
                //This can be used to generate objects/instances with members
                Type[] types = assembly.GetTypes();
                foreach (Type t in types) {
                    Console.WriteLine("");
                    Console.WriteLine("TYPE: " + t.FullName);

                    //Members of the project/dll
                    //Members: methods, properties, fields, events, constructors, nested types
                    MethodInfo[] methods = t.GetMethods();
                    foreach (MethodInfo m in methods) 
                    {
                        Console.WriteLine("Methods: " + m.Name);

                        //Shows the parameters to methods & its data-type
                        ParameterInfo[] parameters = m.GetParameters();
                        foreach (ParameterInfo p in parameters) 
                        {
                            Console.WriteLine("Parameter: " + p.Name + ", Type: " + p.ParameterType);
                        }
                    }
                    //Display properties
                    PropertyInfo[] properties = t.GetProperties();
                    foreach (PropertyInfo p in properties) 
                    {
                        Console.WriteLine("Property: " + p.Name + ", Type: " + p.PropertyType);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
