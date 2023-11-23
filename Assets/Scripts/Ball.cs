using UnityEngine;

public class Ball : MonoBehaviour
{
	public float jumpSpeed = 5;
	Rigidbody2D rb;
	public bool isGrounded;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		var hor = Input.GetAxisRaw("Horizontal");

		rb.AddForce(new Vector2(hor, 0));

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			rb.velocity += Vector2.up * jumpSpeed;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		isGrounded = true;

		if (other.gameObject.CompareTag("Enemy"))
		{
			Die();
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		isGrounded = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GameManager.instance.Win();
	}

	void Die()
	{
		// die sounds and particles
		GameManager.instance.Lose();
	}
}