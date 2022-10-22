using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Control : MonoBehaviour
{
    [SerializeField] public float _speed = 5;
    [SerializeField] public float ForwardSpeed;

    public bool DisableConrol = false;

    private Transform _transform;
    void Update() 
    {
        if (DisableConrol == false)
        {
            SnakeMove();
        }

        DashD();
    }

    private void Start()
    {
        this._transform = this.GetComponent<Transform>();   
    }

    public void SnakeMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * _speed, 0, 0);

            if (direction != Vector3.zero)
            {
                Vector3 pos = this._transform.position;
                direction.x = direction.x > 0 || pos.x > -6.5f ? direction.x : 0;
                direction.x = direction.x < 0 || pos.x < 6.5f ? direction.x : 0;
                this._transform.Translate(direction);
            }
        }

        transform.Translate(new Vector3(0, 0, -1) * ForwardSpeed * Time.deltaTime);
    }

    public Snake Snake;
    public void DashD()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Snake.DestroyLastSphere();
            Snake.Death();
        }
    }
}
    