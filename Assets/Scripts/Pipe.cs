using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pipe : MonoBehaviour
{

    private float _speed = 2f;
    private SpawnManager _spawnManager;
    private GameManager _gameManager;
    private Pipe[] _pipes;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("Game manager not working!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {

        if (transform.position.x < -8.6f)
        {
            float randomY = Random.Range(0.2f, -3.82f);
            transform.position = new Vector3(8.6f, randomY, 0);
            Destroy(gameObject);
        }

        if (_gameManager.GetStatusGame() == false)
        {
            transform.Translate(Vector3.left *_speed * Time.deltaTime,  Space.World);
        }
    }

}
