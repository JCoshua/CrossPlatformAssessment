using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraRectBehaviour : MonoBehaviour
{
    private Camera _camera;
    private Vector2 _startSize;
    [SerializeField]
    private Vector2 _referenceAspectRatio;
    private float _refRatio;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        _startSize = _camera.rect.size;
        _refRatio = _referenceAspectRatio.x / _referenceAspectRatio.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Find how much the screen has scaled from the reference ratio.
        float screenScale = ((float)Screen.width / (float)Screen.height) / _refRatio;

        Rect rect = new Rect();

        //If the new size of the screen is larger than the reference...
        if (screenScale > 1)
        {
            //...adjust the camera rect's width
            rect.size = new Vector2(_startSize.x / screenScale, _camera.rect.height);
            rect.x = 0.5f - (rect.width / 2);
        }
        //Otherwise...
        else
        {
            //...adjust the camera rect's height
            rect.size = new Vector2(_camera.rect.height, _startSize.y / screenScale);
            rect.y = 0.5f - (rect.height / 2);
        }

        //Update the camera's viewport rect.
        _camera.rect = rect;
    }
}