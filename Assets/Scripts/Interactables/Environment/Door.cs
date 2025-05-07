using UnityEngine;

public class Door : MonoBehaviour, IInteractableObject
{
    [SerializeField] private GameObject _openDoor;
    [SerializeField] private GameObject _closeDoor;

    private bool _isOpen = false;

    public void Interact()
    {
        Debug.Log("Interact");
        if(_isOpen)
        {
            _openDoor.SetActive(false);
            _closeDoor.SetActive(true);
        }
        else
        {
            _openDoor.SetActive(true);
            _closeDoor.SetActive(false);
        }
        _isOpen = !_isOpen;
    }
}
