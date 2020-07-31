using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mission_Dialog : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Header text")]
    private Text Speaker;

    [SerializeField]
    [Tooltip("Dialog text")]
    private Text dialog;

    [SerializeField]
    [Tooltip("Text entry gameobject")]
    private GameObject enterText;

    [SerializeField]
    [Tooltip("Input field")]
    private InputField userInput;

    [SerializeField]
    [Tooltip("icons")]
    private Button[] icons;

    [SerializeField]
    [Tooltip("Character image")]
    private Image Character;
    #endregion

    #region Variables
    private string[] intro_dialog;
    private GameObject introText;
    private bool started;
    private bool dialog_finish;
    private GameManage gm;
    private bool[] clickedButton;
    private bool continue_dialog;
    #endregion

    #region Initialization
    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManage>();
        Speaker.text = "";
        dialog.text = "";
        started = false;
        dialog_finish = false;
        continue_dialog = false;
        intro_dialog = new string[7];
        clickedButton = new bool[3];
        intro_dialog[0] = "Welcome";
        intro_dialog[1] = "Thank you for coming. The board of United Aerospace has summoned you here today for a very important mission.";
        intro_dialog[2] = "Aware of the earth's current predicament, you know that the human race cannot stay here for much longer.";
        intro_dialog[3] = "We can only think of one solution.";
        intro_dialog[4] = "As our most skilled pilot, you must venture outside our planet in order to find an ALTERNATIVE HABITATION FOR MANKIND.";
        intro_dialog[5] = "This journey has never been taken before. It is unpredictable and dangerous but it is our only hope.";
        intro_dialog[6] = "YOU ARE OUR ONLY HOPE.";
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        ButtonColorHandler();
        //Starting
        if (this.GetComponent<Image>().color.a.Equals (1) && started == false)
        {
            started = true;
            Speaker.text = "UA Senior Administrator";
            StartCoroutine(DialogWriting(intro_dialog[0], dialog));
        }
        //User input
        if (dialog.text == intro_dialog[0] && dialog_finish)
        {
            dialog_finish = false;
            dialog.text = "";
            enterText.SetActive(true);
        }
        if (continue_dialog)
        {
            continue_dialog = false;
            StartCoroutine(DialogWriting(intro_dialog[0] + " Captain " + gm.username, dialog));
        }

        if (dialog.text == intro_dialog[0] + " Captain " + gm.username && dialog_finish)
        {
            dialog_finish = false;
            dialog.text = "";
            StartCoroutine(DialogWriting(intro_dialog[1], dialog));
        }

        for (int i = 1; i < 6; i++)
        {
            if (dialog.text == intro_dialog[i] && dialog_finish)
            {
                dialog_finish = false;
                dialog.text = "";
                StartCoroutine(DialogWriting(intro_dialog[i + 1], dialog));
            }
        }
        if (dialog.text == intro_dialog[6] && dialog_finish)
        {
            dialog_finish = false;
            dialog.text = "";

        }


    }

    #region Coroutines
    private IEnumerator DialogWriting(string text, Text input)
    {
        yield return new WaitForSeconds(0.5f);
        foreach (char c in text)
        {
            yield return new WaitForSeconds(0.025f);
            input.text += c;
        }
        yield return new WaitForSeconds(0.8f);
        dialog_finish = true;
    }
    #endregion


    //Button method for continue (User input) 
    #region Button Methods
    public void GetInput()
    {
        if (userInput.text == "")
        {
            userInput.placeholder.color = Color.red;
        }
        else
        {
            gm.username = userInput.text;
            enterText.SetActive(false);
            Character.gameObject.SetActive(true);
            Character.GetComponent<Image>().sprite = gm.icon;
            continue_dialog = true;
        }
    }

    public void IconPress(string buttonName)
    {

        if (buttonName == "button1")
        {
            clickedButton[0] = true;
            clickedButton[1] = false;
            clickedButton[2] = false;
            gm.icon = icons[0].GetComponent<Image>().sprite;
        }
        else if (buttonName == "button2")
        {
            clickedButton[1] = true;
            clickedButton[0] = false;
            clickedButton[2] = false;
            gm.icon = icons[1].GetComponent<Image>().sprite;

        }
        else if (buttonName == "button3")
        {
            clickedButton[2] = true;
            clickedButton[0] = false;
            clickedButton[1] = false;
            gm.icon = icons[2].GetComponent<Image>().sprite;
        }
    }
    #endregion

    //Additional Functions
    #region Handler functions
    private void ButtonColorHandler()
    {
        for (int i = 0; i < 3; i++)
        {
            if (clickedButton[i])
            {
                icons[i].GetComponent<Image>().color = Color.blue;
            }
            else
            {
                icons[i].GetComponent<Image>().color = Color.white;

            }
        }
    }

    #endregion



}
