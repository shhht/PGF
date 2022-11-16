


namespace PGF {
    public class Expression : OperatebleValue {

        public override string typeName {get {return "expression";}}

        OperatebleValue expression;

        public Expression(ref char[] expression, ref int position, ref Variables variables) {
        
            OperatebleValue value;
            bool endOfExpression;

            value = GetOperatebleValueFromString(ref expression, ref position, out endOfExpression, ref variables);

            while(position < expression.Length) {
                switch(expression[position]) {
                    case ' ': case '\t':
                    position ++;
                    continue;

                    case ')':
                        endOfExpression = true;
                        break;

                    case '(':
                        throw new MissingOperatorException("There was no operation given before a new expression was created.");

                    default:
                        break;
                }

                break;
            }


            if(endOfExpression) {
                this.expression = value;
                return;
            }

            int priorety = 0;

            this.expression = GetOperationValueFromString(in value, in priorety, ref expression, ref position, ref variables);
        }

        public OperatebleValue GetOperationValueFromString(in OperatebleValue firstValue, in int prioretyLevel, ref char[] expression, ref int position, ref Variables variables) {

            OperationStruct operation;
            OperatebleValue secondValue;

            bool endOfExpression;

            GetValues(ref expression, ref position, ref variables, out operation, out secondValue, out endOfExpression);

            

            {
                if(endOfExpression)
                    return new Operation(operation, firstValue, secondValue);

                int priorety = operation.priorety;

                OperatebleValue lastValue = new Operation(operation, firstValue, secondValue);

                return GetOperationValueFromString(in lastValue, in priorety, ref expression, ref position, ref variables);

            }
        }

        public override void FromString(string value)
        {
            throw new NotImplementedException();
        }

        public override void FromString(char[] value)
        {
            throw new NotImplementedException();
        }

        public override string GetString()
        {
            return expression.GetOutputValue().GetString();
        }

        public override char[] GetCharArray()
        {
            throw new NotImplementedException();
        }

        public override void SetValue(in Value value)
        {
            throw new NotImplementedException();
        }

        public override object GetValue()
        {
            throw new NotImplementedException();
        }

        public override OperatebleValue GetOperatebleValue()
        {
            return expression.GetOutputValue();
        }

        private OperatebleValue GetOperatebleValueFromString(ref char[] expression, ref int position, out bool endOfExpression, ref Variables variables) {    
            return GetOperatebleValueFromString(new List<char>(), ref expression, ref position, out endOfExpression, ref variables);
        }

        private OperatebleValue GetOperatebleValueFromString(List<char> value, ref char[] expression, ref int position, out bool endOfExpression, ref Variables variables) {

            endOfExpression = false;

            while(position < expression.Length) {
                switch(expression[position]) {
                    case '\n':
                        break;


                    // Get string
                    case '\"':
                        return new Text(ref expression, ref position);

                    case '(':
                        position ++;
                        return new Expression(ref expression, ref position, ref variables);

                    case ')':
                        throw new WrongCharacterException($"There is no value before ending the expression with the character \')\'.");

                    case ' ': case '\t':
                        position ++ ;
                        continue;


                    case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9':
                        
                        bool isFloat = false;

                        value.Add(expression[position]);

                        position ++;

                        while(position < expression.Length) {
                            switch(expression[position]) {
                                case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9':
                                    value.Add(expression[position]);
                                    break;

                                case '.': case ',':
                                    if(isFloat)
                                        throw new WrongCharacterException($"This number \'{value}\' already hase a point to seperate the hole numbers from the fractions.");

                                    isFloat = true;
                                    value.Add(',');
                                    break;

                                case 'f':
                                    position ++;
                                    return new Float(float.Parse(new string(value.ToArray())));

                                case ' ': case '\t':

                                    position ++;

                                    if(isFloat) {
                                        return new Float(float.Parse(new string(value.ToArray())));
                                    }

                                    return new Integer(int.Parse(new string(value.ToArray())));

                                case ')':

                                    endOfExpression = true;
                                    position ++;

                                    if(isFloat) {
                                        return new Float(float.Parse(new string(value.ToArray())));
                                    }

                                    return new Integer(int.Parse(new string(value.ToArray())));

                                case '(':
                                    throw new MissingOperatorException("There is no operator before the new expression.");

                                default:
                                    throw new WrongCharacterException($"This number \'{value}\' already hase a point to seperate the hole numbers from the fractions.");

                            }

                            position ++;
                        }
                    
                        throw new MissingTextException("There is no value after a operation");
                    
                    
                    
                    default:
                        value.Add(expression[position]);
                        break;
                }

                break;
                
            }

            position ++;

            while(position < expression.Length) {
                switch(expression[position]) {
                    case '(':
                        throw new MissingOperatorException("There is no operator before the new expression.");

                    case ')':

                        endOfExpression = true;

                        {
                            string stringValue = new string(value.ToArray()).ToLower();

                            position ++;

                            switch(stringValue) {
                                case "true":
                                    return new Boolean(true);
                                
                                case "false":
                                    return new Boolean(false);

                                default:
                                    return variables.GetVariable(new string(value.ToArray()));
                            }
                        }

                    case ' ': case '\t':

                        {
                            string stringValue = new string(value.ToArray()).ToLower();

                            position ++;

                            switch(stringValue) {
                                case "true":
                                    return new Boolean(true);
                                
                                case "false":
                                    return new Boolean(false);

                                default:
                                    return variables.GetVariable(new string(value.ToArray()));
                            }
                        }


                    default:
                        value.Add(expression[position]);
                        break;
                }

                position ++;
            }

            throw new MissingTextException("There is no end for the expression, did you mean to add a \')\' at the end of the line.");
        }

