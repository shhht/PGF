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
                                Expression expression = new Expression(ref contents, ref position, ref variables);
                                output += expression.GetString();
                                break;

                            default:
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

                default:
                    output += contents[position];
                    break;
            }
        }

        return output;
    }
}
