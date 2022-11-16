


namespace PGF {

    public struct DynamicArray<T> {

        public uint size {get; private set;}
        private T[] array;

        uint AutoExpandSize {get; init;}
        bool DefaultWhenOutOfRange {get; init;}

        public DynamicArray() {
            size = 0;
            array = new T[0];

            AutoExpandSize = 0;
            DefaultWhenOutOfRange = false;
        }

        public DynamicArray(uint additionalSpace) {
            size = 0;
            array = new T[additionalSpace];

            AutoExpandSize = 0;
            DefaultWhenOutOfRange = false;
        }

        public DynamicArray(T[] value) {
            size = (uint)value.Length;
            array = value;

            AutoExpandSize = 0;
            DefaultWhenOutOfRange = false;
        }

        public DynamicArray(T[] value, uint additionalSpace) {
            size = (uint)value.Length;
            array = new T[size + additionalSpace];

            for(uint i = 0; i < size; i ++) {
                array[i] = value[i];
            }

            AutoExpandSize = 0;
            DefaultWhenOutOfRange = false;
        }

        public DynamicArray(T[] value, uint AutoExpandSize, bool DefaultWhenOutOfRange, uint additionalSpace) {
            size = (uint)value.Length;
            array = new T[size + additionalSpace];

            for(uint i = 0; i < size; i ++) {
                array[i] = value[i];
            }

            this.AutoExpandSize = AutoExpandSize;
            this.DefaultWhenOutOfRange = DefaultWhenOutOfRange;
        }

        public DynamicArray(uint AutoExpandSize, bool DefaultWhenOutOfRange) {
            size = 0;
            array = new T[0];

            this.AutoExpandSize = AutoExpandSize;
            this.DefaultWhenOutOfRange = DefaultWhenOutOfRange;
        }

        public DynamicArray(uint AutoExpandSize, bool DefaultWhenOutOfRange, uint additionalSpace) {
            size = 0;
            array = new T[additionalSpace];

            this.AutoExpandSize = AutoExpandSize;
            this.DefaultWhenOutOfRange = DefaultWhenOutOfRange;
        }

        public T this[uint index] {

            get {
                if(index >= size)
                    if(DefaultWhenOutOfRange)
                        return default(T);
                    else
                        throw new IndexOutOfRangeException($"index {index} is outside the size of the dynamic array, which is of size {size}");

                return array[index];
            }

            set {
                if(index >= size)
                    if(AutoExpandSize > 0)
                        if(array.Length - 1 <= index)
                            ExpandArray(AutoExpandSize);
                    else
                        throw new IndexOutOfRangeException($"index {index} is outside the size of the dynamic array, which is of size {size}");

                array[index] = value;
            }

        }

        public ref T GetRefValue(uint index) {
            if(index >= size)
                throw new IndexOutOfRangeException($"index {index} is outside the size of the dynamic array, which is of size {size}");

            return ref array[index];
        }



        public static DynamicArray<T> operator +(DynamicArray<T> a, DynamicArray<T> b) {
            a.Add(b);
            return a;
        }

        public static DynamicArray<T> operator +(DynamicArray<T> a, T[] b) {
            a.Add(b);
            return a;
        }

        public static DynamicArray<T> operator +(DynamicArray<T> a, int b) {

            if(b > 0) {
                a.Expand((uint)b);
            } else if(b < 0) {
                a.Shrink((uint)b);
            }

            return a;
        }

        public static DynamicArray<T> operator -(DynamicArray<T> a, int b) {
            return a + (-b);
        }

        public void Add(T value) {

            size ++;
            if(array.Length < size) {
                T[] oldArray = array;
                array = new T[size];

                for(int i = 0; i < size - 1; i++) {
                    array[i] = oldArray[i];
                }
            }

            array[size - 1] = value;
        }

        public void Add(DynamicArray<T> b) {
            
            uint j = b.size + size;

                if(j > array.Length) {
                    T[] oldArray = array;
                    array = new T[j];

                    for(uint i = 0; i < size; i ++) {
                        array[i] = oldArray[i];
                    }
                }

            for(uint i = size; i < j; i ++) {
                array[i] = b.array[i - size];
            }

            size = j;

            return;
        }

        public void Add(T[] b) {

            uint j = (uint)b.Length + size;

                if(j > array.Length) {
                    T[] oldArray = array;
                    array = new T[j];

                    for(uint i = 0; i < size; i ++) {
                        array[i] = oldArray[i];
                    }
                }

            for(uint i = size; i < j; i ++) {
                array[i] = b[i - size];
            }

            size = j;

            return;
        }

        public void ExpandArray(uint size) {

            T[] newArray = new T[array.Length + size];
            for(int i = 0; i < this.size; i++) {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        public void ShrinkArray(uint size) {

            T[] oldArray = array;

            array = new T[array.Length - size];

            uint j = (uint)array.Length;

            if(j > this.size)
                j = this.size;
            else
                this.size = j;

            for(uint i = 0; i < j; i ++) {
                array[i] = oldArray[i];
            }
        }

        public void Expand(uint size) {
            
            if(this.size + size > array.Length)
                ExpandArray(this.size + size - (uint)array.Length);

            this.size += size;
        }

        public void Shrink(uint size) {
            
            if(this.size + size > array.Length)
                ShrinkArray(this.size + size - (uint)array.Length);

            this.size -= size;
        }

        

    }

}