using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Select();
        }
    }

    private void Select()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var interactable = GetComponent<IInteractable>();

        if (Physics.Raycast(ray, out var hitInfo))
        {
            var selectableObject = hitInfo.collider.GetComponent<InteractableObject>();

            if (selectableObject == this && interactable != null)
            {
                interactable.ExecuteInteraction();
            }
        }
    }
}
