using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{
    public void Interact(Collider PlayerObject);
    public void Activate();
}
