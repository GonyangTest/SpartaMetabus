using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private float _offsetX;
    void Start()
    {
        if(_target == null)
        {
            Debug.LogError("Target is not assigned");
            return;
        }

        _offsetX = transform.position.x - _target.transform.position.x;    
    }

    void Update()
    {
        if(_target == null)
        {
            Debug.LogError("Target is not assigned");
            return;
        }

        Vector3 pos = transform.position;
        pos.x = _target.transform.position.x + _offsetX;
        transform.position = pos;
    }
}
