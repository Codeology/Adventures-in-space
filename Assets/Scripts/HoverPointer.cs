using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverPointer : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Text on collision")]
    private Text m_text;

    [SerializeField]
    [Tooltip("Image on collision")]
    private Image m_image;

    [SerializeField]
    [Tooltip("Button on collision")]
    private Button m_button;

    [SerializeField]
    [Tooltip("Button on collision")]
    private Text m_buttontext;
    #endregion

    private void OnMouseEnter()
    {
        m_text.color = Color.black;
        m_text.text = "Click to switch to manual control of spaceship.";
        m_image.color = Color.white;
    }

    private void OnMouseExit()
    {
        m_text.color = Color.clear;
        m_image.color = Color.clear;
    }
}
