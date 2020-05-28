using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    public Transform player;

    public string InteractText = "Press E to ";

    private void Update()
    {
        float distance = Vector2.Distance(player.position, interactionTransform.position);
        if (distance <= radius)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    public virtual void Interact() 
    {
        
    }
}
