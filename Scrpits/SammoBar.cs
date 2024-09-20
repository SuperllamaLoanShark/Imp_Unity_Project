using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SammoBar : MonoBehaviour
{
   public Slider slider;
    public void SetMaxSAmmo(int S_ammo)
    {
        slider.maxValue = S_ammo;
        slider.value = S_ammo;
    }
    public void SetSAmmo(int S_ammo)
    {
        slider.value  = S_ammo;
    }
}
