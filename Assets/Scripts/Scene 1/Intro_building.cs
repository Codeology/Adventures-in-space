using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Intro_building : MonoBehaviour
{
    #region Variables
    private bool start;
    #endregion

    #region Initialization
    private void Awake()
    {
        start = false;
    }
    #endregion

    #region Updates
    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Image>().color == Color.white && start == false)
        {
            start = true;
            StartCoroutine(moving());
        }
    }
    #endregion


    #region Coroutines
    IEnumerator moving()
    {
        Vector3 StartPos = this.transform.position;
        Vector3 Endpos = StartPos + Vector3.down * 1010;
        Debug.Log(StartPos);
        Debug.Log(Endpos);
        while (StartPos != Endpos)
        {
            StartPos = Vector3.Lerp(StartPos, Endpos, 0.004f);
            this.transform.position = StartPos;
            yield return null;
        }
    }
    #endregion
}