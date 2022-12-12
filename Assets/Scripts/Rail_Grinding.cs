using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail_Grinding : MonoBehaviour
{
    public Editor_Rail_Script RailToGrind;

    public int CurrentWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string railName;

    Vector3 last_position;
    Vector3 current_position;

    private void Start()
    {
        //RailToGrind = GameObject.Find(railName).GetComponent<Editor_Rail_Script>();
        last_position = transform.position;
    }
    private void Update()
    {
        float distance = Vector3.Distance(RailToGrind.rail_objs[CurrentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, RailToGrind.rail_objs[CurrentWayPointID].position, Time.deltaTime * speed);

        var rotation = Quaternion.LookRotation(RailToGrind.rail_objs[CurrentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        if(distance <= reachDistance)
        {
            CurrentWayPointID++;
        }

        if(CurrentWayPointID >= RailToGrind.rail_objs.Count)
        {
            CurrentWayPointID = 0;
        }
    }
}
