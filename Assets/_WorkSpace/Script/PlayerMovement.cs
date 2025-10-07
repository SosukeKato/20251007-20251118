using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;     // ジャンプ力
    private Rigidbody2D rb;          // Rigidbody2Dの参照
    private bool isGrounded = false; // 地面にいるかどうか

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D取得
    }

    void Update()
    {
        // スペースキーでジャンプ（地面にいる時だけ）
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // 地面に接触したらジャンプ可能に戻す
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
