using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    [SerializeField] float disableTime = 0.5f;
    [SerializeField] Canvas damageTakenCanvas;

    // Start is called before the first frame update
    void Start()
    {
        damageTakenCanvas.enabled = false;
    }

    public void ShowDamageTaken()
    {
        StartCoroutine(ShowDamageImage());
    }

    IEnumerator ShowDamageImage()
    {
        damageTakenCanvas.enabled = true;
        yield return new WaitForSeconds(disableTime);
        damageTakenCanvas.enabled = false;
        StopCoroutine(ShowDamageImage());
    }
}
