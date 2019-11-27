using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{

    private float speed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = transform.up;
        direction.Normalize();
        direction *= speed * Time.fixedDeltaTime;

        // actually move lol
        transform.position += (Vector3)direction;

        speed += 0.1f;
    }
}
