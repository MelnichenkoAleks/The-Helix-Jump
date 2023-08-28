using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HelixRotator : MonoBehaviour
{
    public float rotationSpeed = 300f;
    public float rotationSpeedMobile = 50f;

    void Update()
    {   // for PC version
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(transform.position.x, -mouseX * rotationSpeed * Time.deltaTime, transform.position.z);
        }

        // for Mobile version
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float xDeltaPos = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(transform.position.x, -xDeltaPos * rotationSpeed * Time.deltaTime, transform.position.z);
        }
    }
}
