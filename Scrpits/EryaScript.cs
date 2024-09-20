using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EryaScript : MonoBehaviour
{
    GameObject player;
    Animator EryaAnim;
    bool IsRight = true;
    public GameObject EryaSpeakButton;
    void Start()
    {
        EryaSpeakButton.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        EryaAnim = GetComponent<Animator>();
    }
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance<5f)
        {
            EryaSpeakButton.SetActive(true);
        }
        else
        {
            EryaSpeakButton.SetActive(false);
        }
        if (player.transform.position.x > transform.position.x && IsRight == false)
        {
            IsRight = true;
            transform.Rotate(0f,180f,0f);
            EryaAnim.SetBool("_isRight", true);
        }
        if (player.transform.position.x < transform.position.x && IsRight == true)
        {
            IsRight = false;
            transform.Rotate(0f,180f,0f);
            EryaAnim.SetBool("_isRight", false);
        }
    }
}
