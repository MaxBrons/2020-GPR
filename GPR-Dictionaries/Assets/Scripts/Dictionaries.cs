using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionaries : MonoBehaviour
{
    private enum Weapons
    {
        SMG,
        AR,
        LMG
    }

    private Dictionary<Weapons, int> _Weapons = new Dictionary<Weapons, int>();
    private Weapons currentWeapon;

    private void Start()
    {
        AddWeapon(Weapons.SMG, 15);
        AddWeapon(Weapons.AR, 30);
        AddWeapon(Weapons.LMG, 100);
        currentWeapon = Weapons.SMG;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetCurrentWeapon(Weapons.SMG);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetCurrentWeapon(Weapons.AR);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetCurrentWeapon(Weapons.LMG);

        if (Input.GetKeyDown(KeyCode.Space)) {
            if(_Weapons[currentWeapon] > 0) {
                _Weapons[currentWeapon] -= 1;
                Debug.Log("Current weapon: " + currentWeapon + " " + _Weapons[currentWeapon]);
            }
        }
    }

    private void AddWeapon(Weapons weapon, int bullets)
    {
        _Weapons.Add(weapon, bullets);
    }

    private void SetCurrentWeapon(Weapons w)
    {
        currentWeapon = w;
        Debug.Log("Weapon set to: " + currentWeapon);
    }
}
