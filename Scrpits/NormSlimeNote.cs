using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormSlimeNote : MonoBehaviour
{
    GameObject player;
    public GameObject CageSpeakButton;
    void Start()
    {
        CageSpeakButton.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance<5f)
        {
            CageSpeakButton.SetActive(true);
        }
        else
        {
            CageSpeakButton.SetActive(false);
        }
    }
}
