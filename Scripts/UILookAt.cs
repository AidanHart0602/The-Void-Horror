using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UILookAt : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraTransform;
    [SerializeField]
    private Camera _mainCam;
    // Start is called before the first frame update
    void Start()
    {
        _mainCam = Camera.main;
        _cameraTransform = _mainCam.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(_mainCam.transform);
    }
}
