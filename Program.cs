using System.IO;
using PGF;

public static class Program{

    public static void Main(string[] args) {
        

        Variables variables = new Variables();
        Console.Clear();
        Console.WriteLine("Enter the path of the file:");
        string? path = Console.ReadLine();
        if(path is null)
            return;

        string formula = File.ReadAllText(path);


        char[] charFormula = formula.ToCharArray();

        int position = 0;
        
        string output = "";
        

        while(position < charFormula.Length) {
            switch(charFormula[position]) {
                case '#':
                    position ++;

                    while(position < charFormula.Length) {
                        switch(charFormula[position]) {
                            case ' ': case '\t':
                                position ++;
                                continue;

                            case '(':
                                position ++;
                                Expression expression = new Expression(ref charFormula, ref position, ref variables);
                                output += expression.GetString();
                                break;

                            default:
                                position ++;
                                break;
                        }

                        break;
                    }

                    break;

                case '\\':
                    position ++;
                    if(position < charFormula.Length)
                        output += charFormula[position];

                    break;

                default:
                    output += charFormula[position];
                    break;
            }

            position ++;
        }


        Console.WriteLine();
        Console.WriteLine(output);
        Console.WriteLine();
    }
}