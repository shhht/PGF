using System.IO;
using PGF;

public static class Program{

    public static void Main(string[] args) {
        

        Variables variables = new Variables();
        Console.Clear();
        string? formula = Console.ReadLine();

        if(formula is null)
            return;

        char[] charFormula = formula.ToCharArray();

        int position = 0;
        Expression expression = new Expression(ref charFormula, ref position, ref variables);
        
        Console.WriteLine();
        Console.WriteLine(expression.GetString());
        Console.WriteLine();
    }
}