using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour {

    public List<Transform> path;
    public Color rayColor = Color.white;

    void OnDrawGizmos()
    {
        Gizmos.color = rayColor;

        path = new List<Transform>();
        var pathObjs = GetComponentInChildren<Transform>();

        foreach (Transform pathObj in pathObjs)
        {
            if (pathObj != transform)
                path.Add(pathObj);
        }

        for (var i = 0; i < path.Count; i++)
        {
            var pos = path[i].position;
            if (i > 0)
            {
                var prev = path[i - 1].position;
                Gizmos.DrawLine(prev, pos);
                Gizmos.DrawWireSphere(pos, 0.5f);
            }
        }
    }
}