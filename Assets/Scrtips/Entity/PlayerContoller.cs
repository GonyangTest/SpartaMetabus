using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : BaseContoller
{
    private Camera _camera;

    protected override void Start()
    {
        base.Start();
        _camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = _camera.ScreenToWorldPoint(mousePosition);
        _lookDirection = worldPosition - (Vector2)transform.position;

        if(_lookDirection.magnitude < 0.9f)
        {
            _lookDirection = Vector2.zero;
        }
        else
        {
            _lookDirection = _lookDirection.normalized;
        }
    }
}
