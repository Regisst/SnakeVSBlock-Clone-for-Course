using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Snake : MonoBehaviour
{
    public Transform HeadTransform;
    public Transform TailTransform;

    public int HealthPoints;
    public int _oldHP;

    public List<Transform> TailsTransform = new List<Transform>();
    public List<Vector3> TailsVector = new List<Vector3>();

    public TextMeshPro PointsText;
    private void Start()
    {
        TailsVector.Add(HeadTransform.position);
        HealthPoints = 3;
        _oldHP = 0;

        SpawnSnakeTail();
        GetHPText();
    }

    public void GetHPText()
    {
        int TextHP = HealthPoints + 1;
        PointsText.SetText(TextHP.ToString());
    }

    public AudioSource AudioCoin;
    public void SpawnSnakeTail()
    {
        AudioCoin.Play();
        for (int i = _oldHP; i < HealthPoints; i++)
        {
            Transform TailsSphere = Instantiate(TailTransform, TailsVector[TailsVector.Count - 1], Quaternion.identity, transform);
            TailsSphere.transform.position = TailsVector[i] + new Vector3(0, 0, 1.3f);
            TailsTransform.Add(TailsSphere);
            TailsVector.Add(TailsSphere.position);
        }

        _oldHP = HealthPoints;
    }

    public int StartDestroy = 0;
    public AudioSource AudioBoop;
    public ParticleSystem Hit;
    public void DestroyLastSphere()
    {
        Hit.Play();
        AudioBoop.Play();

        if (TailsTransform.Count > 0)
        {
            Destroy(TailsTransform[TailsTransform.Count - 1].gameObject);
            TailsTransform.RemoveAt(TailsTransform.Count - 1);
            TailsVector.RemoveAt(TailsVector.Count - 1);
        }

        HealthPoints = HealthPoints - 1;
        _oldHP = _oldHP - 1;
        GetHPText();

        Death();
    }

    public Control Control;
    public ScreenManager ScreenManager;
    public void Death()
    {
        ScreenManager = FindObjectOfType<ScreenManager>();

        if (HealthPoints < 0)
        {
            Destroy(HeadTransform.gameObject);
            Control.DisableConrol = true;
            ScreenManager.Death();
        }

    }
}
