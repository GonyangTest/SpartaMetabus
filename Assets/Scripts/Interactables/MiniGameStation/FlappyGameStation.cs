using UnityEngine;

public class FlappyGameStation : MonoBehaviour, IInteractableObject
{
    public void Interact()
    {
        GameManager.Instance.FlappyBird();
    }
}
