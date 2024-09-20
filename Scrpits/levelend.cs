using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelend : MonoBehaviour
{
    public Collider2D LevelBod; 
    private void OnTriggerEnter2D(Collider2D LevelBod)
    {
        impy_move enemy = LevelBod.GetComponent<impy_move>();
        if(enemy != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
