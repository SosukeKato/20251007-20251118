using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincamera : MonoBehaviour
{
    public Transform player; // プレイヤーのTransformを指定
    public float jumpCameraOffset = 2f; // ジャンプ時のカメラのY方向オフセット
    public float smoothSpeed = 5f; // カメラ移動のスムーズさ
    public float returnSpeed = 3f; // カメラが元の位置に戻るスピード

    private Vector3 originalCameraPosition; // カメラの元の位置
    private bool isJumping = false; // プレイヤーがジャンプ中かどうか

    void Start()
    {
        // カメラの初期位置を記録
        originalCameraPosition = transform.position;
    }

    void Update()
    {
        // プレイヤーのジャンプを検知 (Rigidbody2Dを利用)
        if (player.TryGetComponent(out Rigidbody2D rb))
        {
            if (!isJumping && Mathf.Abs(rb.velocity.y) > 0.1f) // ジャンプ開始
            {
                isJumping = true;
            }
            else if (isJumping && Mathf.Abs(rb.velocity.y) < 0.1f && rb.velocity.y <= 0) // 着地
            {
                isJumping = false;
            }
        }

        // カメラの位置を更新
        if (isJumping)
        {
            // ジャンプ中はカメラを上方向に移動
            Vector3 targetPosition = new Vector3(originalCameraPosition.x, player.position.y + jumpCameraOffset, originalCameraPosition.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
        else
        {
            // 着地後はカメラを元の位置に戻す
            transform.position = Vector3.Lerp(transform.position, originalCameraPosition, returnSpeed * Time.deltaTime);
        }
    }
}