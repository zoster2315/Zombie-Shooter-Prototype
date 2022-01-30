using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 40f;
    [SerializeField] ParticleSystem shootVFX;
    [SerializeField] GameObject HitEffect;
    [SerializeField] float HitEffectDestroyTime = 0.1f;
    [SerializeField] Ammo ammo;
    [SerializeField] float shootTimeOut = 0.1f;

    bool canShoot = true;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canShoot)
                StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammo.AmmoAmount > 0)
        {
            ProcessRaycast();
            ammo.SubtractAmmo();
            StartShootVFX();
        }
        yield return new WaitForSeconds(shootTimeOut);
        canShoot = true;
        StopCoroutine(Shoot());
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        if (hit.transform != null)
        {
            CreateHitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
                target.TakeDamage(damage);
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        if (HitEffect == null)
            return;
        GameObject hitEffect = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffect, HitEffectDestroyTime);
    }

    void StartShootVFX()
    {
        shootVFX.Play();
    }
}
