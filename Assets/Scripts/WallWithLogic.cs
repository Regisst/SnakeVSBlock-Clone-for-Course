using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class WallWithLogic : MonoBehaviour
{
    public int _damage;
    public bool IsDamage1 = false;
    public bool IsDamage2 = false;
    public bool IsDamage3 = false;

    public TextMeshPro Damage;
    private void randomDamage()
    {
        if (IsDamage1 == true)
        {
            _damage = Random.Range(1, 4);
        }
        else if (IsDamage2 == true)
        {
            _damage = Random.Range(4, 10);
        }
        else if (IsDamage3 == true)
        {
            _damage = Random.Range(10, 30);
        }
        else
        {
            _damage = Random.Range(30, 60);
        }
    }
    void Start()
    {
        randomDamage();
        Damage.SetText(_damage.ToString());
        GetGradient();
    }

    public Snake Snake;
    private float time;
    private void OnCollisionStay(Collision collision)
    {
        time += Time.deltaTime;
        if (time >= 0.08f)
        {
            _damage -= 1;
            Damage.SetText(_damage.ToString());

            Snake.DestroyLastSphere();

            if (_damage > 0)
            {
                GetGradient();
            }
            else if (_damage <= 0)
            {
                Snake.StartDestroy = 0;
                Destroy(gameObject);
                
            }
            time = 0f;
        }
    }

    public Gradient SourceGradient;
    private Renderer _renderer;
 
    private void GetGradient()
    {
        int _maxDamage = 45;
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = SourceGradient.Evaluate((float) _damage / _maxDamage);
    }
}
