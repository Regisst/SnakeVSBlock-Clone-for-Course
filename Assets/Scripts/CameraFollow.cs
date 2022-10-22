using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform PlayerFollow;
    public Snake Snake;
    public GameObject Camera;

    private Vector3 _cameraPos;
    private Vector3 _cameraStartPos;
    
    public void FindCameraFollow()
    {
       
        var player = GameObject.FindGameObjectWithTag("Player");
        PlayerFollow = player.GetComponent<Transform>();

        _cameraStartPos = Camera.transform.position - PlayerFollow.transform.position;
    }
    void LateUpdate()
    {
        if (PlayerFollow == null) return;

        if (Camera.transform.position.z > PlayerFollow.transform.position.z)
        {
            _cameraPos.z = PlayerFollow.transform.position.z;
            Camera.transform.position = _cameraPos + _cameraStartPos;
        }
    }

}
