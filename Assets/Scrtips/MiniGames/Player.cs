using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _flapForce;
    private Rigidbody2D _rigidbody;
    private bool _isDead = false;
    private bool _isFlap = false;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if(_isDead) return;
        if(Input.GetMouseButtonDown(0))
        {
            _isFlap = true;
        }
    }

    private void FixedUpdate()
    {
        if(_isDead) return;

        Vector2 velocity = _rigidbody.velocity;
        velocity.x = _forwardSpeed;
        
        if(_isFlap)
        {
            velocity.y = _flapForce;
            _isFlap = false;
        }

        // 회전
        float angle = Mathf.Clamp(_rigidbody.velocity.y * 10f, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);

        _rigidbody.velocity = velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(_isDead) return;

        _isDead = true;
        FlappyBirdGameManager.Instance.GameOver();
    }
}
