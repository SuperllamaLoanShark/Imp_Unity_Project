using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlantSpawn : MonoBehaviour
{
    public GameObject fallingPlant;
    Collider2D PSC;
    float ST = 10f;
    public bool HF;
    void Start()
    {
        HF = false;
        PSC = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D PSC)
    {
        if(fallingPlant != null)
        {
            HF = true;
        }
    }
    public void respawn()
    {
        HF = true;
    }
    void FixedUpdate()
    {
        if(HF == true)
        {
            ST -= Time.fixedDeltaTime;
            if(ST <= 0)
            {
                Debug.Log("spawn");
                Instantiate(fallingPlant, transform.position, Quaternion.identity);
                HF = false;
                ST = 10f;
            }
        }
    }
}
