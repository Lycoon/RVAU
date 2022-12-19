using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public new Camera camera;

    public float walkingSpeed = 5.0f;
    public float rotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetKey(KeyCode.Z))
            transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * walkingSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.left * walkingSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * walkingSpeed * Time.deltaTime);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5000);
        
        // Rotation
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
        camera.transform.Rotate(-Input.GetAxis("Mouse Y") * rotationSpeed, 0, 0);

        if (Input.GetMouseButtonDown(0))
             Cursor.lockState = CursorLockMode.Locked;
    }
}
