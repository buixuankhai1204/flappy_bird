using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private float _speed = 5;
    private float _gravity = 1.0f;
    private float _jumHeight = 5.0f;

    private CharacterController _controller;
    private Pipe _pipe;
    Vector3 velocity = new Vector3(0, 0, 0);

    private float yPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        /*
        _pipe = GameObject.FindWithTag("Pipe").GetComponent<Pipe>();
        */

    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    void Fly()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            yPosition = _jumHeight;
        }  
        else
        {
            yPosition -= _gravity * 10 * Time.deltaTime;
        }
        
        velocity.y = yPosition;
        
        transform.Translate(velocity *Time.deltaTime);
    }

    public void GameOver()
    {
        //Add Animation GameOver
        //free fall bird
        //GameOver = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("OnTriggerEnter2D");

        if (other.tag == "Pipe")
        {
            GameOver();
            //add sound Gameover
        }
    }
    
}
