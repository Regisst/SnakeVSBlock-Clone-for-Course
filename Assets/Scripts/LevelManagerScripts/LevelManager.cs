using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelsList _levelsList;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;

    private int _currentLevelIndex;

    public ScreenManager ScreenManager;
    public CameraFollow CameraFollow;
    public int CurrentLevel;
    private void Awake()
    {
        _currentLevelIndex = _saveLoadSystem.GetLevelIndex();
        _currentLevelIndex %= _levelsList.Levels.Length;
        Instantiate(_levelsList.Levels[_currentLevelIndex]);

        CameraFollow.FindCameraFollow();
        CurrentLevel = _currentLevelIndex;
    }

    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        _saveLoadSystem.SaveLevel(_currentLevelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextLevel();
        }
    }
    public void RestartLevel()
    {
        _currentLevelIndex = _saveLoadSystem.GetLevelIndex();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScreenManager.StartGame();

    }
}