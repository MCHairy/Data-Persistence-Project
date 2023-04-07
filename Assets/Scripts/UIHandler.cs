using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIHandler : MonoBehaviour
{

    public string playerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart()
    {
        MenuManager.Instance.SetPlayerName(playerName);
        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReadStringInput(string name)
    {
         this.playerName = name;
    }
    
}
