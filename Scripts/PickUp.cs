using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteract
{
    public void Interact(Collider Other)
    {
        Destroy(this.gameObject);
    }

    public void Activate()
    {

    }
}
