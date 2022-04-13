using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovementBehaviour : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]
    private Vector2 _defaultAspectRatio;
    private Vector3 _startPos;
    private float _refRatio;
    [SerializeField]
    private Vector3 _zoomScale = Vector3.one;
    [SerializeField]
    private GameObject _objectToFollow = null;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        _refRatio = _defaultAspectRatio.x / _defaultAspectRatio.y;
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_defaultAspectRatio.x <= 0 || _defaultAspectRatio.y <= 0)
            return;
        double ratio = _refRatio / _camera.aspect;
        ratio = Math.Round(ratio, 4);

        Vector3 scaledPosition = Vector3.Scale(_startPos * (float)ratio, _zoomScale);

        transform.position = scaledPosition;

        Vector3 direction = (_objectToFollow.transform.position - transform.position).normalized;
        direction = direction * 500 * Time.fixedDeltaTime;
        transform.Translate(new Vector3(direction.x, direction.y));
    }
}
