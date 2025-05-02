using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private GameObject _textDisplay;
    [SerializeField] private TextMeshProUGUI _text;

    protected string _textContent;

    protected bool _isInteractable = false;
    
    void Start()
    {
        _textContent = $"{KeyManager.Instance.InteractKey.ToString()}를 눌러 상호작용";    
        _text.text = _textContent;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyManager.Instance.InteractKey) && _isInteractable)
        {
            Interact();
        }
    }

    public abstract void Interact();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(Constant.PLAYER_TAG))   
        {
            _textDisplay.SetActive(true);
            _isInteractable = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(Constant.PLAYER_TAG))
        {
            _textDisplay.SetActive(false);
            _isInteractable = false;
        }
    }
}
