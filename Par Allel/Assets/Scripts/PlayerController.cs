using System.Collections;
using Unity.Loading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject other;
    Rigidbody2D rb, otherRb;
    [SerializeField] Transform[] groundChecks, wallChecks, roofChecks;
    [SerializeField] LayerMask groundLayer, wallLayer;
    [SerializeField] bool isGrounded, isCapped, isLeftWalled, isRightWalled;
    private float xDir = 0;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        otherRb = other.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        inputManager = GameObject.Find("TouchManager").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xDir = inputManager.movementInput;

        isGrounded = Physics2D.OverlapBox((Vector2) groundChecks[0].position - new Vector2(0, 0.515f), new Vector2(.9f, .015f), 0, groundLayer)
            || Physics2D.OverlapBox((Vector2) groundChecks[1].position - new Vector2(0, 0.515f), new Vector2(.9f, .015f), 0, groundLayer);
        isCapped = Physics2D.OverlapBox((Vector2) roofChecks[0].position + new Vector2(0, 0.515f), new Vector2(.9f, .015f), 0, groundLayer)
            || Physics2D.OverlapBox((Vector2) roofChecks[1].position + new Vector2(0, 0.515f), new Vector2(.9f, .015f), 0, groundLayer);
        isLeftWalled = Physics2D.OverlapBox((Vector2)wallChecks[0].position - new Vector2(0.5f, 0), new Vector2(.03f, 1f), 0, wallLayer)
            || Physics2D.OverlapBox((Vector2)wallChecks[1].position + new Vector2(0.5f, 0), new Vector2(.03f, 1f), 0, wallLayer);
        isRightWalled = Physics2D.OverlapBox((Vector2)wallChecks[2].position + new Vector2(0.5f, 0), new Vector2(.03f, .9f), 0, wallLayer)
            || Physics2D.OverlapBox((Vector2)wallChecks[3].position - new Vector2(0.5f, 0), new Vector2(.03f, .9f), 0, wallLayer);

        if ((isRightWalled && xDir > 0) || (isLeftWalled && xDir < 0)) xDir = 0;

        transform.Translate(new Vector3(xDir * 10, 0, 0) * Time.deltaTime);
        other.transform.Translate(new Vector3(-xDir * 10, 0, 0) * Time.deltaTime);

        if (isGrounded)
        {
            if (rb.velocity.y < 0 || otherRb.velocity.y < 0)
            {
                rb.velocity *= new Vector2(1, 0);
                otherRb.velocity *= new Vector2(1, 0);
                rb.gravityScale = 0;
                otherRb.gravityScale = 0;
            }
            if (Physics2D.OverlapBox((Vector2)groundChecks[0].position - new Vector2(0, 0.515f), new Vector2(1f, .015f), 0, groundLayer) && transform.position.y != other.transform.position.y)
            {
                other.transform.position = transform.position * new Vector2(-1, 1);
            }
            else if (Physics2D.OverlapBox((Vector2)groundChecks[1].position - new Vector2(0, 0.515f), new Vector2(1f, .015f), 0, groundLayer) && transform.position.y != other.transform.position.y)
            {
                transform.position = other.transform.position * new Vector2(-1, 1);
            }
        }
        else
        {
            rb.gravityScale = 1;
            otherRb.gravityScale = 1;
        }

        if (isCapped) StartCoroutine(StopJump());
    }

    private void Update()
    {
        if (inputManager.isJumping && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            otherRb.velocity = new Vector2(otherRb.velocity.x, 10f);
        }
        /*if (Input.GetButtonUp("Jump"))
        {
            StartCoroutine(StopJump());
        }*/
    }

    private IEnumerator StopJump()
    {
        if (rb.velocity.y > 0 || otherRb.velocity.y > 0)
        {
            rb.velocity *= new Vector2(1, 0);
            otherRb.velocity *= new Vector2(1, 0);
        }
        yield return new WaitForSeconds(.02f);
    }

    public void Left()
    {
        xDir = 1;
    }

    public void Right()
    {
        xDir = -1;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            otherRb.velocity = new Vector2(otherRb.velocity.x, 10f);
        }
    }
}
