using System;

    public class BindProerty<T> where T : IEquatable<T>//可比较的
    {
        private T _value = default(T);//默认值
        public Action<T> _OnValueChanged;//事件
        public T value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!_value.Equals(value))
                {
                    _value = value;
                    _OnValueChanged?.Invoke(_value);
                }
            }
        }
    }
