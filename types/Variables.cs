

namespace PGF {

    public class Variables {

        DynamicArray<Variable> variables;
        Dictionary<string, uint> variablesByName;

        public Variables() {
            variables = new DynamicArray<Variable>(8, false);
            variablesByName = new Dictionary<string, uint>();
        }

        public Variables(Dictionary<string, Variable> variables) {

            Variable[] variableArray = new Variable[variables.Count];
            variablesByName = new Dictionary<string, uint>(variables.Count);

        for(int i = 0; i < variables.Count; i++) {
                variableArray[i] = variables.ElementAt(i).Value;
                variablesByName.Add(variables.ElementAt(i).Key, (uint)i);
        }
        }

        public Variable GetVariable(string name) {
            return variables[variablesByName[name]];
        }

        public ref Variable GetRefVariable(string name) {
            return ref variables.GetRefValue(variablesByName[name]);
        }

        public Variable GetVariable(uint index) {
            return variables[index];
        }

        public ref Variable GetRefVariable(uint index) {
            return ref variables.GetRefValue(index);
        }

        public bool GetVariable(string name, out Variable variable) {
            
            if(variablesByName.ContainsKey(name)) {
                variable = variables[variablesByName[name]];
                return true;
            }

            variable = null;
            return false;
        }

        public bool GetRefVariable(string name, ref Variable variable) {
            
            if(variablesByName.ContainsKey(name)) {
                variable = ref variables.GetRefValue(variablesByName[name]);
                return true;
            }

            return false;
        }

        public bool GetVariable(uint index, out Variable variable) {
            
            if(index < variables.size) {
                variable = variables[index];
                return true;
            }

            variable = null;
            return false;
        }

        public bool GetRefVariable(uint index, ref Variable variable) {
            
            if(index < variables.size) {
                variable = ref variables.GetRefValue(index);
                return true;
            }

            return false;
        }

        public void AddVariable(Variable variable) {
            variablesByName.Add(variable.name, (uint)variables.size);
            variables.Add(variable);
        }

        public bool TryAddVariable(Variable variable) {
            if(variablesByName.ContainsKey(variable.name))
                return false;

            AddVariable(variable);
            return true;
        }

        public void RemoveVariable(uint index) {
            variables[index] = null;
            for(int i = 0; i < variablesByName.Count; i++) {
                if(variablesByName.ElementAt(i).Value == index) {
                    variablesByName.Remove(variablesByName.ElementAt(i).Key);
                }
            }
        }

        public bool TryRemoveVariable(uint index) {

            if(variables.size <= index)
                return false;

            RemoveVariable(index);
            return true;
        }

        public void Clean() {

            Variable[] newVariables = new Variable[variablesByName.Count];
            

            for(int i = 0; i < variablesByName.Count; i++) {
                newVariables[i] = variables[variablesByName.ElementAt(i).Value];
                variablesByName[variablesByName.ElementAt(i).Key] = (uint)i;
            }

            variables = new DynamicArray<Variable>(newVariables);
        }
    }

}