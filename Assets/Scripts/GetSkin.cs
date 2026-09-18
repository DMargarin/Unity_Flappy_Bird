using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSkin : MonoBehaviour
{
    public SpriteRenderer skin;
    

    void Start()
    {
        string wholeName = "skin_" + SkinSelector.Instance.GetCurrentName();

        bool i = PlayerPrefs.GetInt(wholeName, 0) == 1;

        if (i == true)
        {
            skin.sprite = SkinSelector.Instance.GetCurrentSkin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
