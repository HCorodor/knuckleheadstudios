using UnityEngine;

public class Gun : Item
{
    public override bool DepleteOnUse 
    {
        get { return false; }
    }

    public int MaxAmmo = 10;
    public int CurrentAmmo { get; private set; }
    public bool isAutomatic = false;
    public float FireRate = 0.2f;
    public GameObject BulletPrefab;
    public Transform BarrelEnd;

    private float _lastFireTime = 0f;

    public Gun()
    {
        CurrentAmmo = MaxAmmo;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            isAutomatic = !isAutomatic;
            Debug.Log("Changing mode to: " + (isAutomatic ? "Automatic" : "Single"));
        }
    }

    public override void Use()
    {
        if (CurrentAmmo > 0)
        {
            if (isAutomatic && Input.GetMouseButton(1) && (Time.time - _lastFireTime >= FireRate))
            {
                Fire();
                _lastFireTime = Time.time;
                Debug.Log("Gun Fired in automatic mode! Ammo left: " + CurrentAmmo);
            }
            else if (!isAutomatic && Input.GetMouseButtonDown(1))
            {
                Fire();
                Debug.Log("Gun Fired in single mode! Ammo left: " + CurrentAmmo);
            }
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }

    private void Fire()
    {
        if (BulletPrefab != null && BarrelEnd != null)
        {
            Instantiate(BulletPrefab, BarrelEnd.position, BarrelEnd.rotation);
            CurrentAmmo--;
        }
    }

    public void Reload()
    {
        CurrentAmmo = MaxAmmo;
        Debug.Log("Reloading!");
    }
}
