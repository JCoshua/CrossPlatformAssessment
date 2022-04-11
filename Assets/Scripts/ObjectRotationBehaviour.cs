using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotationBehaviour : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Input.mousePosition);
    }
}
