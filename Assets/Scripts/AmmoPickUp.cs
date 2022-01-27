using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] int ammoCount;

    private void OnTriggerEnter(Collider other)
    {
        Ammo ammo = other.GetComponentInChildren<Ammo>();
        if (ammo != null)
        {
            ammo.AddAmmo(ammoCount);
            Destroy(gameObject);
        }
    }
}
