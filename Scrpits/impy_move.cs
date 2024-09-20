using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class impy_move : MonoBehaviour
{
	public int health = 120;
	private int maxHealth = 120;
	public bool _deadImp = false;
	public HealthBar healthBar;
	float _deadTime;
	public Collider2D Collider1;
	public Collider2D Collider2;
	[SerializeField] private float m_JumpForce = 400f;									
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	
	[SerializeField] private bool m_AirControl = false;							
	[SerializeField] private LayerMask m_WhatIsGround;							
	[SerializeField] private Transform m_GroundCheck;													
    float horizontalmove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
	public Animator ImpyAnim;
	const float k_GroundedRadius = .2f; 
	private bool m_Grounded;            
	const float k_CeilingRadius = .2f; 
	private Rigidbody2D m_Rigidbody2D;
	public bool m_FacingRight = true;  
	private Vector3 m_Velocity = Vector3.zero;
	bool _dodge = false;
	public float _dodgeTime = 2f;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	void Start()
	{
		_deadTime = 2f;
		health = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

	}

	void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;
		ImpyAnim.SetBool("_isJumping", true);

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
					ImpyAnim.SetBool("_isJumping", false);
			}
		}
        Move(horizontalmove * Time.fixedDeltaTime, jump);
        jump = false;
		if (_dodge == true)
		{
			_dodgeTime -= Time.fixedDeltaTime;
			if (_dodgeTime <= 0f)
			{
				_dodgeTime = 2f;
				_dodge = false;
			}
		}
		if(_deadImp == true)
		{
			_deadTime -= Time.fixedDeltaTime;
			if(_deadTime <= 0)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}


	}


	public void Move(float move, bool jump)
	{
		if (m_Grounded || m_AirControl)
		{


			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
		}
		if (m_Grounded && jump)
		{
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}
	public void Flip()
	{
		m_FacingRight = !m_FacingRight;

		transform.Rotate(0f,180f,0f);
	}

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        horizontalmove =  Input.GetAxisRaw("Horizontal") *runSpeed;
		if(m_FacingRight)
		{
			ImpyAnim.SetBool("_isRight", true);
		}
		else
		{
			ImpyAnim.SetBool("_isRight", false);
		}
		if(m_Rigidbody2D.velocity.x > 4 || m_Rigidbody2D.velocity.x < -4)
		{
			ImpyAnim.SetBool("_isMoving", true);
		}
		else
		{
			ImpyAnim.SetBool("_isMoving", false);
		}
		if (Input.GetButtonDown("Dodge") && _dodgeTime == 2f && m_FacingRight == true)
		{
			_dodge = true;
			m_Rigidbody2D.AddForce(new Vector2(700f, 100f));
		}
		if (Input.GetButtonDown("Dodge") && _dodgeTime == 2f && m_FacingRight == false)
		{
			_dodge = true;
			m_Rigidbody2D.AddForce(new Vector2(-700f, 100f));
		}

    }
	public void takeDamage( int damage)
    {
		ImpyAnim.SetTrigger("_knockedBack");
        health -= damage;
		healthBar.SetHealth(health);
		if(m_FacingRight == true)
		{
			m_Rigidbody2D.AddForce(new Vector2 (-200f,85f));
		}
		else
		{
			m_Rigidbody2D.AddForce(new Vector2(200f,85f));
		}

        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
		//health = maxhealth;
		//transform.position = _respawn.transform.position + new Vector3(0,0, -3);
		//ImpyAnim.SetTrigger("_isDead");
		//Debug.Log("should respawn");
		//everything above here is completely useless... this took me 7 months to figure out dear god
		Collider1.enabled = false;
		Collider2.enabled = false;
		ImpyAnim.SetTrigger("_isDead");
		GameObject player = GameObject.FindWithTag("Player"); 
        player.GetComponent<Impy_attacks>().enabled = false;
		_deadImp = true;
		m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
		
    }
}
//Movement code written in large part by Brackeys on youtube, if you're seeing this go check em out!
