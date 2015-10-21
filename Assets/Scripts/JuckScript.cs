using UnityEngine;
using System.Collections;
using System.Threading;

public class JuckScript : MonoBehaviour
{

    public float jumpForce;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask whatIsGround;

    private GameScript gameScript;

 
    private float timer = 0.6f;
    private bool game = true;

    void Awake()
    {
        gameScript = GameObject.Find("Game").GetComponent<GameScript>();
    }

   void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        foreach (Touch touch in Input.touches)
        {
            if (touch.fingerId == 0 && grounded && (touch.phase == TouchPhase.Began))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            }
        }


        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }

        if(grounded)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }

        if (!game)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                gameScript.DieJeck();
                game = true;
                timer = 1.5f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Box")
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<Rigidbody2D>().freezeRotation = false;
            GetComponent<Rigidbody2D>().rotation = -43f;

            gameScript.StopCreateBox();
            game = false;
        }

    }

 
}
