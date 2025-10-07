using Unity.VisualScripting;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Transform _player;
    public float _time = 0;
    public bool _isgrounded = false;
    public float _jumpforce = 1;
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
            _isgrounded = false;
        }
       Debug.Log(_isgrounded);
    }
}
