using System.Reflection;

namespace DynamicLinkDemo.App;

public class Program
{
    static void Main(string[] args)
    {
        var path1 = @"P:\DynamicLinkDemo\DynamicLinkDemo.App\Lib\Lib1\DynamicLinkDemo.Lib1.dll";
        var path2 = @"P:\DynamicLinkDemo\DynamicLinkDemo.App\Lib\Lib2\DynamicLinkDemo.Lib2.dll";

        Assembly assembly;
        var parameters = new List<object>();
        var lib = "";

        if (args.Length == 0)
        {
            Console.WriteLine("ERROR");
            return;
        }
        
        switch (args[0])
        {
            case "lib1":
                assembly = Assembly.LoadFrom(path1);
                parameters.Add(Convert.ToInt32(args[1]));
                parameters.Add(Convert.ToInt32(args[2]));
                lib = "Lib1";
                break;
            case "lib2":
                assembly = Assembly.LoadFrom(path2);
                parameters.Add(Convert.ToInt32(args[1]));
                parameters.Add(Convert.ToInt32(args[2]));
                parameters.Add(Convert.ToInt32(args[3]));
                lib = "Lib2";
                break;
            default:
                Console.WriteLine("ERROR");
                return;
        }
        
        // DEBUG
        /*foreach (var p in parameters)
        {
            Console.Write($"{p} ");
        }
        Console.WriteLine();*/
        //

        // DEBUG
        /*foreach (var t in assembly.GetTypes())
        {
            Console.WriteLine(t.FullName);
        }*/
        //
        
        var type = assembly.GetType($"DynamicLinkDemo.{lib}.Calculator");
        
        // DEBUG
        /*Console.WriteLine(type.FullName);
        Console.WriteLine(type.IsClass);
        Console.WriteLine(type.IsAutoClass);*/
        //
        
        // DEBUG
        /*foreach (var m in type.GetMethods())
        {
            Console.WriteLine(m.Name);
        }*/
        //
        
        var add = type?.GetMethod("Add");
        if (add != null)
        {
            // DEBUG
            /*Console.WriteLine(add.GetParameters().Length);*/
            //
            
            var result = add.Invoke(null, parameters: parameters.ToArray());

            Console.Write("Add(");
            foreach (var parameter in parameters)
            {
                Console.Write($"{parameter} ");
            }
            Console.WriteLine($") = {result}");
        }
    }
}