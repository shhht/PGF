



namespace PGF {
        
    public interface Value {


        

        public abstract string typeName {get;}

        public abstract void FromString(string value);
        public abstract void FromString(char[] value);

        public abstract string GetString();
        public abstract char[] GetCharArray();

        public Value GetValue() {
            return this;
        }

        public void SetValue(in Value value);

        public bool Equals(in Value otherValue) {
            return this.GetValue() == otherValue.GetValue();
        }
    }

}