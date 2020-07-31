using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFollow : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The Player to follow")]
    private Transform m_PlayerTransform;

    [SerializeField]
    [Tooltip("The offset from the player's origin to the camera")]
    private Vector3 m_Offset;

    [SerializeField]
    [Tooltip("How fast the player can rotate the camera to the left and right")]
    private float m_RotationSpeed = 4;
    #endregion

    #region Main Updates
    private void LateUpdate()
    {
        float horizontal = 0;
        Vector3 newPos = m_PlayerTransform.position + m_Offset;
        transform.position = Vector3.Slerp(transform.position, newPos, 1);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = (Mathf.Abs(m_PlayerTransform.rotation.y - 1)) * m_RotationSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = (m_PlayerTransform.rotation.y - 1) * m_RotationSpeed;
        }
        else
        {
            horizontal = 0;
        }
        transform.RotateAround(m_PlayerTransform.position, Vector3.up, horizontal);
       
        m_Offset = transform.position - m_PlayerTransform.position;
    }

    #endregion
}