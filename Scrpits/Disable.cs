using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disable : MonoBehaviour
{
    GameObject player;
    void OnEnable()
    {
        GameObject player = GameObject.FindWithTag("Player"); 
 
        player.GetComponent<impy_move>().enabled = false;
        player.GetComponent<Impy_attacks>().enabled = false;
    }
    void OnDisable()
    {
        GameObject player = GameObject.FindWithTag("Player"); 
 
        player.GetComponent<impy_move>().enabled = true;
        player.GetComponent<Impy_attacks>().enabled = true;
    }
}