using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance;
    private const string EquippedSkinKey = "EquippedSkin";
    private const string OwnedSkinsKey = "OwnedSkin_";

    public SkinData equippedSkin;

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;

        DontDestroyOnLoad(gameObject);
        LoadEquippedSkin();
    }

    public void UnlockSkin(string skinName)
    {
        PlayerPrefs.SetInt(OwnedSkinsKey + skinName, 1);
        PlayerPrefs.Save();
    }

    public bool IsSkinOwned(string skinName)
    {
        return PlayerPrefs.GetInt(OwnedSkinsKey + skinName, 0) == 1;
    }

    public void EquipSkin(SkinData skin)
    {
        equippedSkin = skin;
        PlayerPrefs.SetString(EquippedSkinKey, skin.skinName);
        PlayerPrefs.Save();
    }

    private void LoadEquippedSkin()
    {
        string equippedName = PlayerPrefs.GetString(EquippedSkinKey, "");

        // Match with SkinData (simplified approach for now)
        foreach (var s in Resources.LoadAll<SkinData>(""))
        {
            if (s.skinName == equippedName)
            {
                equippedSkin = s;
                break;
            }
        }
    }
}

