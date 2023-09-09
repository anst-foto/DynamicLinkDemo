namespace DynamicLinkDemo.App_;

public class Program
{
    static void Main(string[] args)
    {
        var parameters = new List<int>();

        if (args.Length == 0)
        {
            Console.WriteLine("ERROR");
            return;
        }

        int lib;
        
        switch (args[0])
        {
            case "lib1":
                parameters.Add(Convert.ToInt32(args[1]));
                parameters.Add(Convert.ToInt32(args[2]));
                lib = 1;
                break;
            case "lib2":
                parameters.Add(Convert.ToInt32(args[1]));
                parameters.Add(Convert.ToInt32(args[2]));
                parameters.Add(Convert.ToInt32(args[3]));
                lib = 2;
                break;
            default:
                Console.WriteLine("ERROR");
                return;
        }

        var result = lib switch
        {
            1 => Lib1.Calculator.Add(parameters[0], parameters[1]),
            2 => Lib2.Calculator.Add(parameters[0], parameters[1], parameters[2])
        };
        
        Console.Write("Add(");
        foreach (var parameter in parameters)
        {
            Console.Write($"{parameter} ");
        }
        Console.WriteLine($") = {result}");
    }
}