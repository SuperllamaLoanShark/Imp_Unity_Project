using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AesonScript : MonoBehaviour
{GameObject player;
    Animator AesonAnim;
    bool IsRight = true;
    public GameObject AesonSpeakButton;
    void Start()
    {
        AesonSpeakButton.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        AesonAnim = GetComponent<Animator>();
    }
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance<5f)
        {
            AesonSpeakButton.SetActive(true);
        }
        else
        {
            AesonSpeakButton.SetActive(false);
        }
        if (player.transform.position.x > transform.position.x && IsRight == false)
        {
            IsRight = true;
            transform.Rotate(0f,180f,0f);
            AesonAnim.SetBool("_isRight", true);
        }
        if (player.transform.position.x < transform.position.x && IsRight == true)
        {
            IsRight = false;
            transform.Rotate(0f,180f,0f);
            AesonAnim.SetBool("_isRight", false);
        }
    }
}
