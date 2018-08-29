using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {

    public Animator ani;

    public GameObject weaponBone;
    public GameObject[] weaponPrefabs;

    private GameObject curWeapon;
    private int curWeaponIndex = 0;

    // Attack
    private int comboCounter = 0;
    private bool attackWasReleased = true;

    // Use this for initialization
    void Start () {

        ani = GetComponent<Animator>();

        switchWeapon(curWeaponIndex);

    }
	
	// Update is called once per frame
	void Update () {

        // scroll Weapon forward
        if (Input.mouseScrollDelta.y > 0)
        {
            if (curWeaponIndex + 1 >= weaponPrefabs.Length)
                switchWeapon(0);
            else
                switchWeapon(curWeaponIndex + 1);

        }
        // scroll Weapon backwards
        else if (Input.mouseScrollDelta.y < 0)
        {
            if (curWeaponIndex - 1 < 0)
                switchWeapon(weaponPrefabs.Length-1);
            else
                switchWeapon(curWeaponIndex - 1);
        }

        #region Attack-Inputs

        Debug.Log(comboCounter);

        if (Input.GetKey(KeyCode.L) && attackWasReleased)
        {
            attackWasReleased = false;

            if (curWeapon.GetComponent<Weapon>().comboLength > comboCounter)
            {
                Debug.Log(curWeapon.GetComponent<Weapon>().comboLength + " <> " + (comboCounter + 1));
                comboCounter++;
                PlayAnimation();
                StartCoroutine(ResetCombo(comboCounter, 0.5F));
            }
        }

        if (!Input.GetKey(KeyCode.L))
            attackWasReleased = true;

        #endregion

    }

    private IEnumerator ResetCombo(int comboCounter, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Debug.Log(comboCounter + " | " +  this.comboCounter);

        if (this.comboCounter == comboCounter)
        {
            this.comboCounter = 0;
            StopAnimation();
        }
    }

    private void switchWeapon(int index) {

        if (curWeapon != null)
            StopAnimation();

        Destroy(curWeapon); // Destroy current Weaponobject


        // create new Weapon objekt
        curWeaponIndex = index;
        curWeapon = Instantiate(weaponPrefabs[index]);
        curWeapon.transform.SetParent(weaponBone.transform, false);

    }

    private void PlayAnimation()
    {
        Weapon weaponPorps = curWeapon.GetComponent<Weapon>();

        ani.SetInteger(weaponPorps.animationInteger, comboCounter);

    }

    private void StopAnimation()
    {
        Weapon weaponPorps = curWeapon.GetComponent<Weapon>();

        ani.SetInteger(weaponPorps.animationInteger, 0);

    }

}