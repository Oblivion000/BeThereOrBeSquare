using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkinShopItem : MonoBehaviour
{
    public Image previewImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI previewText;
    public TextMeshProUGUI costText;
    public Button buyEquipButton;

    private SkinData skinData;
    private SkinShopManager shopManager;

    public void Setup(SkinData data, SkinShopManager manager)
    {
        skinData = data;
        shopManager = manager;

        Debug.Log($"Setting up skin: {skinData.skinName}, cost: {skinData.cost}");

        previewImage.sprite = skinData.previewIcon;
        nameText.text = skinData.skinName;

        if (SkinManager.Instance.IsSkinOwned(skinData.skinName))
        {
            costText.text = "Owned";
            buyEquipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
        }
        else
        {
            costText.text = skinData.cost + " Gems";
            buyEquipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
        }

        buyEquipButton.onClick.AddListener(() => shopManager.OnSkinButtonClicked(skinData));
    }


}

