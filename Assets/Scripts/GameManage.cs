using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    #region Variables
    public string username;
    public Sprite icon;
    public int days_passed;

    #endregion
    private void Awake()
    {
        days_passed = 0;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
