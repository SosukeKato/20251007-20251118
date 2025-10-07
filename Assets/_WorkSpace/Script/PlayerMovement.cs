using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;     // �W�����v��
    private Rigidbody2D rb;          // Rigidbody2D�̎Q��
    private bool isGrounded = false; // �n�ʂɂ��邩�ǂ���

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D�擾
    }

    void Update()
    {
        // �X�y�[�X�L�[�ŃW�����v�i�n�ʂɂ��鎞�����j
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // �n�ʂɐڐG������W�����v�\�ɖ߂�
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
