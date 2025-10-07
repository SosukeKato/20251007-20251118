using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincamera : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform���w��
    public float jumpCameraOffset = 2f; // �W�����v���̃J������Y�����I�t�Z�b�g
    public float smoothSpeed = 5f; // �J�����ړ��̃X���[�Y��
    public float returnSpeed = 3f; // �J���������̈ʒu�ɖ߂�X�s�[�h

    private Vector3 originalCameraPosition; // �J�����̌��̈ʒu
    private bool isJumping = false; // �v���C���[���W�����v�����ǂ���

    void Start()
    {
        // �J�����̏����ʒu���L�^
        originalCameraPosition = transform.position;
    }

    void Update()
    {
        // �v���C���[�̃W�����v�����m (Rigidbody2D�𗘗p)
        if (player.TryGetComponent(out Rigidbody2D rb))
        {
            if (!isJumping && Mathf.Abs(rb.velocity.y) > 0.1f) // �W�����v�J�n
            {
                isJumping = true;
            }
            else if (isJumping && Mathf.Abs(rb.velocity.y) < 0.1f && rb.velocity.y <= 0) // ���n
            {
                isJumping = false;
            }
        }

        // �J�����̈ʒu���X�V
        if (isJumping)
        {
            // �W�����v���̓J������������Ɉړ�
            Vector3 targetPosition = new Vector3(originalCameraPosition.x, player.position.y + jumpCameraOffset, originalCameraPosition.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
        else
        {
            // ���n��̓J���������̈ʒu�ɖ߂�
            transform.position = Vector3.Lerp(transform.position, originalCameraPosition, returnSpeed * Time.deltaTime);
        }
    }
}