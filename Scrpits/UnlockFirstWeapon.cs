using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockFirstWeapon : MonoBehaviour
{
    public void Unlock()
    {
        GameObject player = GameObject.FindWithTag("Player"); 
        player.GetComponent<Impy_attacks>().UnlockSword();
    }
}
