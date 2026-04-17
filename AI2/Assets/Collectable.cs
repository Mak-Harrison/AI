using UnityEngine;

public enum ItemType { Soul, Egg, Gloomroot, Biscuit, Feed, LiquidFire, Obol }

public class Collectable : MonoBehaviour
{
    // The Global Ledger
    public static bool hasSoul = false;
    public static bool hasEgg = false;
    public static bool hasGloomroot = false; // Added for your original flow
    public static bool hasBiscuit = false;
    public static bool hasFeed = true;
    public static bool hasLiquidFire = false;
    public static bool hasObol = false;

    public ItemType itemToGive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (itemToGive == ItemType.Soul) hasSoul = true;
            if (itemToGive == ItemType.Egg) hasEgg = true;
            if (itemToGive == ItemType.Gloomroot) hasGloomroot = true;
            if (itemToGive == ItemType.Biscuit) hasBiscuit = true;
            if (itemToGive == ItemType.LiquidFire) hasLiquidFire = true;

            Debug.Log("Picked up: " + itemToGive);
            Destroy(gameObject);
        }
    }
}
