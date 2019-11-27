using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mirror
{
    public class PlayerController : NetworkBehaviour
    {
        public GameObject torpedo;

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

        }

        [Header("Movement Settings")]
        public float moveSpeed = 8f;

        [Header("Diagnostics")]
        public float horizontal = 0f;
        public float vertical = 0f;

        void Update()
        {
            if (!isLocalPlayer) return;

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            if(Input.GetKeyDown("space"))
            {
                GameObject projectile = Instantiate(torpedo, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                projectile.transform.rotation = transform.rotation;
            }
        }

        void FixedUpdate()
        {
            if (!isLocalPlayer) return;

            float turnRate = 150f;
            transform.Rotate(0f, 0f, -horizontal * Time.fixedDeltaTime * turnRate);

            Vector2 direction = transform.up;
            direction.Normalize();
            direction *= moveSpeed * vertical * Time.fixedDeltaTime;

            // actually move lol
            transform.position += (Vector3)direction;
        }
    }
}

