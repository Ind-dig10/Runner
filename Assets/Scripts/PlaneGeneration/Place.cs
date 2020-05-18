using UnityEngine;
using System.Collections.Generic;

public class Place : MonoBehaviour
{
    [SerializeField] public Transform begin;
    [SerializeField] public Transform end;

    public GameObject[] coinPrefabs;
    public int coinChanse;


    void Start()
    {
        foreach (GameObject coin in coinPrefabs)
        {
            coin.SetActive(Random.Range(0,100) <= coinChanse);
           // SpawnTile(2, zPos+5);
        }
    }
}
