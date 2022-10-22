using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextLevel : MonoBehaviour
{
    public Text Text;
    public LevelManager LevelManager;

    private void Start()
    {
        Text.text = "Level " + (LevelManager.CurrentLevel + 1).ToString();
    }
}
