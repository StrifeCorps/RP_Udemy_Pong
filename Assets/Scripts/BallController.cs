using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BallController : MonoBehaviour
{
	AudioSource sfx;
	Rigidbody2D rb;
	Renderer renderer;
	Vector2 velocity;
	Vector2 startPosition;
	GameManager gameManager;

	bool isRespawning;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		renderer = GetComponent<Renderer>();
		sfx = GetComponent<AudioSource>();
		startPosition = transform.position;
		isRespawning = false;
	}

	private void Start()
	{
		gameManager = FindFirstObjectByType<GameManager>();
		velocity = InitiliazeVelocity();
		rb.linearVelocity = velocity;
		sfx.volume = gameManager.volumeSlider.value/2f;
	}

	private void FixedUpdate()
	{
		velocity = rb.linearVelocity;
		if(!renderer.isVisible) ResetBall();
		if(rb.linearVelocity == Vector2.zero && !isRespawning) ResetBall();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		rb.linearVelocity = Vector2.Reflect(velocity, collision.GetContact(0).normal);

		if (collision.gameObject.GetComponent<Player_Controller>() != null)
		{
			rb.linearVelocity *= 1.1f;
		}

		sfx.Play();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (gameManager != null)
		{
			if (collision.gameObject.name == "obj_right_goal")
			{
				gameManager.UpdateScore(1, 0);
			}
			else if (collision.gameObject.name == "obj_left_goal")
			{
				gameManager.UpdateScore(0, 1);
			}
		}

		ResetBall();
	}

	private void ResetBall()
	{
		rb.linearVelocity = Vector2.zero;
		transform.position = startPosition;
		
		StartCoroutine(BallRespawnTimer(1f));
	}

	private IEnumerator BallRespawnTimer(float time)
	{
		isRespawning = true;
		yield return new WaitForSeconds(time);
		rb.linearVelocity = InitiliazeVelocity();
		Debug.Log("Ball Respawned");
		isRespawning = false;
	}

	private Vector2 InitiliazeVelocity()
	{
		int directionX;
		float directionY;
		do
		{
			directionX = Random.Range(-1, 2);
		}
		while (directionX == 0);
		do
		{
			directionY = Random.Range(-1f, 1f);
		}
		while (directionY == 0 || (directionY <= .3f && directionY >= -.3f));

		var initialVelocity = new Vector2(directionX, directionY) * 5f;
		return initialVelocity;
	}
}
