

namespace PGF {
    public class Operation : OperatebleValue {

        public override string typeName {get {return value.name;}}

        public OperationStruct value {get; private set;}

        public OperatebleValue leftArgument {get; private set;}
        public OperatebleValue rightArgument {get; private set;}


        public static OperationStruct OperationFromString(string value) {
            switch(value) {
                case "+":
                    return new Add();
                
                case "-":
                    return new Subtract();

                case "*":
                    return new Multiply();

                case "/":
                    return new Devide();

                case "%":
                    return new Modulus();
                
                case "==":
                    return new DoesEquals();
                
                case "!=":
                    return new DoesNotEqual();

                case ">":
                    return new GreaterThan();

                case "<":
                    return new LessThan();

                case ">=":
                    return new GreaterThanOrEqual();

                case "<=":
                    return new LessThanOrEqual();

                case "||":
                    return new Or();

                case "&&":
                    return new And();

                default:
                    throw new OperationNotFoundException($"The operation \"{value}\" is not a valid operation");
            }
        }

        public override void FromString(string value) {
            this.value = OperationFromString(value);
        }

        public override void FromString(char[] value) {
            this.FromString(new string(value));
        }

        public override string GetString() {
            return value.name;
        }

        public override char[] GetCharArray() {
            return value.name.ToCharArray();
        }

        public override void SetValue(in Value value) {
            throw new NotImplementedException();
        }

        public Operation(OperationStruct value, OperatebleValue leftArgument, OperatebleValue rightArgument) {
            this.value = value;

            this.leftArgument = leftArgument;
            this.rightArgument = rightArgument;
        }
        
        
        public Operation(string value, OperatebleValue leftArgument, OperatebleValue rightArgument) {
            this.value = new NullOperator();

            FromString(value);

            this.leftArgument = leftArgument;
            this.rightArgument = rightArgument;
        }

        public override object GetValue()
        {
            return (object)value;
        }

        public override OperatebleValue GetOutputValue () {
            return value.Operation(leftArgument, rightArgument);
        }

        private OperatebleValue GetValueValue()
        {
            return value.Operation(rightArgument, leftArgument);
        }

        public override Integer ConvertToInteger()
        {
            return GetValueValue().ConvertToInteger();
        }

        public override Float ConvertToFloat()
        {
            return GetValueValue().ConvertToFloat();
        }

        public override Boolean ConvertToBoolean()
        {
            return GetValueValue().ConvertToBoolean();
        }


        public override Text ConvertToText()
        {
            return GetValueValue().ConvertToText();
        }

        public override OperatebleValue Add(in OperatebleValue otherValue)
        {
            return GetValueValue().Add(otherValue);
        }
        
        public override OperatebleValue Subtract(in OperatebleValue otherValue)
        {
            return GetValueValue().Subtract(otherValue);
        }
        
        public override OperatebleValue Multiply(in OperatebleValue otherValue)
        {
            return GetValueValue().Multiply(otherValue);
        }
        
        public override OperatebleValue Devide(in OperatebleValue otherValue)
        {
            return GetValueValue().Devide(otherValue);
        }
        
        public override OperatebleValue Modulus(in OperatebleValue otherValue)
        {
            return GetValueValue().Modulus(otherValue);
        }

        public override OperatebleValue GreaterThan(in OperatebleValue otherValue)
        {
            return GetValueValue().GreaterThan(otherValue);
        }
        
        public override OperatebleValue LessThan(in OperatebleValue otherValue)
        {
            return GetValueValue().LessThan(otherValue);
        }
        
        public override OperatebleValue GreaterThanOrEqual(in OperatebleValue otherValue)
        {
            return GetValueValue().GreaterThanOrEqual(otherValue);
        }
        
        public override OperatebleValue LessThanOrEqual(in OperatebleValue otherValue)
        {
            return GetValueValue().LessThanOrEqual(otherValue);
        }

        public override OperatebleValue Or(in OperatebleValue otherValue)
        {
            return GetValueValue().Or(in otherValue);
        }

        public override OperatebleValue And(in OperatebleValue otherValue)
        {
            return GetValueValue().Or(in otherValue);
        }
    }

}