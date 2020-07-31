using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intensity_manager : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Player transform")]
    private Transform environment;
    #endregion

    #region Variables
    private float dist;
    #endregion

    private void Update()
    {
        dist = Mathf.Round(Vector3.Distance(gameObject.transform.position, environment.transform.position));
        this.GetComponent<Light>().intensity = 1000 / (dist + 0.01f);
    }


}
