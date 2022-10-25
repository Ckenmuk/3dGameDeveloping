using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float angularSpeed = 400f;

    private const string mouseX = "Mouse X";
    private const string mouseY = "Mouse Y";

    private Vector3 rotationDir;

    private void Update()
    {
       // rotationDir.y = Input.GetAxis(mouseX) * angularSpeed * Time.deltaTime;
        rotationDir.x = -Input.GetAxis(mouseY) * angularSpeed * Time.deltaTime;

        transform.Rotate(rotationDir);
    }
}
