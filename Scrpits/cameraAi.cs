using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAi : MonoBehaviour
{
    //public Transform Imp;
    //void Update()
    //{
    //    Transform.position = new Vector3(Imp.position, Imp.position, Imp.position);
    //}
    public Transform player;

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}
