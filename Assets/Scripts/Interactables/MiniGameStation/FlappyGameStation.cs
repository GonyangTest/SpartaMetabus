using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyGameStation : InteractableObject
{
    public override void Interact()
    {
        GameManager.Instance.FlappyBird();
    }
}
