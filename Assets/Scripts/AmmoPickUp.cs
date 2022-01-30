using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] int ammoCount;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other)
    {
        Ammo ammo = other.GetComponentInChildren<Ammo>();
        if (other.gameObject.CompareTag("Player") && ammo != null)
        {
            ammo.AddAmmo(ammoType, ammoCount);
            Destroy(gameObject);
        }
    }
}
