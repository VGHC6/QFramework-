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

    private Action<T> mOnValueChanged = (v) => { }; // -+

    public UnRegisterEvent RegisterOnValueChanged(Action<T> onValueChanged) // +
    {
        mOnValueChanged += onValueChanged;
        return new BindablePropertyUnRegister<T>()
        {
            BindableProperty = this,
            OnValueChanged = onValueChanged
        };
    }

    public void UnRegisterOnValueChanged(Action<T> onValueChanged) // +
    {
        mOnValueChanged -= onValueChanged;
    }
}

public class BindablePropertyUnRegister<T> : UnRegisterEvent where T : IEquatable<T> // +
{
    public BindProerty<T> BindableProperty { get; set; }

    public Action<T> OnValueChanged { get; set; }

    public void UnRegister()
    {
        BindableProperty.UnRegisterOnValueChanged(OnValueChanged);
    }
}

