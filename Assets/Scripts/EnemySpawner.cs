using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]GameObject enemy;
    [SerializeField] List<Vector3> positions;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Vector3 position in positions)
        {
            Instantiate(enemy, position, Quaternion.identity);
        }
        
    }
}
