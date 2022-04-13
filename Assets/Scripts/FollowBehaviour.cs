using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows an object to follow another object without being directly affected by the parent's transform
/// </summary>
public class FollowBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject _objectToFollow = null;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moves the object by the direction of the object it is following
        Vector3 direction = (_objectToFollow.transform.position - transform.position).normalized;
        direction = direction * 500 * Time.fixedDeltaTime;
        transform.Translate(new Vector3(direction.x, direction.y));
    }
}
