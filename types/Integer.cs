



namespace PGF {

    public class Integer : OperatebleValue {

        int value;
        public override string typeName {get {return "integer";}}

        public override void FromString(string value) {
            this.value = int.Parse(value);
        }

        public override void FromString(char[] value)
        {
            int.TryParse(new String(value), out this.value);
        }

        public override string GetString()
        {
            return value.ToString();
        }

        public override char[] GetCharArray()
        {
            return value.ToString().ToCharArray();
        }

        public override object GetValue()
        {
            return value;
        }

        public Integer(int value) {
            this.value = value;
        }

        public override OperatebleValue Add(in OperatebleValue otherValue)
        {
            return new Integer(this.value + otherValue.ConvertToInteger().value);
        }

        public override OperatebleValue Subtract(in OperatebleValue otherValue)
        {
            return new Integer(this.value - otherValue.ConvertToInteger().value);
        }

        public override OperatebleValue Multiply(in OperatebleValue otherValue)
        {
            return new Integer(this.value * otherValue.ConvertToInteger().value);
        }

        public override OperatebleValue Devide(in OperatebleValue otherValue)
        {
            return new Float(this.value / otherValue.ConvertToFloat().value);
        }

        public override OperatebleValue Modulus(in OperatebleValue otherValue)
        {
            return new Integer(this.value % otherValue.ConvertToInteger().value);
        }

        public override OperatebleValue GreaterThan(in OperatebleValue otherValue)
        {
            return new Boolean(this.value > otherValue.ConvertToInteger().value);
        }

        public override OperatebleValue LessThan(in OperatebleValue otherValue)
        {
            return new Boolean(this.value < otherValue.ConvertToInteger().value);
        }

        public override OperatebleValue GreaterThanOrEqual(in OperatebleValue otherValue)
        {
            return new Boolean(this.value >= otherValue.ConvertToInteger().value);
        }

        public override OperatebleValue LessThanOrEqual(in OperatebleValue otherValue)
        {
            return new Boolean(this.value <= otherValue.ConvertToInteger().value);
        }

        public override void SetValue(in Value value)
        {
            throw new NotImplementedException();
        }

        public override Integer ConvertToInteger()
        {
            return this;
        }
    }

}