using UnityEngine;

public class InteractionPoint : MonoBehaviour
{
    public enum LocationType { Bakery, Charon, CowPasture }
    public LocationType currentPoint;

    public GameObject rewardToSpawn; // The Biscuit, Obol, or Liquid Fire

    private void OnTriggerEnter(Collider other)
    {
        // STEP 1: Check if the thing touching us is EITHER the Player OR the AI
        if (other.CompareTag("Player") || other.CompareTag("AI"))
        {
            // STEP 2: Handle the Bakery Logic
            if (currentPoint == LocationType.Bakery)
            {
                if (Collectable.hasEgg && Collectable.hasGloomroot)
                {
                    Collectable.hasEgg = false;
                    Collectable.hasGloomroot = false;
                    Collectable.hasBiscuit = true;

                    if (rewardToSpawn != null)
                    {
                        rewardToSpawn.SetActive(true);
                        Debug.Log("Bakery: " + other.tag + " delivered items. Biscuit spawned!");
                    }
                }
            }

            // STEP 3: Handle the Charon Logic
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

            // STEP 4: Handle the Cow Logic
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
