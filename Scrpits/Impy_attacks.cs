using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Impy_attacks : MonoBehaviour
{
    public static int weaponlevel;
    //public bool attB = false;
    public Transform Fire1;
    public GameObject Fireball;
    public GameObject Shield;
    public GameObject Sword;
    public int weapon = 0;
    public GameObject FireImage;
    public GameObject shieldImage;
    public GameObject swordImage;
    public int F_ammo;
    public int S_ammo;
    public FammoBar _FammoBar;
    public SammoBar _SammoBar;
    float Firetimer;
    bool canAttack;
    int maxAttack = 0;
    int maxAttackplusone;
    public float shieldTime;
    public bool ShieldActive;
    void Start()
    {
        shieldTime = 10f;
        ShieldActive = false;
        maxAttackplusone = maxAttack + 1; 
        canAttack = true;
        Firetimer = .5f;
        F_ammo = 10;
        S_ammo = 5;
        _FammoBar.SetMaxFAmmo(F_ammo);
        _SammoBar.SetMaxSAmmo(S_ammo);
    }
    public void Update()
    {
        if (Input.GetButtonDown("weaponSelec"))
        {
            if(weaponlevel != 0)
            {
            weapon = weapon + 1;
            if (weapon == weaponlevel +1)
                {
                    weapon = 1;
                }
            }
            if(weapon == 3 && weaponlevel == 3)
            {
                shieldImage.SetActive(false);
                FireImage.SetActive(true);
                swordImage.SetActive(false);
            }
            if(weapon == 2 && weaponlevel >= 2)
            {
                FireImage.SetActive(false);
                swordImage.SetActive(false);
                shieldImage.SetActive(true);
            }
            if(weapon == 1 && weaponlevel >= 2)
            {
                FireImage.SetActive(false);
                shieldImage.SetActive(false);
                swordImage.SetActive(true);
            }
        }
        if (Input.GetButtonDown("Fire1") && weapon == 2 && S_ammo >= 0 && canAttack == true && ShieldActive == false)
        {
            Attcak2();
            S_ammo = S_ammo -1;
            _SammoBar.SetSAmmo(S_ammo);
            ShieldActive = true;
        }
        if (Input.GetButtonDown("Fire1") && weapon == 1 && canAttack == true)
        {
            Attcak1();
        }
        if (Input.GetButtonDown("Fire1") && weapon == 3 && F_ammo >= 0 && canAttack == true && ShieldActive == false)
        {
            Attcak3();
            F_ammo = F_ammo -1;
            _FammoBar.SetFAmmo(F_ammo);
        }
    }
    void Attcak3()
    {
        Instantiate(Fireball, Fire1.position, Fire1.rotation);
        canAttack = false;
    }
    void Attcak2()
    {
        Instantiate(Shield, Fire1.position, Fire1.rotation);
        canAttack = false;
    }
    void Attcak1()
    {
        Instantiate(Sword, Fire1.position, Fire1.rotation);
        canAttack = false;
    }
    void FixedUpdate()
    {
        if(canAttack == false)
        {
            Firetimer -= Time.fixedDeltaTime;
            if(Firetimer <= 0f)
            {
                canAttack = true;
                Firetimer = .5f;
            }
        }
        if(ShieldActive == true)
        {
            shieldTime -= Time.fixedDeltaTime;
            if(shieldTime <= 0f)
            {
                ShieldActive = false;
                shieldTime = 10f;
            }
        }
    }
    public void UnlockSword()
    {
        weaponlevel = 1;
        //maxAttack = 1;
        weapon = 1;
        swordImage.SetActive(true);
    }
    public void UnlockShield()
    {
        weaponlevel = 2;
        //maxAttack = 2;
        weapon = 2;
        shieldImage.SetActive(true);
    }
    public void UnlockFire()
    {
        weaponlevel = 3;
        //maxAttack = 3;
        weapon = 3;
        FireImage.SetActive(true);
    }
}
