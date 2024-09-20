using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoraTipoli : MonoBehaviour
{
    public bool _isRight;
    float _attackTime =6f;
    //float _attackWarning = 1f;
    GameObject player;
    Rigidbody2D CoraBod;
    public bool _playerRight;
    Animator CoraAnim;
    float speed = 3000f;
    public GameObject LichenLu;
    public GameObject normSlime;
    public GameObject beanySlime;
    float slimeTime = 20f;
    public Transform enemyspawn;
    public bool _isVunerable;
    float vulnTime = 5f;
    public int health = 1000;
    //float enemyCount;
    void Start()
    {

        _isVunerable = false;
        CoraAnim = GetComponent<Animator>();
        CoraBod = GetComponent<Rigidbody2D>();
        _isRight = false;
        player = GameObject.FindGameObjectWithTag("Player");
        //enemyCount = 0;
    }
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(player.transform.position.x < transform.position.x)
        {
            _playerRight = false;
        }
        if(player.transform.position.x > transform.position.x)
        {
            _playerRight = true;
        }
        if(_isRight == false && _playerRight == true) // && _attackTime >= 1);
        {
            transform.Rotate(0f,180f,0f);
            CoraAnim.SetBool("_isRight", true);
            _isRight = true;
        }
        if(_isRight == true && _playerRight == false) // && _attackTime >= 1);
        {
            transform.Rotate(0f,180f,0f);
            CoraAnim.SetBool("_isRight", false);
            _isRight = false;
        }
    }
    void FixedUpdate()
    {
        GameObject[] babees = GameObject.FindGameObjectsWithTag("baby");
        int babeeCounter = babees.Length;
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance <= 30f)
        {
            if(_isVunerable == false)
            {
                _attackTime -= Time.fixedDeltaTime;
                slimeTime -= Time.fixedDeltaTime;
            }
            if(_attackTime <= 0)
            {
                Lunge();
                _attackTime = 5f;
            }
            if(_attackTime <= 1 && _attackTime >= .95f)
            {
                Debug.Log("Gonna Lunge!");
            }
            if(slimeTime <=0 && _isRight == true && babeeCounter < 4)
            {
                Instantiate(beanySlime, enemyspawn.position, Quaternion.identity);
                slimeTime = 20f;
                //enemyCount=+1;
            }
            if(slimeTime <=0 && _isRight == false && babeeCounter < 4)
            {
                Instantiate(beanySlime, enemyspawn.position, Quaternion.identity);
                slimeTime = 20f;
                //enemyCount=+1; 
            }
            if(_isVunerable == true)
            {
                vulnTime -= Time.fixedDeltaTime;
                if(vulnTime <= 0)
                {
                    _isVunerable = false;
                    vulnTime = 5f;
                }
            }
        }
    }
    void Lunge()
    {
        Vector2 moveDir = (player.transform.position - transform.position).normalized * speed;
        CoraBod.AddForce(new Vector2(moveDir.x, moveDir.y));
    }
    //public void _lessEnemy()
    //{
    //    enemyCount=-1;
    //}
    public void BushHit()
    {
        _isVunerable = true;
        Debug.Log("Is Vulnerable!");
    }
    public void takeDamage(int damage)
    {
        if(_isVunerable == true)
        {
            health -= damage;
        }
        if(health <=0)
        {
            Destroy(gameObject);
        }
    }
}
