using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGenerator : MonoBehaviour
{
    [SerializeField] GameObject point;
    [SerializeField] private int pointAmount;
    [SerializeField] Vector3 minSpawningVector;
    [SerializeField] Vector3 maxSpawningVector;

    
    public void Generate()
    {
        for (int i = 0; i < pointAmount; i++)
        {
            GameObject go = Instantiate(point, transform.parent.position + GeneratedPosition(), Quaternion.identity, transform.parent);
            go.transform.parent = transform.parent;
          
        }
    }

    private Vector3 GeneratedPosition()
    {
        float x, y, z;
        x = Random.Range(minSpawningVector.x, maxSpawningVector.x);
        y = Random.Range(minSpawningVector.y, maxSpawningVector.y);
        z = Random.Range(minSpawningVector.z, maxSpawningVector.z);
        return new Vector3(x, y, z);
    }

    // Update is called once per frame
  
}
