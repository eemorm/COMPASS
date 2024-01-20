using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/MeleeWeapon")]
public class MeleeWeaponData : ScriptableObject
{
    public int damage;
    public AnimationClip meleeAttackAnimation;
    // Add other properties as needed
}
