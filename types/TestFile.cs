



namespace PGF {
        
    public class TestFile : Value {

        public string typeName {get {return "Testfile";}}

        FileStream value;
    
        public void FromString(string path) {

            value = new FileStream(path, FileMode.Open);
        }

        public void FromString(char[] path) {

            FromString(new string(path));
        }

        public string GetString() {

            return value.Name;        
        }

        public char[] GetCharArray() {
            return GetString().ToCharArray();
        }

        public void SetValue(in Value value) {
            this.value = (FileStream)(object)value;
        }

        public TestFile(string path) {
            value = new FileStream(path, FileMode.Open);
        }

    }

}