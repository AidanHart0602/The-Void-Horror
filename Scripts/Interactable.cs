using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _uiContainer;
    private bool _canInteract;
    private IInteract _interactable;
    // Start is called before the first frame update
    void Start()
    {
        _interactable = GetComponent<IInteract>();
        _canInteract = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiContainer.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactable.Interact(other);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactable.Interact(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _uiContainer.SetActive(false);
        }
    }
}
