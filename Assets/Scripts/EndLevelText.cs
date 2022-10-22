using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndLevelText : MonoBehaviour
{
    public TextMeshPro EndText;
    void Start()
    {
        EndText.SetText("Level " + 01.ToString() +" Completed!");
    }
}
