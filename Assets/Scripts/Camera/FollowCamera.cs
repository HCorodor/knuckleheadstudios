using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Player;
    public float Sensitivity = 5f;
    private float _rotationX = 0f;
    private float _rotationY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        if (Player != null)
        {
            _rotationX += Input.GetAxis("Mouse X") * Sensitivity;
            _rotationY -= Input.GetAxis("Mouse Y") * Sensitivity;
            _rotationY = Mathf.Clamp(_rotationY, -80f, 80f);

            transform.rotation = Quaternion.Euler(_rotationY, _rotationX, 0);

            transform.position = Player.position;
        }
    }
}
