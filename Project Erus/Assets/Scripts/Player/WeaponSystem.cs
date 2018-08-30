using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {

    public Animator ani;
    private CatController control;

    public GameObject weaponBone;
    public GameObject[] weaponPrefabs;

    private int curWeaponIndex = 0;
    private GameObject curWeapon;
    public GameObject CurWeapon
    {
        get { return curWeapon; }
    }


    // Attack
    private int comboCounter = 0;
    private bool attackWasReleased = true;
    private bool animationWasPlayed = true;

    // Use this for initialization
    void Start () {

        ani = GetComponent<Animator>();
        control = GetComponent<CatController>();

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

        if (comboCounter == curWeapon.GetComponent<Weapon>().comboLength && animationWasPlayed)
            comboCounter = 0;

        if (Input.GetKey(KeyCode.L) && attackWasReleased && animationWasPlayed)
        {
            attackWasReleased = false;
            animationWasPlayed = false;

            if (curWeapon.GetComponent<Weapon>().comboLength > comboCounter)
            {
                comboCounter++;
                PlayAnimation();
            }
        }

        if (!Input.GetKey(KeyCode.L))
            attackWasReleased = true;

        Debug.Log(control.IsMovementBlocked + " > " + comboCounter);

        if (curWeapon.GetComponent<Weapon>().animationInteger == "ComboAttackKnife" && comboCounter == 3 && !control.IsMovementBlocked)
            control.BlockMovement();
        else if (curWeapon.GetComponent<Weapon>().animationInteger == "ComboAttackKnife" && comboCounter != 3 && control.IsMovementBlocked)
            control.BlockMovement();

        #endregion

    }

    private void switchWeapon(int index)
    {

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

    public void StopAnimation()
    {
        StartCoroutine(ResetCombo(comboCounter, 0.5F));
        animationWasPlayed = true;
        
    }

    private IEnumerator ResetCombo(int comboCounter, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Debug.Log(this.comboCounter + " | " + comboCounter);

        if (this.comboCounter == comboCounter )
        {
            this.comboCounter = 0;
        }
    }

}