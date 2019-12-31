using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ThermalMachine : MonoBehaviour
{

    public void xyWalk(int w, int h, Action<int, int> a)
    {
        for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++)
                a(x, y);
    }
    void Start()
    {
        xyWalk(10,10, (y, x) =>
        {
            GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cube);
            o.transform.position = 
                (Vector3.up * (y + 1) * 1.5f) + 
                (Vector3.left * (x -5)
            );
            Rigidbody rigidbody= o.AddComponent<Rigidbody>();

            rigidbody.constraints = 
                RigidbodyConstraints.FreezePositionX
                |RigidbodyConstraints.FreezePositionZ
                |RigidbodyConstraints.FreezeRotation
                ;
            o.AddComponent<BoxCollider>();
            o.GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Color"));

            ThermalBlock thermal=o.AddComponent<ThermalBlock>();
            thermal.Kelvin=UnityEngine.Random.Range(0,1000);

            

        });
    }
}
