using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed ;
    private Rigidbody2D rb2d;
    public float jump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }


    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical);
        PlayerMovementAnimation(horizontal, vertical); 
        CrouchControll();
        ;    }

    private void MoveCharacter(float horizontal ,float vertical)
    {

        // move character horizotally 

        Vector3 position = transform.position;
        position.x += horizontal* speed * Time.deltaTime;
        transform.position = position;


        //move characater veritcally 
        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (horizontal > 0)
        {   
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void CrouchControll()
    {
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)){
            animator.SetBool("Crouch", true); 
        }
            else
            {
                animator.SetBool("Crouch", false);
            }
    }

    public void PickKey()
    {
       Debug.Log("Player Picked up the Key");
    }
} 