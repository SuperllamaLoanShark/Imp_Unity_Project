using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeachAI : MonoBehaviour
{
    public int health = 100;
    Rigidbody2D _leachybod;
    public Collider2D facesensor;
    public GameObject _leach;
    public Transform _respawn;
    public GameObject Player;
    public Transform TPlayer;
    public Animator leachAnim;
    public Collider2D WholeLeach;
    public float Speed = 2f;
    public float swoopSpeed = 5f;
    public float distanceThreshold = 5f;
    public float detectRange = 3f;
    public LayerMask playerLayer;
    public LayerMask BrickLayer;

    void Start()
    {
        
        _leachybod = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, TPlayer.position);
        if(IsfacingRight())
        {
            _leachybod.velocity = new Vector2(Speed, 0f);
            leachAnim.SetBool("_isRight", true);
        }
        else
        {
            _leachybod.velocity = new Vector2(-Speed, 0f);
            leachAnim.SetBool("_isRight", false);
        }
        if (TPlayer != null && Mathf.Abs(TPlayer.position.x - transform.position.x) < 0.2f)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, detectRange, playerLayer);
            RaycastHit2D hitGround = Physics2D.Raycast(transform.position, Vector2.down, detectRange, BrickLayer);
            if (hit.collider != null && hitGround.collider != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, TPlayer.position, swoopSpeed * Time.deltaTime);
                Debug.Log("Enemy attacking player!");
            }
        }
    }
    private bool IsfacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(_leachybod.velocity.x)), transform.localScale.y);
    }
    private void OnTriggerEnter2D(Collider2D WholeLeach)
    {
        impy_move enemy = WholeLeach.GetComponent<impy_move>();
        if(enemy != null)
        {
            Debug.Log("Hit!");
            enemy.takeDamage(110);
        }
    }
    public void takeDamage( int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
