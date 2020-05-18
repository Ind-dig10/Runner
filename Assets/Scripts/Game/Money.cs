using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour, ITrigger
{
    [SerializeField] private int count;

    public int Count => count;

    public void Collect()
    {
        Destroy(gameObject);
    }
}
