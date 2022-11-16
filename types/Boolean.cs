


namespace PGF {
    public class Boolean : OperatebleValue{

        bool value;
        public override string typeName {get {return "boolean";}}

        public override void FromString(string value) {
            switch(value) {
                case "true": case "TRUE":
                    this.value = true;
                    return;

                case "false": case "FALSE":
                    this.value = false;
                    return;

                default:
                    throw new WrongArgumentException($"The value \"{value}\" is not a boolean.");
            }
        }

        public override void FromString(char[] value)
        {
            this.FromString(new string(value));
        }

        public override string GetString()
        {
            return value.ToString();
        }

        public override char[] GetCharArray()
        {
            return this.GetString().ToCharArray();
        }

        public override object GetValue()
        {
            return value;
        }

        public Boolean(bool value) {
            this.value = value;
        }

        public override void SetValue(in Value value) {

        }

        public override OperatebleValue Or(in OperatebleValue otherValue)
        {
            return new Boolean(value || otherValue.ConvertToBoolean().value);
        }

        public override OperatebleValue And(in OperatebleValue otherValue)
        {
            return new Boolean(value && otherValue.ConvertToBoolean().value);
        }
    }

}