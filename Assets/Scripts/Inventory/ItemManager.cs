using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    //Melee
    public MeleeWeaponData crowbar;
    public MeleeWeaponData hatchet;
    public MeleeWeaponData switchblade;
    public MeleeWeaponData pipe;
    public MeleeWeaponData shovel;
    public MeleeWeaponData screwdriver;
    public MeleeWeaponData flashlight;
    public MeleeWeaponData brassknuckles;
    //Guns
    public GunWeaponData basicshotgun;
    //Other
    public PlayerMelee playerattackm;
    public PlayerGun playerattackg;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ItemList(InventoryItem item)
    {
        //Melee
        if (item.itemData.displayName == "Crowbar")
        {
            playerattackg.enabled = false;
            playerattackm.enabled = true;
            playerattackm.weaponData = crowbar;
        }
        else if (item.itemData.displayName == "Hatchet")
        {
            playerattackg.enabled = false;
            playerattackm.enabled = true;
            playerattackm.weaponData = hatchet;
        }
        else if (item.itemData.displayName == "Switchblade")
        {
            playerattackg.enabled = false;
            playerattackm.enabled = true;
            playerattackm.weaponData = switchblade;
        }
        else if (item.itemData.displayName == "Pipe")
        {
            playerattackg.enabled = false;
            playerattackm.enabled = true;
            playerattackm.weaponData = pipe;
        }
        else if (item.itemData.displayName == "Shovel")
        {
            playerattackg.enabled = false;
            playerattackm.enabled = true;
            playerattackm.weaponData = shovel;
        }
        else if (item.itemData.displayName == "Screwdriver")
        {
            playerattackg.enabled = false;
            playerattackm.enabled = true;
            playerattackm.weaponData = screwdriver;
        }
        else if (item.itemData.displayName == "Flashlight")
        {
            playerattackg.enabled = false;
            playerattackm.enabled = true;
            playerattackm.weaponData = flashlight;
        }
        else if (item.itemData.displayName == "Brass Knuckles")
        {
            playerattackg.enabled = false;
            playerattackm.enabled = true;
            playerattackm.weaponData = brassknuckles;
        }
        //Guns
        else if (item.itemData.displayName == "Basic Shotgun")
        {
            playerattackg.enabled = true;
            playerattackm.enabled = false;
            playerattackg.weaponData = basicshotgun;
        }
    }
}