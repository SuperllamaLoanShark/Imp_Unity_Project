using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class theron : MonoBehaviour
{
    GameObject player;
    Animator theronAnim;
    bool IsRight = true;
    public GameObject SpeakButton;
    void Start()
    {
        SpeakButton.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        theronAnim = GetComponent<Animator>();
        //impy_move move = player.GetComponent<impy_move>();
    }
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance<5f)
        {
            SpeakButton.SetActive(true);
        }
        else
        {
            SpeakButton.SetActive(false);
        }
        if (player.transform.position.x > transform.position.x && IsRight == false)
        {
            IsRight = true;
            transform.Rotate(0f,180f,0f);
            theronAnim.SetBool("_isRight", true);
        }
        if (player.transform.position.x < transform.position.x && IsRight == true)
        {
            IsRight = false;
            transform.Rotate(0f,180f,0f);
            theronAnim.SetBool("_isRight", false);
        }
    }
}
