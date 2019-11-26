using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mirror
{
    public class PlayerController : NetworkBehaviour
    {
        [SyncVar]
        Transform spriteTransform;

        /*void OnDisable()
        {
            if (isLocalPlayer)
            {
                Camera.main.transform.SetParent(null);
                Camera.main.transform.localPosition = new Vector3(0f, 50f, 0f);
                Camera.main.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
            }
        }*/

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

            spriteTransform = GetComponentInChildren<SpriteRenderer>().transform;

            /*Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = new Vector3(0f, 0f, -8f);
            Camera.main.transform.localEulerAngles = new Vector3(0f, 0f, 0f);*/
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
        }

        void FixedUpdate()
        {
            if (!isLocalPlayer) return;

            float turnRate = 150f;
            spriteTransform.Rotate(0f, 0f, -horizontal * Time.fixedDeltaTime * turnRate);

            Vector2 direction = spriteTransform.up;
            direction.Normalize();
            direction *= moveSpeed * vertical * Time.fixedDeltaTime;

            // actually move lol
            transform.position += (Vector3)direction;
        }
    }
}

