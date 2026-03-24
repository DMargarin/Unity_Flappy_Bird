using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinMenuUI : MonoBehaviour
{
    public Image skin;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateSkin();
    }

    public void NextSkin()
    {
        if (SkinSelector.Instance != null)
        {
            SkinSelector.Instance.NextSkin();
            UpdateSkin();
        }
    }

    public void PreviousSkin()
    {
        if (SkinSelector.Instance != null)
        {
            SkinSelector.Instance.PreviousSkin();
            UpdateSkin();
        }
    }

    void UpdateSkin()
    {
        if (SkinSelector.Instance != null)
        {
            skin.sprite = SkinSelector.Instance.GetCurrentSkin();
        }
    }
}
