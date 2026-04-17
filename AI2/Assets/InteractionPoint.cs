using UnityEngine;

public class InteractionPoint : MonoBehaviour
{
    public enum LocationType { CowPasture, Bakery, Charon }
    public LocationType currentPoint;

    public GameObject rewardToSpawn; // Drag your Liquid Fire model here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentPoint == LocationType.CowPasture)
            {
                // Check if player has the starting feed
                if (Collectable.hasFeed)
                {
                    Collectable.hasFeed = false;    // Use the feed
                    Collectable.hasLiquidFire = true; // Give the player the fire

                    if (rewardToSpawn != null)
                    {
                        rewardToSpawn.SetActive(true); // Make the fire model appear!
                        Debug.Log("Cow: Fed! Liquid Fire produced.");
                    }
                }
                else
                {
                    Debug.Log("Cow: I'm hungry. Where is the feed?");
                }
            }
            // ... (keep the Bakery and Charon logic here too)
        }
    }
}
