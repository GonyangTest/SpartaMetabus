using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private string _interactionKey = "E";
    [SerializeField] private GameObject _textDisplay;
    [SerializeField] private TextMeshProUGUI _text;

    private string _textContent;

    private bool _isInteractable = false;
    
    void Start()
    {
        _textContent = $"{_interactionKey} key to interact";    
        _text.text = _textContent;
    }

    void Update()
    {
        if(Input.GetKeyDown("e") && _isInteractable)
        {
            Interact();
        }
    }

    public abstract void Interact();

    public void OnTriggerEnter2D(Collider2D other)
    {
        _textDisplay.SetActive(true);
        _isInteractable = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        _textDisplay.SetActive(false);
        _isInteractable = false;
    }
}
