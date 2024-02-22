using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototype1 : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject prefabAimingCursor;
    public GameObject aimingCursor;

    // Start is called before the first frame update
    void Start()
    {
        aimingCursor = Instantiate(prefabAimingCursor) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
