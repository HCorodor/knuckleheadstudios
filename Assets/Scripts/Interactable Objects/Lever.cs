using System.Collections;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public Animator Animator;
    public bool HasSwitched = false;

    public void Interact()
    {
        if (!HasSwitched)
        {
            StartCoroutine(SwitchLever());
        }
    }

    private IEnumerator SwitchLever()
    {
        HasSwitched = true;
        Animator.Play("LeverSwitch");
        yield return new WaitForSeconds(3f);
        Animator.Play("Idle");
        HasSwitched = false;
    }
}
