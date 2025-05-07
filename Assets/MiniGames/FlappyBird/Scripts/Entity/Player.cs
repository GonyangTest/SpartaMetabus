using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _flapForce;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isDead = false;
    private bool _isFlap = false;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if(_isDead)
        {
            // 게임 오버 상태에서 Q 키를 누르면 메인 씬으로 돌아가기
            if(Input.GetKey(KeyManager.Instance.QuitKey))
            {
                Debug.Log("Q 키 입력 감지: 메인 씬으로 돌아갑니다.");
                FlappyBirdGameManager.Instance.ReturnMainScene();
            }
            // 게임 오버 상태에서 R 키를 누르면 게임 재시작
            else if(Input.GetKey(KeyManager.Instance.RestartKey))
            {
                Debug.Log("R 키 입력 감지: 게임을 재시작합니다.");
                FlappyBirdGameManager.Instance.Restart();
            }
        }
        else
        {
            // 게임 진행 중에 마우스 왼쪽 버튼을 클릭하면 점프
            if(Input.GetMouseButtonDown(0))
            {
                _isFlap = !_isFlap;
            }
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
            // _isFlap = false;
        }
        else
        {
            velocity.y = -_flapForce;
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

        _animator.SetTrigger("IsDie");
        FlappyBirdGameManager.Instance.GameEnd();
    }
}
