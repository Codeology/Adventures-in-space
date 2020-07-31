using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The transform of the camera following the player")]
    private Transform m_CameraTransform;


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

    [SerializeField]
    [Tooltip("Camera 1")]
    private Camera cam1;

    [SerializeField]
    [Tooltip("Camera 2")]
    private Camera cam2;

    [SerializeField]
    [Tooltip("Exit Button")]
    private Button exit;

    [SerializeField]
    [Tooltip("Exit text")]
    private Text exit_t;

    [SerializeField]
    [Tooltip("Player Speed")]
    private float m_Speed;

    #endregion

    #region Private Variables
    private Animator cr_Anim;
    private Rigidbody cc_Rb;
    private Vector3 p_Velocity;
    private Vector3 target;
    private Vector3 rotation;
    float right, forward;
    #endregion

    #region Initialization
    private void Awake()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        this.gameObject.SetActive(true);
        p_Velocity = Vector3.zero;
        cc_Rb = GetComponent<Rigidbody>();
        cr_Anim = GetComponent<Animator>();
        cr_Anim.speed = 0;
        rotation = Vector3.zero;
        right = 0; forward = 0;

    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_text.color = Color.clear;
        m_image.color = Color.clear;
        m_button.GetComponent<Image>().color = Color.clear;
        m_buttontext.color = Color.clear;
    }

    #endregion

    #region Main Updates
    private void Update()
    {
        //MOVEMENT USING KEYS
        // see how hard player is pressomg movement buttons
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Starting the animation based on user input 
            // up and down (+ and -)
            forward = Input.GetAxis("Vertical");
            //right and left(+ and -)
            right = Input.GetAxis("Horizontal");
            cr_Anim.speed = 2;
            //Move player based on user input 
            p_Velocity = new Vector3(right, 0.0f, forward);
        }
        else
        {
            p_Velocity = Vector3.zero;
            cr_Anim.speed = 0;
        }

        //Update player position
        cc_Rb.MovePosition(cc_Rb.position + m_Speed * Time.fixedDeltaTime * p_Velocity.magnitude * transform.forward);

        if (p_Velocity.sqrMagnitude > 0)
        {
            float angletoRotCam = Mathf.Deg2Rad * Vector2.SignedAngle(Vector2.up, p_Velocity);
            Vector3 camForward = m_CameraTransform.forward;
            Vector3 newRot = new Vector3(Mathf.Cos(angletoRotCam) * camForward.x - Mathf.Sin(angletoRotCam) * camForward.z, 0, Mathf.Cos(angletoRotCam) * camForward.z + Mathf.Sin(angletoRotCam) * camForward.x);
            float theta = Vector3.SignedAngle(transform.forward, newRot, Vector3.up);
            cc_Rb.rotation = Quaternion.Slerp(cc_Rb.rotation, cc_Rb.rotation * Quaternion.Euler(0, theta, 0), 0.05f);
        }
    }
    #endregion


    #region Collision Methods
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "tv")
        {
            Cursor.lockState = CursorLockMode.None;
            cc_Rb.constraints = RigidbodyConstraints.FreezeRotation;
            m_image.color = Color.white;
            m_text.color = Color.black;
            m_button.GetComponent<Image>().color = Color.black;
            m_buttontext.color = Color.white;
            m_text.text = "Switch on screen display?";
        }
        if(collision.collider.tag == "Inventory")
        {
            Cursor.lockState = CursorLockMode.None;
            cc_Rb.constraints = RigidbodyConstraints.FreezeRotation;
            m_image.color = Color.white;
            m_text.color = Color.black;
            m_button.GetComponent<Image>().color = Color.black;
            m_buttontext.color = Color.white;
            m_text.text = "Open inventory?"; 
        }

        if (collision.collider.tag == "door")
        {
            Cursor.lockState = CursorLockMode.None;
            cc_Rb.constraints = RigidbodyConstraints.FreezeRotation;
            m_image.color = Color.white;
            m_text.color = Color.black;
            m_button.GetComponent<Image>().color = Color.black;
            m_buttontext.color = Color.white;
            m_text.text = "Enter Cockpit?";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_text.color = Color.clear;
        m_image.color = Color.clear;
        m_button.GetComponent<Image>().color = Color.clear;
        m_buttontext.color = Color.clear;
    }
    #endregion

    #region Button Methods
    public void YesClick()
    {
        m_text.color = Color.clear;
        m_image.color = Color.clear;
        m_button.GetComponent<Image>().color = Color.clear;
        m_buttontext.color = Color.clear;
        if (m_text.text == "Switch on screen display?")
        {
            SceneManager.LoadScene("5.Map");

        }
        if (m_text.text == "Enter Cockpit?")
        {
            this.gameObject.SetActive(false);
            cam1.enabled = false;
            cam2.enabled = true;
            exit.GetComponent<Image>().color = Color.white;
            exit_t.color = Color.black;
    }
    }

    public void ExitClick()
    {
        this.gameObject.SetActive(true);
        cam1.enabled = true;
        cam2.enabled = false;
        exit.GetComponent<Image>().color = Color.clear;
        exit_t.color = Color.clear;
    }
    #endregion


}
