using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingAcademy : Academy
{

    public override void InitializeAcademy()
    {
        Monitor.SetActive(true);
        base.InitializeAcademy();
    }

    //was lazy 
    public override void AcademyReset()
    {   
        TrafficGenerator[] trafficGenerators = FindObjectsOfType(typeof(TrafficGenerator)) as TrafficGenerator[]; 
        PointGenerator[] pointGenerators = FindObjectsOfType(typeof(PointGenerator)) as PointGenerator[];
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            if (go.name == "Car7(Clone)" || go.name == "Point(Clone)")
                Destroy(go);
        foreach (TrafficGenerator generator in trafficGenerators)      
            generator.ResetGenerator();
        foreach (PointGenerator generator in pointGenerators)
            generator.Generate();        
    }

    public override void AcademyStep()
    {
        base.AcademyStep();
    }
}
