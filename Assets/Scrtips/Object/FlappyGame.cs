using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyGame : InteractableObject
{
    public override void Interact()
    {
        GameManager.Instance.FlappyBird();
    }
}
