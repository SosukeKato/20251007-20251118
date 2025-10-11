using UnityEngine;

public class CameraFollowY : MonoBehaviour
{
    public Transform target;      // プレイヤー
    public float smoothSpeed = 5f;
    public float yOffset = 1f;
    public float minY = 0f;       // 地面（カメラが下がりすぎない制限）

    private float fixedX;         // X軸固定用

    void Start()
    {
        // 初期X位置を固定
        fixedX = transform.position.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 目標のY位置（プレイヤーのY + オフセット）
        float targetY = target.position.y + yOffset;

        // スムーズに補間
        float newY = Mathf.Lerp(transform.position.y, targetY, Time.deltaTime * smoothSpeed);

        // カメラが地面より下がらないよう制限
        newY = Mathf.Max(newY, minY);

        // カメラ位置を反映（Xは固定）
        transform.position = new Vector3(fixedX, newY, transform.position.z);
    }
}