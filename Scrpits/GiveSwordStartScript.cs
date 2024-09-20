using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveSwordStartScript : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player"); 
        player.GetComponent<Impy_attacks>().UnlockSword();
        player.GetComponent<Impy_attacks>().weapon = 1;
        //player.GetComponent<impy_move>().Flip();
    }
}
