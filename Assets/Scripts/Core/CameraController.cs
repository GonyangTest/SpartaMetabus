using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private float _offsetX;
    void Start()
    {
        if(_target == null)
        {
            Debug.LogError("Target is not assigned");
            // _target = GameObject.FindGameObjectWithTag("Player"); // TOOD: 확인 필요
            return;
        }

        _offsetX = transform.position.x - _target.transform.position.x;    
    }

    void LateUpdate()
    {
        if(_target == null)
        {
            Debug.LogError("Target is not assigned");
            // _target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        Vector3 pos = transform.position;
        pos.x = _target.transform.position.x + _offsetX;
        transform.position = pos;
    }
}
