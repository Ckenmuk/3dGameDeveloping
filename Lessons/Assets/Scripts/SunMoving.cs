using UnityEngine;

public class SunMoving : MonoBehaviour
{
    [SerializeField] private float dayLength;

    private float turningSpeed;
    

    private void FixedUpdate()
    {
        turningSpeed = Time.deltaTime / dayLength;
        transform.Rotate(0, turningSpeed, 0);
    }
}
