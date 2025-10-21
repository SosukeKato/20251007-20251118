using UnityEngine;

public class RisingGround : MonoBehaviour
{
    [Header("上昇速度 (1.0 = ゆっくり)")]
    public float moveSpeed = 1.0f;

    [Header("到達する高さ (Y座標)")]
    public float targetHeight = 5.0f;

    private bool isRising = true;

    void Update()
    {
        if (isRising)
        {
            // 現在位置を取得
            Vector3 pos = transform.position;

            // 一定速度で上昇
            pos.y += moveSpeed * Time.deltaTime;

            // 目標高さを超えたら停止
            if (pos.y >= targetHeight)
            {
                pos.y = targetHeight;
                isRising = false;
            }

            // 位置を反映
            transform.position = pos;
        }
    }
}

