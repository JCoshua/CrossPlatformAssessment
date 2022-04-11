using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0;
    private Rigidbody _rigidBody;
    private Camera _camera;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Casts a ray from the camera using the mouse position
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        //If the ray hits an object
        if (Physics.Raycast(ray, out hitInfo))
        {
            Vector2 direction = (hitInfo.point - transform.position).normalized;
            direction = new Vector2(direction.x, 0);
            transform.Translate(direction * _speed * Time.fixedDeltaTime);
        }
    }
}
