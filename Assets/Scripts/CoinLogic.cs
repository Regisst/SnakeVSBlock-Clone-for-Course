using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoinLogic : MonoBehaviour
{
    public int _coinGivesHP;

    public bool IsCoin1 = false;
    public bool IsCoin2 = false;

    private void randomCoin()
    {
        if (IsCoin1 == true)
        {
            _coinGivesHP = Random.Range(1, 4);
        }
        else if (IsCoin2 == true)
        {
            _coinGivesHP = Random.Range(4, 7);
        }
        else
        {
            _coinGivesHP = Random.Range(7, 12);
        }

    }

    public TextMeshPro HPCoin;
    void Start()
    {
        randomCoin();

        HPCoin.SetText(_coinGivesHP.ToString());
    }

    public Snake Snake;
    public Collider Head;
    private void OnTriggerEnter(Collider Head)
    {

      Snake.HealthPoints += _coinGivesHP;
      Destroy(gameObject);
      Snake.SpawnSnakeTail();
      Snake.GetHPText();

        
    }
}