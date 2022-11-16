



namespace PGF {
    public interface OperationStruct {

        public int priorety {get;}
        public string name {get;}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument);
    }

    public struct Add : OperationStruct {

        public int priorety {get {return 1;}}
        public string name {get {return "+";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.Add(in rightArgument);
        }
    }

    public struct Subtract : OperationStruct {

        public int priorety {get {return 1;}}

        public string name {get {return "-";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.Subtract(in rightArgument);
        }
    }

    public struct Multiply : OperationStruct {

        public int priorety {get {return 2;}}

        public string name {get {return "*";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.Multiply(in rightArgument);
        }
    }

    public struct Devide : OperationStruct {

        public int priorety {get {return 2;}}

        public string name {get {return "/";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.Devide(in rightArgument);
        }
    }

    public struct Modulus : OperationStruct {

        public int priorety {get {return 2;}}

        public string name {get {return "%";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.Modulus(in rightArgument);
        }
    }

    public struct DoesEquals : OperationStruct {

        public int priorety {get {return 3;}}

        public string name {get {return "==";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return new Boolean(leftArgument.Equals(rightArgument));
        }
    }

    public struct DoesNotEqual : OperationStruct {

        public int priorety {get {return 3;}}

        public string name {get {return "!=";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return new Boolean(!leftArgument.Equals(rightArgument));
        }
    }

    public struct GreaterThan : OperationStruct {

        public int priorety {get {return 3;}}

        public string name {get {return ">";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.GreaterThan(in rightArgument);
        }
    }

    public struct LessThan : OperationStruct {

        public int priorety {get {return 3;}}

        public string name {get {return "<";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.LessThan(in rightArgument);
        }
    }

    public struct GreaterThanOrEqual : OperationStruct {

        public int priorety {get {return 3;}}

        public string name {get {return ">=";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.GreaterThanOrEqual(in rightArgument);
        }
    }

    public struct LessThanOrEqual : OperationStruct {

        public int priorety {get {return 3;}}

        public string name {get {return "<=";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.LessThanOrEqual(in rightArgument);
        }
    }

    public struct And : OperationStruct {

        public int priorety {get {return 4;}}

        public string name {get {return "&&";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.And(in rightArgument);
        }
    }

    public struct Or : OperationStruct {

        public int priorety {get {return 4;}}

        public string name {get {return "||";}}
        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            return leftArgument.Or(rightArgument);
        }
    }

    public struct NullOperator : OperationStruct {
        public int priorety {get {return 0;}}

        public string name {get {throw new Exception("NullOperator is not a usable operator.");}}

        public OperatebleValue Operation(in OperatebleValue leftArgument, in OperatebleValue rightArgument) {
            throw new Exception("NullOperator is not a usable operator.");
        }
    }

}