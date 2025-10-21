using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDead = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    void Update()
    {
        if (isDead) return;

        // Spaceでジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    // 接地判定
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void Die()
    {
        isDead = true;
        rb.velocity = Vector2.zero;
        // アニメーションやリスポーン処理などもここで呼び出し可能
        Debug.Log("Player Dead!");
    }
}