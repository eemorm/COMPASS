using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/GunWeapon")]
public class GunWeaponData : ScriptableObject
{
    public int damage;
    public float fireRate;
    public AnimationClip gunAttackAnimation;
    // Add other properties as needed
}