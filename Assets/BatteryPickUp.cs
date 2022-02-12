using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    [SerializeField] float restoreAngle = 70f;
    [SerializeField] float addIntensity = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FlashLightSystem flashLight = other.gameObject.GetComponentInChildren<FlashLightSystem>();
            if (flashLight != null)
            {
                flashLight.AddLightIntensity(addIntensity);
                flashLight.RestoreLightAngle(restoreAngle);
                Destroy(gameObject);
            }
        }
    }
}
