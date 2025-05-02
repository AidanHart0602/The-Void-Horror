using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTPSystem : MonoBehaviour, InteractInterface
{
    [SerializeField] private GameObject _doorA, _doorB;
    [SerializeField] private GameObject[] _spawnPoints;
    public static int spawnPointNum = 0;

    public bool locked;
    // Start is called before the first frame update
    void Start()
    {
        locked = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        locked = false;
    }

    private void OnTriggerStay(Collider other)
    {
        /* if (other.gameObject.CompareTag("Player") && locked == false && Input.GetKeyDown("E"))
         {
             LocationSwap(other);
         }*/

        LocationSwap(other);
    }

    void LocationSwap(Collider Player)
    {
        if (this.gameObject.CompareTag("DoorA"))
        {
            Player.transform.position = _spawnPoints[0].transform.position;
            spawnPointNum = 1;
        }

        else if (this.gameObject.CompareTag("DoorB"))
        {
            Player.transform.position = _spawnPoints[1].transform.position;
            spawnPointNum = 0;
        }
    }
}
