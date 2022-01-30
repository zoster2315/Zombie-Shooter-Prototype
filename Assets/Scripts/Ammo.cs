using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] AmmoType currnetAmmoType;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        if (ammoSlot == null)
            return 0;

        return ammoSlot.ammoAmount;
    }

    private void Start()
    {
        UpdateAmmoText();
    }
    public void SubtractAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        if (ammoSlot == null)
            return;

        ammoSlot.ammoAmount--;
        UpdateAmmoText();
    }

    public void AddAmmo(AmmoType ammoType, int count)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        if (ammoSlot == null)
            return;

        ammoSlot.ammoAmount += count;
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        if (ammoText == null)
            return;

        AmmoSlot ammoSlot = GetAmmoSlot(currnetAmmoType);
        if (ammoSlot == null)
            return;

        ammoText.text = ammoSlot.ammoAmount.ToString();
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (var ammo in ammoSlots)
            if (ammo.ammoType == ammoType)
                return ammo;
        return null;
    }

    public void SetCurrentAmmoType(AmmoType ammoType)
    {
        currnetAmmoType = ammoType;
        UpdateAmmoText();
    }
}
