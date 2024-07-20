
using UnityEngine;

public class SafeString
{
    private string _value;
    ProtectedValue protectedValue;

    public SafeString(string value)
    {
        protectedValue = new ProtectedValue(value);
        Value = protectedValue.GetString();
    }

    public string Value { 
        get 
        { 
            if (protectedValue.CompareValue(_value))
            {
                return _value;
            }
            else
            {
                GameObject.FindFirstObjectByType<CheatDetector>().SendMessage("CheatDetected");
                Value = protectedValue.GetString();
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
                GameObject.Find("CheatDetector").SendMessage("CheatDetected");
                Value = protectedValue.GetString();
            }
        }
    }
}
