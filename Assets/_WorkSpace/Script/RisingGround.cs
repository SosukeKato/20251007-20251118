using UnityEngine;

public class RisingGround : MonoBehaviour
{
    [Header("�㏸���x (1.0 = �������)")]
    public float moveSpeed = 1.0f;


    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�v���C���[���n�ʂɓ������Ď��S�I");
            Destroy(collision.gameObject); // �v���C���[���폜
        }
    }
}

