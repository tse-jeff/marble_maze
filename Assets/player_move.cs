using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_move : MonoBehaviour
{
    public float speed = 20;

    Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float zSpeed = Input.GetAxis("Vertical") * speed;
        float xSpeed = Input.GetAxis("Horizontal") * speed;

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 moveDirection = forward * zSpeed + right * xSpeed;
        _rigidbody.AddForce(moveDirection);

        // if player falls off the map, restart the scene
        if (transform.position.y < -15) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
