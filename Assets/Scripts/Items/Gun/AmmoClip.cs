using UnityEngine;

public class AmmoClip : Item
{
    public override bool DepleteOnUse 
    {
        get { return true; }
    }

    public override void Use()
    {
        PlayerEquipment playerEquipment = GetComponentInParent<PlayerEquipment>();

        if (playerEquipment != null && playerEquipment.RightHandItem != null)
        {
            //Grabs the gun component from the player equipment to access the reload function.
            Gun gun = playerEquipment.RightHandItem.GetComponent<Gun>();

            if (gun != null)
            {
                gun.Reload();
                Destroy(gameObject);
            }
        }
    }
}
