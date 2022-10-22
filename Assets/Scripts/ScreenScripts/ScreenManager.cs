using Assets.Scripts;
using Assets.Scripts.ScreenScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private List<Screen> _screens;
    private Screen _activeScreen;
    private void Start()
    {
        _screens = new List<Screen>();
        _screens.AddRange(GetComponentsInChildren<Screen>());


        StartGame();
        
    }
    public LevelManager LevelManager;
    public void StartGame()
    {
        foreach (var screen in _screens)
        {
            if (screen is GameScreen)
            {
                screen.ShowScreen();
                _activeScreen = screen;
            }
            else
            {
                screen.HideScreen();
            }
        }
    }

    public void Win()
    {
        _activeScreen.HideScreen();

        foreach (var screen in _screens)
        {
            if (screen is WinScreen)
            {
                screen.ShowScreen();
                _activeScreen = screen;
                break;
            }
           
        }
    }

    public void Death()
    {
        _activeScreen.HideScreen();

        foreach (var screen in _screens)
        {
            if (screen is DeathScreen)
            {
                screen.ShowScreen();
                _activeScreen = screen;
                break;
            }
        }
    }
}
