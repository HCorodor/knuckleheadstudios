using UnityEngine;

public class Flashlight : Item
{
    private Light _spotLight;
    private bool isOn = false;

    public override bool DepleteOnUse 
    {
        get { return false; }
    }

    private void Start()
    {
        _spotLight = GetComponentInChildren<Light>();

        if (_spotLight != null)
        {
            _spotLight.enabled = false;
        }
    }

    public override void Use()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_spotLight != null)
                {
                    isOn = !isOn;
                    _spotLight.enabled = isOn;
                }
        }
    }
}
