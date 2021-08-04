using UnityEngine;

public class Player_move: MonoBehaviour
{
    bool crouch_flag = false;
    public Animator animator;
    public BoxCollider2D boxCollider2D;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        Player_standFlip(horizontal);
        Player_crouch_jump(vertical);
        Player_movement(horizontal);
        //debugIt();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision true" + collision.gameObject.name);
    }
    public void Player_standFlip(float horizontal)
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        Vector3 player_flipper = transform.localScale;
        if (horizontal < 0)
        {
            player_flipper.x = -1f * Mathf.Abs(player_flipper.x);
        }
        else if(horizontal > 0)
        {
            player_flipper.x = Mathf.Abs(player_flipper.x);
        }

        transform.localScale = player_flipper;
    }
    public void Player_crouch_jump(float vertical)
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch_flag = !crouch_flag;                 // changing crouch flag true if false and false if true.
        }
        if (crouch_flag == true)
        {
            animator.SetBool("Crouch", crouch_flag);
            //boxCollider2D.siz

        }
        else if (crouch_flag == false)
        {
            animator.SetBool("Crouch", crouch_flag);
        }
        //Jump
        if (vertical > 0)
        {
        animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }

        if (vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }



    }
    public void Player_movement(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }
}
