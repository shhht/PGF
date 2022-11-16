

namespace PGF {

    public class Float : OperatebleValue {

        public float value;

        public override string typeName {get {return "float";}}



        public override void FromString(string value) { 
            this.value = float.Parse(value);
        }

        public override void FromString(char[] value) {
            FromString(new string(value));
        }

        public override string GetString()
        {
            return value.ToString();
        }

        public override char[] GetCharArray() {
            return value.ToString().ToCharArray();
        }

        public override void SetValue(in Value value)
        {
            throw new NotImplementedException();
        }

        public override object GetValue()   
        {
            return (object)value;
        }

        public Float(float value) {
            this.value = value;
        }

        public Float(char[] value) {
            this.value = float.Parse(new string(value));
        }

        public Float(string value) {
            this.value = float.Parse(value);
        }


        public override OperatebleValue Add(in OperatebleValue otherValue)
        {
            return new Float(this.value + otherValue.ConvertToFloat().value);
        }

        public override OperatebleValue Subtract(in OperatebleValue otherValue)
        {
            return new Float(this.value - otherValue.ConvertToFloat().value);
        }

        public override OperatebleValue Multiply(in OperatebleValue otherValue)
        {
            return new Float(this.value * otherValue.ConvertToFloat().value);
        }

        public override OperatebleValue Devide(in OperatebleValue otherValue)
        {
            return new Float(this.value / otherValue.ConvertToFloat().value);
        }

        public override OperatebleValue Modulus(in OperatebleValue otherValue)
        {
            return new Float(this.value % otherValue.ConvertToFloat().value);
        }

        public override OperatebleValue GreaterThan(in OperatebleValue otherValue)
        {
            return new Boolean(this.value > otherValue.ConvertToFloat().value);
        }

        public override OperatebleValue LessThan(in OperatebleValue otherValue)
        {
            return new Boolean(this.value < otherValue.ConvertToFloat().value);
        }

        public override OperatebleValue GreaterThanOrEqual(in OperatebleValue otherValue)
        {
            return new Boolean(this.value >= otherValue.ConvertToFloat().value);
        }

        public override OperatebleValue LessThanOrEqual(in OperatebleValue otherValue)
        {
            return new Boolean(this.value <= otherValue.ConvertToFloat().value);
        }

        public override Float ConvertToFloat()
        {
            return this;
        }
    }

}