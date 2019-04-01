
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBrain : MLAgents.Agent

{
    public GameObject ball;
    public List<float> state = new List<float>();
    Vector3 ballStartPos;

    private void Start()
    {
        ballStartPos = gameObject.transform.position;
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        if (brain.brainParameters.vectorActionSpaceType == MLAgents.SpaceType.continuous)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 1), vectorAction[0]);
            gameObject.transform.Rotate(new Vector3(1, 0, 0), vectorAction[1]);
            if (IsDone())
            {
                SetReward(0.1f);
            }
            if ((ball.transform.position.y - gameObject.transform.position.y < -2f) ||
                    Mathf.Abs(ball.transform.position.x - gameObject.transform.position.x) > 3f ||
                    Mathf.Abs(ball.transform.position.z - gameObject.transform.position.z) > 3f)
            {
                Done();
                SetReward(-1f);
            }
               

        }
    }

    public override void CollectObservations()
    {
       
        AddVectorObs(gameObject.transform.rotation.z);
        AddVectorObs(gameObject.transform.rotation.x);
        AddVectorObs(ball.transform.position.x - gameObject.transform.position.x);
        AddVectorObs(ball.transform.position.y - gameObject.transform.position.y);
        AddVectorObs(ball.transform.position.z - gameObject.transform.position.z);
        AddVectorObs(ball.transform.GetComponent<Rigidbody>().velocity.x);
        AddVectorObs(ball.transform.GetComponent<Rigidbody>().velocity.y);
        AddVectorObs(ball.transform.GetComponent<Rigidbody>().velocity.z);
    
    }


    public override void AgentReset()
    {
        gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        ball.transform.position = ballStartPos;
    }



}