        private OperationStruct GetOperationStructFromString(ref char[] expression, ref int position, out bool newExpression) {
            
            List<char> value = new List<char>();

            while(position < expression.Length) {

                switch(expression[position]) {
                    case ')':
                        throw new NotEnoughArgumentsException("No value was given after a operation and before the end of the expression.");

                    case ' ': case '\t':
                        position ++;
                        continue;

                    case '(':
                        newExpression = true;
                        position ++;
                        return new Multiply();

                    default:
                        value.Add(expression[position]);
                        break;
                }

                position ++;

                break;
            }
            
            
            return GetOperationStructFromString(value, ref expression, ref position, out newExpression);
        }

        private OperationStruct GetOperationStructFromString(List<char> value, ref char[] expression, ref int position, out bool newExpression) {

            newExpression = false;
            
            while(position < expression.Length) {

                switch(expression[position]) {
                    case ')':
                        throw new NotEnoughArgumentsException("No value was given after a operation and before the end of the expression.");

                    case ' ': case '\t':
                        position ++;
                        return Operation.OperationFromString(new string(value.ToArray()));

                    case '(':
                        newExpression = true;
                        position ++;
                        return Operation.OperationFromString(new string(value.ToArray()));

                    default:
                        value.Add(expression[position]);
                        break;
                }

                position ++;
            }

            throw new MissingTextException("There is no value after a operation");
        }

        public void GetValues(ref char[] expression, ref int position, ref Variables variables, out OperationStruct operation, out OperatebleValue value, out bool endOfExpression) {

            bool newExpression;

            endOfExpression = false;

            position ++;

            if(position >= expression.Length)
                throw new MissingTextException("There is no indication that the expression hase ended before the end of the text.");

            operation = GetOperationStructFromString(new List<char>() {expression[position - 1]}, ref expression, ref position, out newExpression);

            if(newExpression)
                value = new Expression(ref expression, ref position, ref variables);

            else
                value = GetOperatebleValueFromString(ref expression, ref position, out endOfExpression, ref variables);

            if(endOfExpression)
                return;


            while(position < expression.Length) {
                switch(expression[position]) {
                    case ' ': case '\t':
                    position ++;
                    continue;

                    case ')':
                        endOfExpression = true;
                        return;

                    case '(':
                        throw new MissingOperatorException("There was no operation given before a new expression was created.");

                    default:
                        return;
                }
            }

            throw new MissingTextException("There was no indication that the expression ended before the end of the text, did you forget to add a \')\' at the end?");

        }

        public override OperatebleValue Add(in OperatebleValue otherValue)
        {
            return expression.Add(in otherValue);
        }

        public override OperatebleValue Subtract(in OperatebleValue otherValue)
        {
            return expression.Subtract(in otherValue);
        }
        
        public override OperatebleValue Multiply(in OperatebleValue otherValue)
        {
            return expression.Multiply(in otherValue);
        }
        
        public override OperatebleValue Devide(in OperatebleValue otherValue)
        {
            return expression.Devide(in otherValue);
        }
        
        public override OperatebleValue Modulus(in OperatebleValue otherValue)
        {
            return expression.Modulus(in otherValue);
        }

        public override OperatebleValue GreaterThan(in OperatebleValue otherValue)
        {
            return expression.GreaterThan(in otherValue);
        }

        public override OperatebleValue LessThan(in OperatebleValue otherValue)
        {
            return expression.LessThan(in otherValue);
        }

        public override OperatebleValue GreaterThanOrEqual(in OperatebleValue otherValue)
        {
            return expression.GreaterThanOrEqual(in otherValue);
        }

        public override OperatebleValue LessThanOrEqual(in OperatebleValue otherValue)
        {
            return expression.LessThanOrEqual(in otherValue);
        }

        public override Integer ConvertToInteger()
        {
            return GetOperatebleValue().ConvertToInteger();
        }
    }

}