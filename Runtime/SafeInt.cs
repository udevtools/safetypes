
using UnityEngine;

public class SafeInt
{
    private int _value;
    ProtectedValue protectedValue;

    public SafeInt(int value)
    {
        protectedValue = new ProtectedValue(value);
        Value = protectedValue.GetInt();
    }

    public int Value { 
        get 
        { 
            if (protectedValue.CompareValue(_value))
            {
                return _value;
            }
            else
            {
                GameObject.FindFirstObjectByType<CheatDetector>().SendMessage("CheatDetected");
                Value = protectedValue.GetInt();
                return _value;
            }
        }
        set
        {
            if (protectedValue.CompareValue(_value))
            {
                _value = value;
                protectedValue.ApplyNewValue(_value);
            }
            else
            {
                GameObject.FindFirstObjectByType<CheatDetector>().SendMessage("CheatDetected");
                Value = protectedValue.GetInt();
            }
        }
    }
}
