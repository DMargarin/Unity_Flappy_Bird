using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyLevelsUIScript : MonoBehaviour
{
    public GameObject mark1;
    public GameObject mark2;
    public GameObject mark3;
    public LogicScript logic;

   

    // Start is called before the first frame update
    void Start()
    {
        
        //logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        bool markOneState = PlayerPrefs.GetInt("mark1", 0) == 1;
        bool markTwoState = PlayerPrefs.GetInt("mark2", 0) == 1;
        bool markThreeState = PlayerPrefs.GetInt("mark3", 0) == 1;

        mark1.SetActive(markOneState);
        mark2.SetActive(markTwoState);
        mark3.SetActive(markThreeState);

        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void deleteAllMarks() {
        
        PlayerPrefs.DeleteKey("mark1");
        PlayerPrefs.DeleteKey("mark2");
        PlayerPrefs.DeleteKey("mark3");
        PlayerPrefs.Save();
    }

}
