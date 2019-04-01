using MLAgents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RacingAgent : Agent
{
    private RayPerception rayPerception;
    private RacingAcademy racingAcademy;
    private Rigidbody rigidBody;
    private Vector3 agentStartPos;
    private Quaternion startRotation;
    [SerializeField] private float agentSpeed;

 
    
    private void Start()
    {

        rayPerception = GetComponent<RayPerception>();
        rigidBody = GetComponent<Rigidbody>();
        racingAcademy = FindObjectOfType<RacingAcademy>();  
        startRotation = transform.rotation;
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {   
        gameObject.transform.Rotate(new Vector3(0, 1, 0), vectorAction[0]);
        rigidBody.AddRelativeForce(0, 0, agentSpeed);
        detectCollision();

    }

    private void detectCollision()
    {
        Collider[] hitObjects = Physics.OverlapBox(transform.position,
                                           new Vector3(0.4f, 0.4f, 0.4f));

        if (hitObjects.Where(col => col.gameObject.tag == "Obstacle").ToArray().Length == 1)
        {
            SetReward(-1f);
            Done();
        }

        else if (hitObjects.Where(col => col.gameObject.tag == "Finish").ToArray().Length == 1)
        {
           
            AddReward(+0.5f);
            Done();
        }
        else if (hitObjects.Where(col => col.gameObject.tag == "Point").ToArray().Length == 1)
        {
            AddReward(+0.2f);
            Destroy(hitObjects[0].gameObject);           
        }

    }

    public override void CollectObservations()
    {
        float[] rayAngles = { 0f, 45f, 90f, 135f, 180f, 110f, 70f, -45f, -90, -135, -180, -110, -70 };
        string[] detectableObjects = { "Obstacle", "Agent", "Point", "Finish", "Start" };
        AddVectorObs(rayPerception.Perceive(20f, rayAngles, detectableObjects, 0f, 0f));
    }

    public override void AgentReset()
    {
       
        transform.localPosition = new Vector3(UnityEngine.Random.Range(-10, 10), 1.295539f, -65f);
        transform.rotation = startRotation;
    }

   



}
