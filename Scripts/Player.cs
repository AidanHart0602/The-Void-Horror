using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private UIManager _uiManager;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _speed = 5;
    private bool _gameOver = false;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_gameOver == false) 
        {
            PlayerMovement();
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Structure"))
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            _uiManager.GameOver();
            _gameOver = true;
        }
    }
}
