using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayController : MonoBehaviour
{
    [SerializeField]
    private List<Way> _activeWayPoints;
    [SerializeField]
    private List<Way> _wayPoints;

    public void GenerateWayPoint()
    {
        Way w;

        RemoveWayPoint(_activeWayPoints[0]);
        w = _wayPoints[0];
        _wayPoints.Remove(w);
        _activeWayPoints.Add(w);

        int l = Random.Range(4,10);
        if (w.transform.localScale.x == 3f)
        {
            w.transform.localPosition = _activeWayPoints[_activeWayPoints.Count - 2].transform.localPosition + new Vector3(-_activeWayPoints[_activeWayPoints.Count - 2].transform.localScale.x/2f+1.5f, 0, l / 2.0f + 1.5f);
            w.Init(3f,l);
        }
        else
        {
            w.transform.localPosition = _activeWayPoints[_activeWayPoints.Count - 2].transform.localPosition + new Vector3(-l / 2.0f - 1.5f, 0, _activeWayPoints[_activeWayPoints.Count - 2].transform.localScale.z / 2f - 1.5f);
            w.Init(l, 3f);
        }
        
    }
    public void RemoveWayPoint(Way w) {
        _activeWayPoints.Remove(w);
        _wayPoints.Add(w);
        w.Destr();
    }

    public void Clear() {
        foreach (Way w in _activeWayPoints)
            w.Destr();
        _wayPoints.AddRange(_activeWayPoints);
        _activeWayPoints = new List<Way>();
    }
}
