using UnityEngine;

public class Rock : Item
{
    public float ThrowForce = 10f;

    public override bool DepleteOnUse
    {
        get { return true; }
    }

    public override void Use()
    {
        transform.SetParent(null);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        rb.AddForce(transform.forward * ThrowForce, ForceMode.Impulse);

        Remove(this.gameObject, 5f);
    }
}
