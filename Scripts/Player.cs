using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        
        Vector3 playerDirection = Vector3.zero;

        playerDirection += _camera.forward * vertInput;
        playerDirection += _camera.right * horInput;
        
        playerDirection.y = 0;
        playerDirection.Normalize();

        transform.Translate(playerDirection * _speed  * Time.deltaTime);
    }
}
