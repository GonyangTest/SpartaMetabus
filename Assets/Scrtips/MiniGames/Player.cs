using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _flapForce;
    private Rigidbody2D _rigidbody;

    private bool _isFlap = false;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isFlap = true;
        }
    }

    private void FixedUpdate()
    {
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
}
