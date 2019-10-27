using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _changeSpeedDelay;
    [SerializeField]
    private float _minSpeed;
    [SerializeField]
    private float _maxSpeed;

    private float _timer;
    private float _dir;
    void Start()
    {
        _dir = -1f;
        _timer = _changeSpeedDelay;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0) {
            _timer = _changeSpeedDelay;
            ChangeSpeed(1f);
        }

        if (GroundCheck())
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _dir *= (-1f);
            }
            PlayerMovement();
        }
    }
    public bool GroundCheck() {
        RaycastHit hit;
        float distance = 2f;
        Vector3 dir = Vector3.down;

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeSpeed(float val) {
        _speed = Mathf.Clamp(_speed + val, _minSpeed, _maxSpeed);
    }
    void PlayerMovement() {
        Vector3 direction;
        direction = new Vector3(_speed*_dir,0,_speed);
        transform.Translate(direction * Time.deltaTime);
    }
}
