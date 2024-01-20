using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableInventory : MonoBehaviour
{
    public Canvas inventory;
    public PlayerMelee pm;
    public PlayerGun pg;

    bool melee;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.enabled)
            {
                inventory.enabled = false;
            }
            else
            {
                inventory.enabled = true;
            }
        }
    }
}
