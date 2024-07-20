
using UnityEngine;

public class SafeBool
{
    private bool _value;
    ProtectedValue protectedValue;

    public SafeBool(bool value)
    {
        protectedValue = new ProtectedValue(value);
        Value = protectedValue.GetBool();
    }

    public bool Value { 
        get 
        { 
            if (protectedValue.CompareValue(_value))
            {
                return _value;
            }
            else
            {
                GameObject.FindFirstObjectByType<CheatDetector>().SendMessage("CheatDetected");
                Value = protectedValue.GetBool();
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
                Value = protectedValue.GetBool();
            }
        }
    }
}
