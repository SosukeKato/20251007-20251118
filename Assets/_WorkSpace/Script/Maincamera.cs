using UnityEngine;

public class CameraFollowY : MonoBehaviour
{
    public Transform target;      // �v���C���[
    public float smoothSpeed = 5f;
    public float yOffset = 1f;
    public float minY = 0f;       // �n�ʁi�J�����������肷���Ȃ������j

    private float fixedX;         // X���Œ�p

    void Start()
    {
        // ����X�ʒu���Œ�
        fixedX = transform.position.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // �ڕW��Y�ʒu�i�v���C���[��Y + �I�t�Z�b�g�j
        float targetY = target.position.y + yOffset;

        // �X���[�Y�ɕ��
        float newY = Mathf.Lerp(transform.position.y, targetY, Time.deltaTime * smoothSpeed);

        // �J�������n�ʂ�艺����Ȃ��悤����
        newY = Mathf.Max(newY, minY);

        // �J�����ʒu�𔽉f�iX�͌Œ�j
        transform.position = new Vector3(fixedX, newY, transform.position.z);
    }
}