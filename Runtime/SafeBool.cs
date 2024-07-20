
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
            if (protectedValue.CompareValue(Value))
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
            if (protectedValue.CompareValue(Value))
            {
                _value = value;
                protectedValue.ApplyNewValue(_value);
            }
            else
            {
                GameObject.Find("CheatDetector").SendMessage("CheatDetected");
                Value = protectedValue.GetBool();
            }
        }
    }
}
