using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Transform _player;
    private float _time = 0;
    private bool _isgrounded = false;
    public float _jumpforce = 0.01f;
    [SerializeField] float _JumpingMoveSpeed = 10;
    [SerializeField] float _Maxjumptime =3;
    [SerializeField] float _deadzone = 1;
    Rigidbody2D _Rb2D;
    private float _direction = 0;
    void Start()
    {
        _Rb2D = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isgrounded = true;
        }
    }
    void Update()
    {

        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ��ʏ�̃}�E�X���W���Q�[�����̃��[���h���W�ɕϊ����Ď擾����

        float dx = mousepos.x - _player.position.x;
        if (dx > 0)//�v���C���[���E�������Ă�����
        {
            _player.localScale = new Vector3(-1, 1, 1);
            _direction = 1;
        }
        if (dx < 0)//�v���C���[�����������Ă�����
        {
            _player.localScale = new Vector3(1, 1, 1);
            _direction = -1;
        }
        if (Mathf.Abs(dx) < _deadzone)
        {
            _direction = 0;
        }
        if (Input.GetMouseButton(0) && _isgrounded == true)
        {
            _time += Time.deltaTime;
            if (_time > _Maxjumptime)
            {
                Debug.Log("�ő�");
                _time = _Maxjumptime;
            }
            Debug.Log(_time + "�b�W�����v���߂Ă܂�");
        }
        if (Input.GetMouseButtonUp(0))
        {
            _Rb2D.AddForce(Vector2.up * _jumpforce * _time + Vector2.right * _direction * _JumpingMoveSpeed);
            Debug.Log(Vector2.up * _jumpforce * _time);
            _isgrounded = false;
            _time = 0;
        }
        if (!_isgrounded)
        {
            float gravity = Time.deltaTime * _Rb2D.gravityScale;
            _Rb2D.velocity += Vector2.down * gravity;
        }
    }
}
