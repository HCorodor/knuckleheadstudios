using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract bool DepleteOnUse { get; }
    public abstract void Use();
    public virtual void Remove(GameObject item, float delay)
    {
        Destroy(item, delay);
    }
}
