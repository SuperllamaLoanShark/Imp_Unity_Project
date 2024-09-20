using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_respawns : MonoBehaviour
{
    public GameObject normSlime;
    public GameObject leach;
    public GameObject jumpoBean;
    public impy_move _playerScript;
    void Start()
    {
        
    }

    void Update()
    {
        //if(GameObject.Find("Imp").GetComponent<impy_move>()._deadImp)
        //{
        //    Destroy(gameObject);
        //    Instantiate(_slimeItself, _respawn.position + new Vector3(0,0, -3), _respawn.rotation);
            //transform.position = _respawn.transform.position + new Vector3(0,0, -3);
        //}
    }
}
