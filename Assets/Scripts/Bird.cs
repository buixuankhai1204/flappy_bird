using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private float _speed = 5;
    private float _gravity = 1.0f;
    private float _jumHeight = 5.0f;
    private float yPosition;
    Vector3 velocity = new Vector3(0, 0, 0);

    private CharacterController _controller;
    private Pipe _pipe;
    private GameManager _gameManager;
    private UiManager _uiManager;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _pointAudioSource;
    [SerializeField] private AudioClip _pointAudioClip;
    
    [SerializeField] private AudioSource _dieAudioSource;
    [SerializeField] private AudioClip _dieAudioClip;
    
    [SerializeField] private AudioSource _hitAudioSource;
    [SerializeField] private AudioClip _hitAudioClip;
    
    [SerializeField] private AudioSource _wingAudioSource;
    [SerializeField] private AudioClip _wingAudioClip;
    bool _checkSound = false;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("Game Manager not working!!");
        }
        
        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        if (_uiManager == null)
        {
            Debug.LogError("Ui Manager not working!!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        Fly();
        ShowPoint();
    }

    void Fly()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && _gameManager.GetStatusGame() == false)
        {
            yPosition = _jumHeight;
            _animator.SetBool("activeFly", true);
            _wingAudioSource.PlayOneShot(_wingAudioClip);

            
            
        }  
        else
        {
            yPosition -= _gravity * 10 * Time.deltaTime;
            _animator.SetBool("activeFly", false);
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

    public void ShowPoint()
    {
        _uiManager.ShowPoint(_gameManager.GetPoint());
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Pipe")
        {
            _gameManager.UpdatePoint();
            _pointAudioSource.PlayOneShot(_pointAudioClip);
            other.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (other.tag == "DeathZone")
        {
            _gameManager.ChangeStatusGame(true);
            _animator.SetBool("activeFly", false);
            Debug.LogError("Death");
            if (_checkSound == false)
            {
                _hitAudioSource.PlayOneShot(_hitAudioClip);
                _dieAudioSource.PlayOneShot(_dieAudioClip);
                _checkSound = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _gameManager.ChangeStatusGame(true);
        _uiManager.ShowRestartLevel(true);
        if (_checkSound == false)
        {
            _hitAudioSource.PlayOneShot(_hitAudioClip);
            _dieAudioSource.PlayOneShot(_dieAudioClip);
            _checkSound = true;
        }
    }
}
