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
        //Grabbing the light component.
        _spotLight = GetComponentInChildren<Light>();

        if (_spotLight != null)
        {
            //Immediately turning it off.
            _spotLight.enabled = false;
        }
    }

    public override void Use()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_spotLight != null)
                {
                    //Flipping the flashlight mode.
                    isOn = !isOn;
                    _spotLight.enabled = isOn;
                }
        }
    }
}
