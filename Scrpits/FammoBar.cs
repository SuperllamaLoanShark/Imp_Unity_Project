using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FammoBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxFAmmo(int F_ammo)
    {
        slider.maxValue = F_ammo;
        slider.value = F_ammo;
    }
    public void SetFAmmo(int F_ammo)
    {
        slider.value  = F_ammo;
    }
}
