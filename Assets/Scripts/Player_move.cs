using UnityEngine;

public class Player_move: MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Player_movement();
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
}
