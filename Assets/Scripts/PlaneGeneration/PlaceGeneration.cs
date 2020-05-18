using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceGeneration : MonoBehaviour
{
    [SerializeField] private Transform startPositionMap;

    public Transform player;
    public Place[] placePrefabs;
    public Place firstPlace;
    float posX;
    float posZ;

    private List<Place> spawnPlases = new List<Place>();

    private void Start()
    {
        StartSpawn();
        //spawnPlases.Add(firstPlace);
    }

    private void Update()
    {
       if(player.position.z > spawnPlases[spawnPlases.Count - 1].end.position.z - 100)
        {
            SpawnPlace();
        }
    }

    private void StartSpawn()
    {
        Place firstPlace = Instantiate(placePrefabs[Random.Range(0, placePrefabs.Length)]);
        firstPlace.transform.position = startPositionMap.position;
        spawnPlases.Add(firstPlace);
    }

    public void Restart()
    {
        foreach(Place i in spawnPlases)
        {
            Destroy(i.gameObject);
        }
        //Destroy(spawnPlases[spawnPlases.Count - 1].gameObject);
        spawnPlases.Clear();

        StartSpawn();
    }

    private void SpawnPlace()
    {
        Place newPlace = Instantiate(placePrefabs[Random.Range(0, placePrefabs.Length)]);
        newPlace.transform.position = spawnPlases[spawnPlases.Count - 1].end.position + new Vector3(0,0,100);
        spawnPlases.Add(newPlace);

        if(spawnPlases.Count >= 3)
        {
            Destroy(spawnPlases[0].gameObject);
            spawnPlases.RemoveAt(0);
        }
    }
}
