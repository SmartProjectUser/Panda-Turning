using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private bool _bGameOver;
    void Start()
    {
        transform.localPosition = FindEndPoint();
    }

    void Update()
    {
        transform.localPosition = FindEndPoint();
    }

    Vector3 FindEndPoint() {
        float endPointZ;
        endPointZ = _player.transform.position.z-4;
        Vector3 endPoint = new Vector3(_player.transform.position.x, transform.localPosition.y, endPointZ);
        return endPoint;
    }
}
