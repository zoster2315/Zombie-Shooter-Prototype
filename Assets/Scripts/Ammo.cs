using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    [SerializeField] TextMeshProUGUI ammoText;
    public int AmmoAmount { get { return ammoAmount; } }

    private void Start()
    {
        UpdateAmmoText();
    }
    public void SubtractAmmo()
    {
        ammoAmount--;
        UpdateAmmoText();
    }

    public void AddAmmo(int count)
    {
        ammoAmount += count;
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        if (ammoText == null)
            return;
        ammoText.text = ammoAmount.ToString();
    }
}
