using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdCameraController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private float _offsetX;
    private void Start()
    {
        if(_target == null)
        {
            Debug.LogError("Target is not assigned");
            _target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        _offsetX = transform.position.x - _target.transform.position.x;    
    }

    private void LateUpdate()
    {
        if(_target == null)
        {
            Debug.LogError("Target is not assigned");
            _target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        Vector3 pos = transform.position;
        pos.x = _target.transform.position.x + _offsetX;
        transform.position = pos;
    }
}
