using UnityEngine;

public class RisingGround : MonoBehaviour
{
    [Header("上昇速度 (1.0 = ゆっくり)")]
    public float moveSpeed = 1.0f;


    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("プレイヤーが地面に当たって死亡！");
            Destroy(collision.gameObject); // プレイヤーを削除
        }
    }
}

