using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    private bool isDead;
    public LayerMask whatStopsMovement;
    public LayerMask whatKillsCharacter;
    public Animator anim;

    public CharacterActions characterActions;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }

    public void move(Vector3 moveVector3)
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + moveVector3, .2f, whatStopsMovement))
            {
                if(Physics2D.OverlapCircle(movePoint.position + moveVector3, .2f, whatKillsCharacter))
                {
                    die();
                    Debug.Log(getDead());
                }
                movePoint.position += moveVector3;
            }
        }
    }
    public void die()
    {
        anim.SetBool("dead", true);
        isDead = true;
    }
    public bool getDead()
    {
        return isDead;
    }
}
