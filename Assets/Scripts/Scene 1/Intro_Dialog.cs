using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro_Dialog : MonoBehaviour
{

    #region Editor Variables
    [SerializeField]
    [Tooltip("Intro text")]
    private Text intro;

    [SerializeField]
    [Tooltip("Intro text 1")]
    private Text intro1;

    [SerializeField]
    [Tooltip("Dialog text")]
    private Text dialog;
    #endregion

    #region Variables
    private string[] intro_dialog;
    private GameObject introText;
    private bool intro_finish;
    private bool dialog_finish;
    private int i;
    #endregion

    #region Initialization
    // Use this for initialization
    void Start()
    {
        intro.text = "";
        dialog.text = "";
        i = 0;
        intro_finish = false;
        dialog_finish = false;
        StartCoroutine(IntroWriting("YEAR 2910\n EARTH", intro, 0.5f, 0.14f, 1.8f));
        intro_dialog = new string[6];
        intro_dialog[0] = "Over the last few centuries, earth’s population has grown exponentially, currently reaching 12 billion people.";
        intro_dialog[1] = "We have tried solutions like building upwards to resolve this issue but things have only gotten worse with time.";
        intro_dialog[2] = "Our overpopulation has resulted in large amounts of garbage, droughts, deforestation, pollution, and much more.";
        intro_dialog[3] = "We are afraid that this planet will not be able to sustain us for much longer.";
        intro_dialog[4] = "There is only one solution now.";
        intro_dialog[5] = "And we need YOUR help."; 
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        if(intro.text == "YEAR 2910\n EARTH" && intro_finish)
        {
            intro_finish = false;
            intro.text = "";
            StartCoroutine(DialogWriting(intro_dialog[0]));
        }

        if (i < 5)
        {
            if (dialog.text == intro_dialog[i] && dialog_finish)
            {
                dialog_finish = false;
                dialog.text = "";
                StartCoroutine(DialogWriting(intro_dialog[i + 1]));
                i += 1;
            }
        }
        if (i == 5)
        {
            if (dialog.text == intro_dialog[i] && dialog_finish)
            {
                dialog_finish = false;
                dialog.text = "";
                intro1.text = "";
                StartCoroutine(IntroWriting("UNITED AEROSPACE\n GLOBAL HEADQUARTERS", intro1, 1.5f, 0.14f, 2.5f));
            }
        }

        if (intro1.text == "UNITED AEROSPACE\n GLOBAL HEADQUARTERS" && intro_finish)
        {
            SceneManager.LoadScene("2.Intro_mission");
        }
    }

    #region Coroutines
    private IEnumerator IntroWriting(string text, Text input, float startSec, float typeTime, float endsec)
    {
        yield return new WaitForSeconds(startSec);
        foreach (char c in text)
        {
            yield return new WaitForSeconds(typeTime);
            input.text += c;
        }
        yield return new WaitForSeconds(endsec);
        intro_finish = true;
        input.color = Color.clear;
    }

    private IEnumerator DialogWriting(string text)
    {
        yield return new WaitForSeconds(0.5f);
        foreach (char c in text)
        {
            yield return new WaitForSeconds(0.025f);
            dialog.text += c;
        }
        yield return new WaitForSeconds(3.0f);
        dialog_finish = true;
    }
    #endregion

}
