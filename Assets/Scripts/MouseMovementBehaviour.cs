using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementBehaviour : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Mouse X"), 0).normalized;
        transform.Translate(moveDirection * 25 * Time.fixedDeltaTime);
    }
}
