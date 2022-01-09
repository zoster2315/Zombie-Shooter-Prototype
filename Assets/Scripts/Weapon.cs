using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        if (hit.transform != null)
        {
            Debug.Log($"shot into {hit.transform.name}");
        }
    }
}
