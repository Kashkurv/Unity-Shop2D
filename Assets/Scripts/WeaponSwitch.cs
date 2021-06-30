using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public static WeaponSwitch Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public int indexWeapon;
    void Start()
    {       
        indexWeapon = PlayerPrefs.HasKey("Weapon") ? PlayerPrefs.GetInt("Weapon") : 0;
    }
    void Update()
    {

        int currentWeapon = indexWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            indexWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            indexWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            indexWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            indexWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            indexWeapon = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && transform.childCount >= 6)
        {
            indexWeapon = 5;
        }

        SelectWeapon(indexWeapon);
        if (currentWeapon != indexWeapon)
        {
            SelectWeapon(0);
        }

    }
  
    public void SelectWeapon(int itemIndex)
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == itemIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
