using UnityEngine;
using System.Collections.Generic;

public class SkinShopManager : MonoBehaviour
{
    public List<SkinData> availableSkins;
    public GameObject skinItemPrefab;
    public Transform shopItemContainer;

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
        }
    }

    public void OnSkinButtonClicked(SkinData skin)
    {
        if (!SkinManager.Instance.IsSkinOwned(skin.skinName))
        {
            if (CurrencyManager.Instance.SpendCurrency(skin.cost))
            {
                SkinManager.Instance.UnlockSkin(skin.skinName);
            }
            else
            {
                Debug.Log("Not enough coins!");
                return;
            }
        }

        SkinManager.Instance.EquipSkin(skin);
    }
}

