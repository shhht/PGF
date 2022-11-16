




namespace PGF {
        
    public class Text : OperatebleValue{
        public char[] value;

        public override string typeName {get {return "text";}}

        public override void FromString(string value) {
            FromString(value.ToCharArray());
        }

        public override void FromString(char[] value) {
            this.value = value;
        }

        public override string GetString() {
            return new string(value);
        }

        public override char[] GetCharArray() {
            return this.value;
        }

        public override object GetValue() {
            return (object) new string(value);
        }

        public override void SetValue(in Value value) {
            throw new NotImplementedException();
        }

        public Text(string value) {
            this.value = value.ToCharArray();
        }

        public Text(char[] value) {
            this.value = value;
        }

        public Text(ref char[] formula, ref int position) {
            position ++;

            List<char> newValue = new List<char>();

            while(position < formula.Length) {
                switch(formula[position]) {
                    case '"':
                        value = newValue.ToArray();
                        return;

                    case '\\':
                        if(position < formula.Length)
                            newValue.Add(this.GetSpecialChar(formula, ref position));
                        break;

                    default:
                        newValue.Add(formula[position]);
                        break;
                }
            }

            throw new MissingTextException($"Can't create text because there is no text left.");
        }

        public char GetSpecialChar(char[] formula, ref int position) {
            
            position ++;

            if(position >= formula.Length)
                throw new MissingTextException("todo");
            
            switch(formula[position]) {
                case '"':
                    return '"';

                case 'n':
                    return '\n';

                default:
                    break;
            }

            return formula[position];
        }

    }

}