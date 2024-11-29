using UnityEngine;

public abstract class Item : MonoBehaviour
{
    //A boolean depicting whether an item will be depleted on use.
    public abstract bool DepleteOnUse { get; }

    //An abstract function that is universal within all items.
    public abstract void Use();

    //A virtual function that allows any item to be removed on their on parameters.
    public virtual void Remove(GameObject item, float delay)
    {
        Destroy(item, delay);
    }
}
