using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float InteractionRange = 10f;
    public Camera Camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InteractWithObject();
        }
    }

    private void InteractWithObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, InteractionRange))
        {
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
            else
            {
                Debug.Log("No interactable object detected");
            }
        }
    }
}