using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] List<Vector3> positions;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Vector3 position in positions)
        {
            Instantiate(coin, position, Quaternion.identity);
        }

    }
}
