using PGF;

public class pgfFile {
    char[] contents;

    public pgfFile(string path) {
        contents = File.ReadAllText(path).ToCharArray();
    }

    public string parse() {
        Variables variables = new Variables();
        if (contents is null)
            throw new Exception("File contents do not exist");
        string output = "";

        uint line = 0;
        uint minusCharacters = 0;

        for (int position = 0; position < contents.Length; position++) {
            switch (contents[position]) {
                case '#':
                    position++;

                    while (position < contents.Length) {
                        switch (contents[position]) {
                            case ' ':
                            case '\t':
                                position++;
                                continue;

                            case '(':
                                position++;
                                Expression expression;
                                try {
                                    expression = new Expression(ref contents, ref position, ref variables);
                                    
                                    output += expression.GetString() + contents[position];
                                
                                } catch(Exception exception) {

                                    string errorContents = "";

                                    for(int i = position - 5; i < position; i ++) {
                                        if(i >= 0 && contents[i] != '\n')
                                            errorContents += contents[i];
                                    }
                                    Console.WriteLine($"A error hase accured at line: {line}, chacater: {position + 1 - (int)minusCharacters}. \"{errorContents}\" <===!)");
                                    Console.WriteLine($"[error message] {exception.Message}\n");
                                }

                                break;


                            case '\n':
                                line ++;
                                output += '\n';
                                minusCharacters = (uint)position;
                                break;

                            default:
                                output += contents[position];
                                position++;
                                break;
                        }

                        break;
                    }

                    break;

                case '\\':
                    position++;
                    if (position < contents.Length)
                        output += contents[position];

                    break;

                case '\n':
                    line ++;
                    output += '\n';
                    minusCharacters = (uint)position;
                    break;

                default:
                    output += contents[position];
                    break;
            }
        }

        return output;
    }
}
