using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 20f;
    public float LifeTime = 5f;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * Speed;
        }

        Destroy(gameObject, LifeTime);
    }
}
