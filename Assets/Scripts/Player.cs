using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerScore = 0;

    [SerializeField]
    private float velocity = 1f;
    [SerializeField]
    private float jumpAmount = 3f;

    [SerializeField]
    private Transform groundCheck;
    
    [SerializeField]
    private LayerMask whatIsGround;

    private bool onGround;
    private float groundCheckRadius = 0.1f;

    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if(Input.GetMouseButtonDown(0) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Coin c = collision.gameObject.GetComponent<Coin>();
        
        if(c != null)
        {
            playerScore++;
            c.Collected();
        }
    }
}
