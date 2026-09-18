using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinMenuUI : MonoBehaviour
{
    public TMPro.TMP_Text skinName;
    public Image skin;
    public TMPro.TMP_Text price;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSkin();
        SkinSelector.Instance.SkinAssignments();
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
            skinName.text = SkinSelector.Instance.GetCurrentName();
            skin.sprite = SkinSelector.Instance.GetCurrentSkin();
            price.text = SkinSelector.Instance.GetCurrentPrice().ToString();
        }
    }
}
