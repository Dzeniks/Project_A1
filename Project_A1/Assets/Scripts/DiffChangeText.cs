using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DiffChangeText : MonoBehaviour
{
    // def Difficult
    private int i = 1;
    private string[] difficulties = { "Easy", "Medium", "Hard", "HardPlus" };
    public TextMeshProUGUI DiffText;
    
    // Start is called before the first frame update
    void Start()
    {
        DiffText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject MainMenu = GameObject.Find("MainMenu");
        mainMenu MenuScript = MainMenu.GetComponent<mainMenu>();
        
        if (i >= 4)
        {
            i = 0;
        }
        if (true)
        {
            i++;
            Debug.Log(i);
        }
        
        
        Debug.Log(difficulties[i]);
        DiffText.text = $"{difficulties[i]}";
    }
}
