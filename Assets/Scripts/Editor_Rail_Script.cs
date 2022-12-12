using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_Rail_Script : MonoBehaviour
{
    public Color rayColor = Color.white;
    public List<Transform> rail_objs = new List<Transform>();
    Transform[] theArray;

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        rail_objs.Clear();

        foreach (Transform rail_obj in theArray)
        {
            if (rail_obj != this.transform)
            {
                rail_objs.Add(rail_obj);
            }
        }

        for (int i = 0; i < rail_objs.Count; i++)
        {
            Vector3 position = rail_objs[i].position;
            if(i > 0)
            {
                Vector3 previous = rail_objs[i - 1].position;
                Gizmos.DrawLine (position, previous);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }
    }
}
