using UnityEngine;
using System.Collections.Generic;

public class SkinShopManager : MonoBehaviour
{
    public List<SkinData> availableSkins = new List<SkinData>();
    public GameObject skinItemPrefab;
    public Transform shopItemContainer;

    public GameObject floatingTextPrefab;
    public Transform floatingTextSpawnPoint;

    void Start()
    {
        PopulateShop();
    }

    void PopulateShop()
    {
        foreach (var skin in availableSkins)
        {
            GameObject item = Instantiate(skinItemPrefab, shopItemContainer);
            item.GetComponent<SkinShopItem>().Setup(skin, this);
            Debug.Log($"Added skin to shop: {skin.skinName} with cost {skin.cost}");
        }
    }

    public void OnSkinButtonClicked(SkinData skin)
    {
        if (!SkinManager.Instance.IsSkinOwned(skin.skinName))
        {
            if (CurrencyManager.Instance.SpendCurrency(skin.cost))
            {
                SkinManager.Instance.UnlockSkin(skin.skinName);
                ShowFloatingText("Purchased " + skin.skinName + "!");
            }
            else
            {
                Debug.Log("Not enough gems!");
                ShowFloatingText("Not enough gems!");
                return;
            }
        }
        else
        {
            ShowFloatingText("Equipped " + skin.skinName + "!");
        }

            SkinManager.Instance.EquipSkin(skin);
    }

    void ShowFloatingText(string message)
    {
        GameObject textObj = Instantiate(floatingTextPrefab, floatingTextSpawnPoint);
        textObj.GetComponent<FloatingText>().Show(message);
    }
}

