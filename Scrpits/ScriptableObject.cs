using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObject : MonoBehaviour
{
    public float enemiesKO;
    void Start()
    {
        enemiesKO =0;
    }
    public void murder()
    {
        enemiesKO =1;
    }
}
