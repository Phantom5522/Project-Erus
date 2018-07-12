using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {

    public GameObject weaponBone;
    public GameObject[] weaponPrefabs;

    private GameObject curWeapon;
    private int curWeaponIndex = 0;

	// Use this for initialization
	void Start () {

        curWeapon = Instantiate(weaponPrefabs[curWeaponIndex]);
        curWeapon.transform.SetParent(weaponBone.transform, false);



    }
	
	// Update is called once per frame
	void Update () {

        if (Input.mouseScrollDelta.y > 0)
        {
            if (curWeaponIndex + 1 >= weaponPrefabs.Length)
                switchWeapon(0);
            else
                switchWeapon(curWeaponIndex + 1);

        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            if (curWeaponIndex - 1 < 0)
                switchWeapon(0);
            else
                switchWeapon(curWeaponIndex + 1);
        }


    }

    private void switchWeapon(int index) {



    }

}
