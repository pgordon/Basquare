using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private int playerScore = 0;

    [SerializeField]
    private float velocity = 1f;
    [SerializeField]
    private float jumpAmount = 3f;
    [SerializeField]
    private float climbAmount = 6f;

    [SerializeField]
    private Text scoreDisplay;

    [SerializeField]
    private Transform groundCheck;
    
    [SerializeField]
    private LayerMask whatIsGround;

    private bool onGround;
    private bool againstWall; // used to check if the player's front is against a block but cant fall down and could climb
    private float againstWallWidth = 0.1f;
    private float groundCheckRadius = 0.1f;
    private float groundCheckHeight = 0.005f;
    private float playerBottomWidth = 0.3f;
    private float playersideHeight = 0.3f;

    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerBottomWidth = boxCollider.size.x;
        playersideHeight = boxCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y); // https://answers.unity.com/questions/408072/how-to-add-force-or-velocity-to-the-rigid-body.html
        onGround = Physics2D.OverlapArea( new Vector2(groundCheck.position.x - playerBottomWidth , groundCheck.position.y - groundCheckHeight + 0.05f), 
                                            groundCheck.position, whatIsGround);
        againstWall = Physics2D.OverlapArea(new Vector2(groundCheck.position.x + againstWallWidth , groundCheck.position.y + playersideHeight),
                                            new Vector2(groundCheck.position.x, groundCheck.position.y + 0.05f), whatIsGround );

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)) && againstWall)
        {
            rb.velocity = new Vector2(rb.velocity.x, climbAmount);
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        }
        // would we want the climb height to have a seperate if so that it could move up more against gravity --> based on playtesting and feel
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin c = collision.gameObject.GetComponent<Coin>();

        if (c != null)
        {
            ScoreUpdate(Coin.COIN_WORTH);
            c.Collected();
        }
    }

    private void ScoreUpdate(int change)
    {
        playerScore += change;
        scoreDisplay.text = string.Format("Score: {0}", playerScore);
    }

}
