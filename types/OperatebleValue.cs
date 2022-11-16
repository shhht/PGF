



namespace PGF {
        
    public abstract class OperatebleValue : Value {

        public delegate Value Method(in Value otherValue);
        public virtual string typeName {get {throw new NotImplementedException($"Base value type \"{this.GetType()}\" dit not implement a type name.");}}

        public Type thisType {get {return this.GetType();}}

        public abstract void FromString(string value);
        public abstract void FromString(char[] value);

        public abstract string GetString();
        public abstract char[] GetCharArray();

        public virtual OperatebleValue GetOperatebleValue() {
            return this;
        }

        public virtual OperatebleValue Add(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation add (+).");
        }

        public virtual OperatebleValue Subtract(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation subtract (-).");
        }

        public virtual OperatebleValue Multiply(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation multiply (*).");
        }

        public virtual OperatebleValue Devide(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation devide (/).");
        }

        public virtual OperatebleValue Modulus(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation mod (%).");
        }

        public virtual OperatebleValue GreaterThan(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation greater than (>).");
        }

        public virtual OperatebleValue LessThan(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation less than (<).");
        }

        public virtual OperatebleValue GreaterThanOrEqual(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation greater than or equal (>=).");
        }

        public virtual OperatebleValue LessThanOrEqual(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation equals (<=).");
        }

        public virtual OperatebleValue Or(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation or (||).");
        }

        public virtual OperatebleValue And(in OperatebleValue otherValue) {
            throw new WrongArgumentException($"The value type \"{typeName}\" is not able to perform the operation and (&&).");
        }


        public virtual Integer ConvertToInteger() {
            throw new WrongConversionException($"Can't convert from type {typeName} to integer.");
        }
        
        public virtual Float ConvertToFloat() {
            throw new WrongConversionException($"Can't convert from type {typeName} to float.");
        }

        public virtual Boolean ConvertToBoolean() {
            throw new WrongConversionException($"Can't convert from type {typeName} to boolean.");
        }

        public virtual Text ConvertToText() {
            throw new WrongConversionException($"Can't convert from type {typeName} to text.");
        }

        public abstract object GetValue();

        public virtual OperatebleValue GetOutputValue() {
            return this;
        }
        public abstract void SetValue(in Value value);

        public bool NotEqual(in Value otherValue) {
            return !this.Equals(otherValue);
        }
    }

}