using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficGenerator : MonoBehaviour
{
   
    private enum Directions {Left, Right};
    private int carsSpawned;
    private float timeSinceLastSpawn;
    public float trafficSpeed;
    
    [SerializeField] private int maxCarsAllowed;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private GameObject car;
    [SerializeField] private Transform rightLaneSpawn;
    [SerializeField] private Transform leftLaneSpawn;

    public void ResetGenerator()
    {
        timeSinceLastSpawn = 0;
        carsSpawned = 0;
       

    }

    private void SpawnTraffic()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns) {
            timeSinceLastSpawn -= timeBetweenSpawns;
            GameObject spawnedCar = Instantiate(car);
            SpawningValues(spawnedCar);
            carsSpawned++;
        }
    }

    private void SpawningValues(GameObject spawnedCar)
    {
        spawnedCar.GetComponent<Car>().speed = trafficSpeed;
        Directions ranDirection = RandomEnumValue<Directions>();
        spawnedCar.transform.position = ranDirection == Directions.Right ? rightLaneSpawn.position : leftLaneSpawn.position;
        spawnedCar.transform.rotation = transform.rotation;
    }

    private T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(new System.Random().Next(v.Length));
    }

    // Update is called once per frame
    private void Update()
    {
        if (carsSpawned < maxCarsAllowed)
            SpawnTraffic();
    }
}
