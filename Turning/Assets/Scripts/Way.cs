using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    [SerializeField]
    private WayController _wayController;
    [SerializeField]
    private GameObject _bonusItem;

    public void  Init(float x,float z)
    {
        transform.localScale = new Vector3(x, 1, z);
        gameObject.SetActive(true);
        int i = Random.Range(0, 4);
        if (i == 0) {
            _bonusItem.SetActive(true);
        }
    }

    public void Destr(){
        gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _wayController.GenerateWayPoint();
            GameController.score += 1;
        }
    }
}
