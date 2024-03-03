using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
        static private Launcher S;

    // fields set in the Unity Inspector pane
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    // fields set dynamically
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public Rigidbody projectileRigidbody;

    static public Vector3 LAUNCH_POS
    {
        get {
            if(S == null) return Vector3.zero;
            return S.launchPos;
        }
    }

    void Awake()
    {
        S = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            projectile = Instantiate(prefabProjectile) as GameObject;
        }
    }
}
