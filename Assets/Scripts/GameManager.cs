using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private Bird _bird;
    private UiManager _uiManager;
    private int _point = 0;

    private bool _isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        _bird = GameObject.FindWithTag("Player").GetComponent<Bird>();
        if (_bird == null)
        {
           ChangeStatusGame(true);
           Debug.LogError("bird die");
        }
        
        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        if (_uiManager == null)
        {
            ChangeStatusGame(true);
            Debug.LogError("Ui manager not working");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayGame();
        RestartLevel();
    }

    public void ChangeStatusGame(bool ChangeValue)
    {
        _isGameOver = ChangeValue;
    }

    public bool GetStatusGame()
    {
        return _isGameOver;
    }
    public int GetPoint()
    {
        return _point;
    }

    public void UpdatePoint()
    {
        _point += 1;
    }

    public void RestartLevel()
    {
        if (GetStatusGame())
        {
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void PlayGame()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _uiManager.EnebleAll();
        }
    }
    
    
    
}
