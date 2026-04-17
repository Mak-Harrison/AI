using UnityEngine;

public class InteractionPoint : MonoBehaviour
{
    public enum LocationType { Bakery, Charon, CowPasture }
    public LocationType currentPoint;

    public GameObject rewardToSpawn; // The Biscuit, Obol, or Liquid Fire

    private void OnTriggerEnter(Collider other)
    {
        // 1. First, check if it's actually the Player touching the trigger
        if (other.CompareTag("Player"))
        {
            // 2. CHECK FOR BAKERY
            if (currentPoint == LocationType.Bakery)
            {
                Debug.Log("Player touched the Bakery!");

                if (Collectable.hasEgg && Collectable.hasGloomroot)
                {
                    Collectable.hasEgg = false;
                    Collectable.hasGloomroot = false;
                    Collectable.hasBiscuit = true;

                    if (rewardToSpawn != null)
                    {
                        rewardToSpawn.SetActive(true);
                        Debug.Log("Success: Biscuit Spawned!");
                    }
                }
                else
                {
                    Debug.Log("Bakery: Missing items! Egg: " + Collectable.hasEgg + " | Root: " + Collectable.hasGloomroot);
                }
            }

            // 3. CHECK FOR CHARON
            else if (currentPoint == LocationType.Charon)
            {
                if (Collectable.hasBiscuit && Collectable.hasLiquidFire)
                {
                    Collectable.hasBiscuit = false;
                    Collectable.hasLiquidFire = false;
                    Collectable.hasObol = true;

                    if (rewardToSpawn != null)
                    {
                        rewardToSpawn.SetActive(true);
                        Debug.Log("Charon: Trade complete!");
                    }
                }
                else
                {
                    Debug.Log("Charon: You need a Biscuit and Liquid Fire.");
                }
            }

            // 4. CHECK FOR COW
            else if (currentPoint == LocationType.CowPasture)
            {
                if (Collectable.hasFeed)
                {
                    Collectable.hasFeed = false;
                    Collectable.hasLiquidFire = true;

                    if (rewardToSpawn != null)
                    {
                        rewardToSpawn.SetActive(true);
                        Debug.Log("Cow: Produced Liquid Fire!");
                    }
                }
            }
        }
    }
}
