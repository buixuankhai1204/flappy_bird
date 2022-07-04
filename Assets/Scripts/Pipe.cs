using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pipe : MonoBehaviour
{

    private float _speed = 2f;
    private SpawnManager _spawnManager;
    private Pipe[] _pipes;
    [SerializeField] private Bird _bird;

    // Start is called before the first frame update
    void Start()
    {
        _bird = GameObject.FindWithTag("Player").GetComponent<Bird>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
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

        transform.Translate(Vector3.left *_speed * Time.deltaTime,  Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("OnCollisionEnter2D");
        if (other.tag == "Player")
        {
            Debug.LogError("OnCollisionEnter2D");
            _bird.GameOver();
            //add sound Gameover
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError("OnCollisionEnter2D");
    }
}
