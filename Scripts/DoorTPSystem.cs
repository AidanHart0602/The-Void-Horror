using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTPSystem : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject _otherSpawnPoint;
    [SerializeField] private GameObject _lockedPanel, _openPanel;
    public bool locked;
    // Start is called before the first frame update
    
    void Start()
    {
        if (locked == true)
        {
            _openPanel.SetActive(false);
            _lockedPanel.SetActive(true);
        }

        if (locked == false)
        {
            _openPanel.SetActive(true);
            _lockedPanel.SetActive(false);
        }
    }

    public void Interact(Collider Player)
    {
        Player.transform.position = _otherSpawnPoint.transform.position;
    }

    public void Activate()
    {

    }
}
