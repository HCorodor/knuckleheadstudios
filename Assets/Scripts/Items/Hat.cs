using UnityEngine;

public class Hat : Item
{

    public override bool DepleteOnUse 
    {
        get { return true; }
    }

    public override void Use()
    {
        PlayerEquipment playerEquipment = GetComponentInParent<PlayerEquipment>();

        if (playerEquipment != null)
        {
            //Sets the hat to be a child of the Head of the player.
            transform.SetParent(GameObject.Find("Head").transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            playerEquipment.WearingHat = true;
        }
    }
}
