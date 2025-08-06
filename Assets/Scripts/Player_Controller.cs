using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    private Rigidbody2D rb;
    private Collider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rb.linearVelocity = movement * speed * Time.fixedDeltaTime;
    }
}
