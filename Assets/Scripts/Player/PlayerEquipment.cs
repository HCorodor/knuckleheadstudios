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
        //This will de-equip any items currently held in the left hand.
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
        //This will de-equip any items currently held in the right hand.
        else if (RightHandItem != null && Input.GetKeyDown(KeyCode.E))
        {
            RightHandItem.Remove(RightHandItem.gameObject, 0);
            RightHandItem = null;
        }

        //By pressing LMB, the item in the left hand will be used.
        if (Input.GetMouseButton(0) && LeftHandItem != null)
        {
            LeftHandItem.Use();
            if (LeftHandItem.DepleteOnUse)
            {
                LeftHandItem = null;
            }

        }
        //By pressing RMB, the item in the right hand will be used.
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
        //It grabs an item from the prefab list based on the given item name.
        GameObject itemPrefab = Resources.Load<GameObject>($"Prefabs/{itemName}");
        if (itemPrefab != null)
        {
            GameObject newItem = Instantiate(itemPrefab, hand.position, hand.rotation, hand);
            
            Item item = newItem.GetComponent<Item>();

            //Assigns the corresponding hand to the item.
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
