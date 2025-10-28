using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Transform _player;
    private float _time = 0;
    private bool _isgrounded = false;
    private bool _isfall = false;
    public float _jumpforce = 0.01f;
    [Header("ジャンプ中の移動スピード"),SerializeField] float _JumpingMoveSpeed = 10;
    [Header("ジャンプの最大時間"),SerializeField] float _Maxjumptime =3;
    [SerializeField] float _deadzone = 1;//playerの真上の判定を取るための変数
    Rigidbody2D _Rb2D;
    private float _direction = 0;
    Animator _anim;
    void Start()
    {
        _Rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isgrounded = true;
            _isfall = false;
            _anim.SetBool("isJumping", false);
            _anim.SetBool("isfall", false);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isgrounded = false;
            _anim.SetBool("isJumping", true);
        }
    }
    void Update()
    {
        Debug.Log(_isgrounded);
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 画面上のマウス座標をゲーム内のワールド座標に変換して取得する

        float dx = mousepos.x - _player.position.x;//プレイヤーとマウスの距離
        if (dx > 0)//プレイヤーが右を向いていたら
        {
            _player.localScale = new Vector3(1, 1, 1);
            _direction = 1;
        }
        if (dx < 0)//プレイヤーが左を向いていたら
        {
            _player.localScale = new Vector3(-1, 1, 1);
            _direction = -1;
        }
        if (Mathf.Abs(dx) < _deadzone)//マウスがプレイヤーの真上にあったら
        {
            _direction = 0;
        }
        if (_isgrounded)
        {
            _isfall = false;
        }
        else if (_Rb2D.velocity.y < -0.01f)
        {
            _isfall = true;
        }
        _anim.SetBool("isfall", _isfall);
        if (Input.GetMouseButton(0) && _isgrounded == true)
        {
            _time += Time.deltaTime;
            if (_time > _Maxjumptime)
            {
                Debug.Log("最大");
                _time = _Maxjumptime;
            }
            Debug.Log(_time + "秒ジャンプ溜めてます");
        }
        if (Input.GetMouseButtonUp(0))
        {
            _Rb2D.AddForce(Vector2.up * _jumpforce * _time + Vector2.right * _direction * _JumpingMoveSpeed);
            Debug.Log(Vector2.up * _jumpforce * _time);
            _time = 0;
        }
        if (!_isgrounded)
        {
            float gravity = Time.deltaTime * _Rb2D.gravityScale;
            _Rb2D.velocity += Vector2.down * gravity;
        }
    }
}
