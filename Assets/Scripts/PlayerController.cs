using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Boundry
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundry boundry;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 movement = Input.GetTouch(0).deltaPosition;
            transform.Translate(-movement.x * speed, 0.0f, -movement.z * speed);

            rb.velocity = movement * speed;
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundry.xMin, boundry.xMax), 0.0f,
                                          Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax));
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

        } else {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.velocity = movement * speed;
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundry.xMin, boundry.xMax), 0.0f,
                                          Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax));
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        }
    }

}
