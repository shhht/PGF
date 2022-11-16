using PGF;

public static class Program {

    public static void Main(string[] args) {
        Variables variables = new Variables();
        string? path;

        if (args.Length == 0) {
            Console.WriteLine("Enter the path of the file:");
            path = Console.ReadLine();
        }
        else
            path = args[0];

        if (path is null)
            throw new Exception("No path specified to PGF file");

        var file = new pgfFile(path);
        Console.WriteLine(file.parse());
    }
}
