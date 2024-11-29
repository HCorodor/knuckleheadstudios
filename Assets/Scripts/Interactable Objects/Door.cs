using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Animator Animator;
    public bool IsOpen = false;

    public void Interact()
    {
        if (!IsOpen)
        {
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        IsOpen = true;
        Animator.Play("DoorOpen");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(5f);
        Animator.Play("Idle");
        IsOpen = false;
    }
}
