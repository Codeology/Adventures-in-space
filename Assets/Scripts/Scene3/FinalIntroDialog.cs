using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalIntroDialog : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Header text")]
    private Text Speaker;

    [SerializeField]
    [Tooltip("Dialog text")]
    private Text dialog;

    [SerializeField]
    [Tooltip("Character image")]
    private Image Character;

    #endregion

    #region Variables
    private GameManage gm;
    private string[] intro_dialog;
    private bool dialog_finish; 
    #endregion

    // Use this for initialization
    void Start()
    {
        Speaker.text = "UA Senior Administrator";
   //     Character.GetComponent<Image>().sprite = gm.icon;
        dialog_finish = false;
        intro_dialog = new string[5];
        intro_dialog[0] = "To help you with the mission, the ship is equipped with a DIGITAL MAP OF THE OBSERVABLE UNIVERSE. ";
        intro_dialog[1] = "We have also included enough food and water to last 365 days in your time frame, accounting for time dilation.";
        intro_dialog[2] = "Lastly, we have provided you with a few weapons to help you in your journey, should you encounter any formidable creatures.";
        StartCoroutine(DialogWriting(intro_dialog[0]));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            if (dialog.text == intro_dialog[i] && dialog_finish)
            {
                dialog_finish = false;
                dialog.text = "";
                StartCoroutine(DialogWriting(intro_dialog[i + 1]));
            }
          

        }
    }

    #region Coroutines
    private IEnumerator DialogWriting(string text)
    {
        yield return new WaitForSeconds(0.5f);
        foreach (char c in text)
        {
            yield return new WaitForSeconds(0.011f);
            dialog.text += c;
        }
        yield return new WaitForSeconds(1.0f);
        dialog_finish = true;
    }
        #endregion

}
