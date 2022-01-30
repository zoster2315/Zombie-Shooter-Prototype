using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;


    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(weaponIndex == currentWeapon);
            weaponIndex++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();
        if (previousWeapon != currentWeapon)
            SetWeaponActive();
    }

    void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentWeapon = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            currentWeapon = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            currentWeapon = 2;
    }

    void ProcessScrollWheel()
    {
        var mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        int mouseScrollDirection = mouseScroll > 0 ? 1 : mouseScroll < 0 ? -1 : 0;

        currentWeapon += mouseScrollDirection;
        if (currentWeapon < 0)
            currentWeapon = transform.childCount - 1;
        if (currentWeapon > transform.childCount - 1)
            currentWeapon = 0;
    }
}
