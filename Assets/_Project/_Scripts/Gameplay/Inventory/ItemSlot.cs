using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item _item;
    private Image imageItem;
    private Image imageFrame;
    public int amount = 0;
    private TextMeshProUGUI quantityTMP;
    
    [SerializeField] private Color32 lockColor = new Color32(90, 90, 90,225);
    private Color32 unlockColor = new Color32(255, 255, 255,255);
    private Color32 nullColor = new Color32(0, 0, 0,0);


    private void Awake()
    {
        imageItem = transform.GetChild(0).GetComponent<Image>();
        imageFrame = transform.GetComponent<Image>();
        quantityTMP = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void UpdateSlotUI()
    {
        if (_item == null)
        {
            quantityTMP.text = "";
            imageItem.color = nullColor;
            imageItem.sprite = null;

            return;
        }

        imageItem.sprite = _item.icon;

        switch (_item)
        {
            case EquipItem when amount > 0:
                imageItem.color = unlockColor;
                quantityTMP.text = "";
                break;
            case EquipItem:
                imageItem.color = lockColor;
                quantityTMP.text = "";
                break;
            default:
                quantityTMP.text = amount.ToString();
                imageItem.color = unlockColor;
                break;
        }
    }

    public void SetFrameIMG(Sprite sprite)
    {
        imageFrame.sprite = sprite;
    }
}