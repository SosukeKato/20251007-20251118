using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Transform _player;
    private float _time = 0;
    private bool _isgrounded = false;
    public float _jumpforce = 0.01f;
    [SerializeField] float _Maxjumptime =3;
    Rigidbody2D _Rb2D;
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
            _Rb2D.AddForce(Vector2.up * _jumpforce * _time);
            Debug.Log(Vector2.up * _jumpforce * _time);
            _isgrounded = false;
            _time = 0;
        }
        if (!_isgrounded)
        {
            float gravity = Time.deltaTime * _Rb2D.gravityScale;
            _Rb2D.velocity += Vector2.down * gravity;
        }
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 画面上のマウス座標を、ゲーム内のワールド座標に変換して取得する
        if (mousepos.x > _player.position.x)
        {
            _player.localScale = new Vector3(-1, 1, 1);
        }
        if (mousepos.x < _player.position.x)
        {
            _player.localScale = new Vector3(1, 1, 1);
        }
    }
}
