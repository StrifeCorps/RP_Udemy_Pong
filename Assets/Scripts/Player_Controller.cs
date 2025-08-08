using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    private Rigidbody2D rb;
    private Collider2D collider;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0) { Movement(); }
    }

	void Movement()
	{
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 velocity = new Vector2(0, moveVertical);
		rb.MovePosition(rb.position + velocity * speed * Time.fixedDeltaTime);
	}
}
