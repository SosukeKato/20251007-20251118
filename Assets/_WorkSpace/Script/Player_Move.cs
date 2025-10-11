using Unity.VisualScripting;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Transform _player;
    public float _time = 0;
    public bool _isgrounded = false;
    public float _jumpforce = 1;
    [SerializeField] float _Maxjumptime =5;
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
       
        if (Input.GetMouseButton(0)&&_isgrounded == true)
        {
            _time += Time.deltaTime;
            Debug.Log("ジャンプ溜めてます");
        }
        if (Input.GetMouseButtonUp(0))
        {
              _Rb2D.AddForce(Vector2.up * _jumpforce * _time);
              Debug.Log(Vector2.up * _jumpforce * _time);
              Debug.Log("ジャンプ");
            if (_time > _Maxjumptime)
            {
                _time = _Maxjumptime;
                Debug.Log("最大火力");
            }
              _isgrounded = false;
              _time = 0;
        }
        if (!_isgrounded)
        {
            float gravity = Time.deltaTime * _Rb2D.gravityScale;
            _Rb2D.velocity += Vector2.up * gravity;
        }
       Debug.Log(_isgrounded);
    }
}
