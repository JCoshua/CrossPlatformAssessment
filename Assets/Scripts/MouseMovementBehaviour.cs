using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0;

    private Rigidbody _rigidBody;
    private Camera _camera;

    //Moves on the Y-axis if false
    [SerializeField]
    private bool _movesOnXAxis = true;
    [SerializeField]
    private float _minDistance;
    [SerializeField]
    private float _maxDistance;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _camera = Camera.main;

        //If the object will move on the X-Axis
        if(_movesOnXAxis)
        {
            //offset the min and max distance by the position of the object
            _minDistance = transform.position.x - _minDistance;
            _maxDistance = transform.position.x + _maxDistance;
        }
        //Else if the object would move on the Y-Axis
        else
        {
            //offset the min and max distance by the position of the object
            _minDistance = transform.position.y - _minDistance;
            _maxDistance = transform.position.y + _maxDistance;
        }
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
            //If the object will move on the X-Axis

            if (_movesOnXAxis)
            {
                //Gets the direction the object would move
                Vector2 direction = (hitInfo.point - transform.position).normalized;
                direction = new Vector2(direction.x, 0);
                Vector3 movement = direction * _speed * Time.fixedDeltaTime;
                movement += transform.position;

                //If the object's new position would be within the bound...
                if(movement.x > _minDistance && movement.x < _maxDistance)
                {
                    //...Translate the object
                    transform.Translate(direction * _speed * Time.fixedDeltaTime);
                }

                //If the object would go beyond the bounds...
                else if (movement.x < _minDistance)
                {
                    //Set the objects x to be the minimum distance
                    transform.position = new Vector3(_minDistance, transform.position.y, transform.position.z);
                }
                else if (movement.x < _maxDistance)

                {
                    //Set the objects x to be the maximum distance
                    transform.position = new Vector3(_maxDistance, transform.position.y, transform.position.z);
                }
            }
            else
            {
                //Gets the direction the object would move
                Vector2 direction = (hitInfo.point - transform.position).normalized;
                direction = new Vector2(0,direction.y);
                Vector3 movement = direction * _speed * Time.fixedDeltaTime;
                movement += transform.position;

                //If the object's new position would be within the bound...
                if (movement.y > _minDistance && movement.y < _maxDistance)
                {
                    //...Translate the object
                    transform.Translate(direction * _speed * Time.fixedDeltaTime);
                }

                //If the object would go beyond the bounds...
                else if (movement.y < _minDistance)
                {
                    //Set the objects x to be the minimum distance
                    transform.position = new Vector3(transform.position.x, _minDistance, transform.position.z);
                }
                else if (movement.y < _maxDistance)
                {
                    //Set the objects x to be the maximum distance
                    transform.position = new Vector3(transform.position.x, _maxDistance, transform.position.z);
                }
            }
        }
    }
}
