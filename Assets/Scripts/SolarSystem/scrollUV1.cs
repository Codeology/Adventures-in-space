using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollUV1  : MonoBehaviour
{
    //AUTOMATIC SCROLL WHEN STARSHIP IS MOVING
   //otherwise, offset background based on the user's absolution position

    #region variables
    private MeshRenderer mr;
    private Material mat;
    private Vector2 offset;
    private float parallax;
    #endregion

    private void Start()
    {
        mr = this.GetComponent<MeshRenderer>();
        mat = mr.materials[0];
        offset = Vector2.zero;
        parallax = 10f;
    }
    // Update is called once per frame
    void Update()
    {
         offset.x = transform.position.x / transform.localScale.x / parallax;
         offset.y = transform.position.y / transform.localScale.y / parallax;
         mat.mainTextureOffset = offset;
    }
}
