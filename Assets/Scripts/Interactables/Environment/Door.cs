using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private GameObject _openDoor;
    [SerializeField] private GameObject _closeDoor;

    private bool _isOpen = false;

    public override void Interact()
    {
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
