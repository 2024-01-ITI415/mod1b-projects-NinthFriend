using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [Header("Set in Inspector")]

    // a reference for a range that destroys the spheres
    public static float rangeZ = 10f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > rangeZ)
        {
            Destroy(this.gameObject);
        }
    }
}
