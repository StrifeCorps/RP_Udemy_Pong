using NUnit.Framework.Constraints;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] BallController ballController;
	Rigidbody2D rb;
    [SerializeField] int speed;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Start()
    {
        ballController = FindFirstObjectByType<BallController>();
    }

	// Update is called once per frame
	private void FixedUpdate()
	{
		Movement();
	}

	void Movement()
	{
		var moveVertical = new Vector2(rb.position.x, ballController.transform.position.y);
		this.transform.position = Vector2.MoveTowards(rb.position, moveVertical, speed * Time.fixedDeltaTime);
	}
}
