using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerController : BaseController
{
    private Camera _camera;
    private List<IInteractableObject> _interactablesInRange = new List<IInteractableObject>();

    private IInteractableObject _interactable;
    private GameObject _interactText;

    protected void Start()
    {
        _camera = Camera.main;
    }
    public void OnMove(InputValue inputValue)
    {
        Debug.Log("OnMove: " + inputValue.Get<Vector2>());
        _movementDirection = inputValue.Get<Vector2>();
        _movementDirection = _movementDirection.normalized;
    }

    public void OnLook(InputValue inputValue)
    {
        Vector2 mousePosition = inputValue.Get<Vector2>();
        Vector2 worldPosition = _camera.ScreenToWorldPoint(mousePosition);
        _lookDirection = worldPosition - (Vector2)transform.position;

        if(_lookDirection.magnitude < Constant.PLAYER_LOOK_DISTANCE_THRESHOLD)
        {
            _lookDirection = Vector2.zero;
        }
        else
        {
            _lookDirection = _lookDirection.normalized;
        }
    }

    public void OnInteract(InputValue inputValue)
    {
        if(inputValue.isPressed && _interactable != null)
        {
            UpdateClosestInteractable();
            _interactable.Interact();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(Constant.INTERACTABLE_TAG))   
        {
            _interactText.SetActive(true);
            _interactable = other.gameObject.GetComponent<IInteractableObject>();
            _interactablesInRange.Add(_interactable);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(Constant.INTERACTABLE_TAG))
        {
            _interactable = other.gameObject.GetComponent<IInteractableObject>();
            _interactablesInRange.Remove(_interactable);
            Debug.Log("interactablesInRange: " + _interactablesInRange.Count);
            if(_interactablesInRange.Count == 0)
            {
                _interactText.SetActive(false);
            }
        }
    }

    private void UpdateClosestInteractable()
    {
        if (_interactablesInRange.Count == 0)
        {
            _interactable = null;
            return;
        }

        _interactable = _interactablesInRange
            .OrderBy(i => Vector2.Distance(transform.position, ((MonoBehaviour)i).transform.position))
            .FirstOrDefault();
    }
}
