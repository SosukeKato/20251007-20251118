using UnityEngine;

public class RisingGround : MonoBehaviour
{
    [Header("�㏸���x (1.0 = �������)")]
    public float moveSpeed = 1.0f;

    [Header("���B���鍂�� (Y���W)")]
    public float targetHeight = 5.0f;

    private bool isRising = true;

    void Update()
    {
        if (isRising)
        {
            // ���݈ʒu���擾
            Vector3 pos = transform.position;

            // ��葬�x�ŏ㏸
            pos.y += moveSpeed * Time.deltaTime;

            // �ڕW�����𒴂������~
            if (pos.y >= targetHeight)
            {
                pos.y = targetHeight;
                isRising = false;
            }

            // �ʒu�𔽉f
            transform.position = pos;
        }
    }
}

