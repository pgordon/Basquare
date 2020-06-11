using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private int playerScore = 0;

    [SerializeField]
    private float velocity = 1f;
    [SerializeField]
    private float jumpAmount = 3f; //7.1 is good for current level design but not neccecsarrly all possoble

    [SerializeField]
    private Text scoreDisplay;

    [SerializeField]
    private Transform groundCheck;
    
    [SerializeField]
    private LayerMask whatIsGround;

    private bool onGround;
    private float groundCheckRadius = 0.1f;
    private float groundCheckHeight = 0.005f;
    private float playerBottomWidth = 0.3f;

    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerBottomWidth = boxCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y); // https://answers.unity.com/questions/408072/how-to-add-force-or-velocity-to-the-rigid-body.html
        //onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        onGround = Physics2D.OverlapArea(groundCheck.position, new Vector2(groundCheck.position.x + playerBottomWidth -0.1f, groundCheck.position.y - groundCheckHeight), whatIsGround);

        if ( (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0) ) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        }        

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
