



namespace PGF {
        
    public class Variable : OperatebleValue {

        int variableType;
        public override string typeName {get {return "Variable";}}
        Value value;
        public string name {get; init;}

        public Variable(string name, Value value) {
            this.name = name;
            this.value = value;
        }

        public override void FromString(string value) {
            this.value.FromString(value);
        }

        public override void FromString(char[] value) {
            this.value.FromString(value);
        }

        public override string GetString() {
            return value.GetString();
        }

        public override char[] GetCharArray() {
            return value.GetCharArray();
        }

        public override void SetValue(in Value value) {
            throw new NotImplementedException("SetValue(in Value) is not meant to be used.");
        }

        public override object GetValue()
        {
            return value;
        }

        public ref Value GetRefValue() {
            return ref value;
        }
    }

}