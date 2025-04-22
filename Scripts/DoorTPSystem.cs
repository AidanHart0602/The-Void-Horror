using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTPSystem : MonoBehaviour
{
    [SerializeField] private GameObject _doorA, _doorB;
    [SerializeField] private GameObject[] _spawnPoints;
    public static int spawnPointNum = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(spawnPointNum);
        if (other.gameObject.CompareTag("Player"))
        {
            LocationSwap(other);
        }
    }

    void LocationSwap(Collider Player)
    {
        if (spawnPointNum == 0)
        {
            Player.transform.position = _spawnPoints[0].transform.position;
            spawnPointNum = 1;
        }

        else if (spawnPointNum == 1)
        {
            Player.transform.position = _spawnPoints[1].transform.position;
            spawnPointNum = 0;
        }
    }
}
