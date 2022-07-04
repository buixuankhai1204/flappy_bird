using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    private bool _stopSpawnPipe = false;
    [SerializeField] private GameObject _pipePrefabs;
    private int _maxPipe = 7;
    private int _countPipe = 0;
    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPipe()
    {
        while (_stopSpawnPipe == false)
        {
            Vector3 direction = new Vector3(8.6f, Random.Range(0.2f, -3.82f));
             Instantiate(_pipePrefabs, direction, Quaternion.identity);
            _countPipe++;
            yield return new WaitForSeconds(2.0f);
        }
    }

}
