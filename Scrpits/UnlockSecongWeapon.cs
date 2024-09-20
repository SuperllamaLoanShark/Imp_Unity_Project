using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockSecongWeapon : MonoBehaviour
{
    public GameObject swordImage;
    public void Unlock()
    {
        GameObject player = GameObject.FindWithTag("Player"); 
        player.GetComponent<Impy_attacks>().UnlockShield();
        swordImage.SetActive(false);
    }
}
