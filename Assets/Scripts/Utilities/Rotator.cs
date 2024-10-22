using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 axis;

    public float sensitivity = 2.0f;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.Rotate(new Vector3(0, mouseX * sensitivity, 0));
            transform.Rotate(new Vector3(-mouseY * sensitivity, 0, 0));
        }
        else
        {
            transform.Rotate(axis, speed * Time.deltaTime, Space.World);
        }

    }
}
