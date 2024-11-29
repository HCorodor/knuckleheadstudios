using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public Transform CameraTransform;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(moveX, 0, moveZ).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            Vector3 moveDirection = CameraTransform.TransformDirection(inputDirection);
            moveDirection.y = 0f;
            transform.Translate(moveDirection * MovementSpeed * Time.deltaTime, Space.World);
        }

        RotatePlayerToMouse();
    }

    private void RotatePlayerToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 directionToMouse = (hit.point - transform.position).normalized;

            if (directionToMouse.sqrMagnitude > 0f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
    }
}
