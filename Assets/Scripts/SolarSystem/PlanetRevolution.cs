using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRevolution : MonoBehaviour
{

    #region Editor Variables
    [SerializeField]
    [Tooltip("Planet revolution speed")]
    private float speed;

    [SerializeField]
    [Tooltip("Semi_major axis")]
    private float major_axis;

    [SerializeField]
    [Tooltip("Semi_minor axis")]
    private float minor_axis;

    [SerializeField]
    [Tooltip("Sun position")]
    private GameObject sun;
    #endregion

    #region variables
    private Vector3 center;
    private float X;
    private float Z;
    private float angle;
    #endregion

    private void Start()
    {
        center = sun.transform.position;
        angle = 0;
    }

    void Update()
    {
        //need to change speed based on number of days passed
        angle += speed;
        X = center.x + (major_axis * Mathf.Cos(angle * .005f));
        Z = center.z + (minor_axis * Mathf.Sin(angle * .005f));
        this.gameObject.transform.position = new Vector3(X, 0, Z);
    }
}
