using UnityEngine;

public class Player_move: MonoBehaviour
{
    bool crouch_flag = false;
    public Animator animator;
    public BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Player_movement();
        Player_crouch();
        //debugIt();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision true" + collision.gameObject.name);
    }
    public void Player_movement()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(speed));

        Vector3 player_flipper = transform.localScale;
        if (speed < 0)
        {
            player_flipper.x = -1f * Mathf.Abs(player_flipper.x);
        }
        else if(speed > 0)
        {
            player_flipper.x = Mathf.Abs(player_flipper.x);
        }

        transform.localScale = player_flipper;
    }
    public void Player_crouch()
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

    }
}
