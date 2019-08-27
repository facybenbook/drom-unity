﻿using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown("e"))
        {
            this.SendMessage("OnInteract");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isPlayerNear = true;
            GameObject.Find("Canvas").BroadcastMessage("ShowInteractionSuggestion", this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isPlayerNear = false;
            GameObject.Find("Canvas").BroadcastMessage("HideInteractionSuggestion", this.gameObject);
        }
    }
}
