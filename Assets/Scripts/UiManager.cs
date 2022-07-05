using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private GameManager _gameManager;
    private GameObject _bird;

    [SerializeField] private Sprite[] _listPointDozen;
    [SerializeField] private Image _PointDozenImg;
    [SerializeField] private Sprite[] _listPointUnit;
    [SerializeField] private Image _PointUnitImg;
    
    [SerializeField] private Image _gameOver;
    [SerializeField] private Image _startGame;
    [SerializeField] private Text _restartLevel;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _bird = GameObject.FindWithTag("Player");
        if (_gameManager == null)
        {
            Debug.LogError("Game manager not working");
        }
        DisalbelAll();

    }

    // Update is called once per frame
    void Update()
    {
        ShowGameOver();
    }

    public void ShowPoint(int _point)
    {
        int Dozen = _point / 10;
        int Unit = _point % 10;

        _PointDozenImg.sprite = _listPointDozen[Dozen];
        _PointUnitImg.sprite = _listPointUnit[Unit];
    }

    public void ShowGameOver()
    {
        if (_gameManager.GetStatusGame())
        {
            _gameOver.enabled = true;
        }
    }

    public void ShowRestartLevel(bool value)
    {
        if (value)
        {
            _restartLevel.enabled = true;
        }
    }

    void DisalbelAll()
    {
        _gameOver.enabled = false;
        _restartLevel.enabled = false;
        _PointDozenImg.enabled = false;
        _PointUnitImg.enabled = false;
        _bird.SetActive(false);
        ShowStartGame(true);
    }
    
    public void EnebleAll()
    {
        _PointDozenImg.enabled = true;
        _PointUnitImg.enabled = true;
        ShowStartGame(false);
        _bird.SetActive(true);

    }

    public void ShowStartGame(bool val)
    {
        _startGame.enabled = val;
    }
}
