using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool isGrounded;
    public Transform player;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");

        if (isGrounded && UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            player.transform.Rotate(0f, 180f, 0f);
        }
    }

    public void LoadData(GameData data)
    {
        Vector2 positionTransfer = new Vector2(data.position[0], data.position[1]);
        this.transform.position = positionTransfer;
    }

    public void SaveData(ref GameData data)
    {
        data.position[0] = this.transform.position.x;
        data.position[1] = this.transform.position.y;
    }
}
