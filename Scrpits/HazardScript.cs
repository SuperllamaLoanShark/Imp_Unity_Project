using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    Collider2D box;
    void Update()
    {
        Collider2D box = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D box)
    {
        impy_move enemy = box.GetComponent<impy_move>();
        if(enemy != null)
        {
            enemy.takeDamage(1000);
        }
    }
}
