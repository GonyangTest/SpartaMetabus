using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private float _offsetX;
    private float _offsetY;
    private void Start()
    {
        if(_target == null)
        {
            Debug.LogError("Target is not assigned");
            _target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        _offsetX = transform.position.x - _target.transform.position.x;    
        _offsetY = transform.position.y - _target.transform.position.y;    
    }

    void LateUpdate()
    {
        if(_target == null)
        {
            Debug.LogError("Target is not assigned");
            _target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        Vector3 pos = transform.position;
        pos.x = _target.transform.position.x + _offsetX;
        pos.y = _target.transform.position.y + _offsetY;
        transform.position = pos;
    }
}
