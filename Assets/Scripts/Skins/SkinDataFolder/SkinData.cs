using UnityEngine;

[CreateAssetMenu(fileName = "NewSkin", menuName = "Skins/SkinData")]
public class SkinData : ScriptableObject
{
    public string skinName; // Name of the skin
    public int cost;
    public Sprite previewIcon;
    public RuntimeAnimatorController animatorController; // Animator controller for the skin
}
