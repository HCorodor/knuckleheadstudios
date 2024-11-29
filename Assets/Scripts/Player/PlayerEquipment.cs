using System.Security.Cryptography;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public Transform LeftHand, RightHand;
    public Item LeftHandItem, RightHandItem;
    public bool WearingHat = false;

    private void Update()
    {
        if (LeftHandItem == null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                EquipItem("Flashlight", LeftHand);
            }
            else if (Input.GetKeyDown(KeyCode.H) && !WearingHat)
            {
                EquipItem("Hat", LeftHand);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                EquipItem("Ammo Clip", LeftHand);
            }
        }
        else if (LeftHandItem != null && Input.GetKeyDown(KeyCode.Q))
        {
            LeftHandItem.Remove(LeftHandItem.gameObject, 0);
            LeftHandItem = null;
        }

        if (RightHandItem == null)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                EquipItem("Rock", RightHand);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                EquipItem("Gun", RightHand);
            }
        }
        else if (RightHandItem != null && Input.GetKeyDown(KeyCode.E))
        {
            RightHandItem.Remove(RightHandItem.gameObject, 0);
            RightHandItem = null;
        }

        if (Input.GetMouseButton(0) && LeftHandItem != null)
        {
            LeftHandItem.Use();
            if (LeftHandItem.DepleteOnUse)
            {
                LeftHandItem = null;
            }

        }
        if (Input.GetMouseButton(1) && RightHandItem != null)
        {
            RightHandItem.Use();
            if (RightHandItem.DepleteOnUse)
            {
                RightHandItem = null;
            }
        }
    }

    public void EquipItem(string itemName, Transform hand)
    {
        GameObject itemPrefab = Resources.Load<GameObject>($"Prefabs/{itemName}");
        if (itemPrefab != null)
        {
            if (itemName == "Rock")
            {
                hand = RightHand;
            }
            else if (itemName == "Flashlight" || itemName == "Hat")
            {
                hand = LeftHand;
            }

            GameObject newItem = Instantiate(itemPrefab, hand.position, hand.rotation, hand);
            
            Item item = newItem.GetComponent<Item>();

            if (hand == LeftHand)
            {
                LeftHandItem = item;
            }
            else if (hand == RightHand)
            {
                RightHandItem = item;
            }
        }
    }
}
