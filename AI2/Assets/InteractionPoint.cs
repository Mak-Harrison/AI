using UnityEngine;

public class InteractionPoint : MonoBehaviour
{
    public enum LocationType { Bakery, Charon }
    public LocationType currentPoint;

    public GameObject rewardToSpawn; // The Biscuit or the Obol

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentPoint == LocationType.Bakery)
            {
                // Checks the names exactly as they appear in Collectable.cs
                if (Collectable.hasEgg && Collectable.hasGloomroot)
                {
                    // Consumes the ingredients
                    Collectable.hasEgg = false;
                    Collectable.hasGloomroot = false;

                    // Gives the biscuit
                    Collectable.hasBiscuit = true;
                    rewardToSpawn.SetActive(true);
                    Debug.Log("Bakery created a Biscuit!");
                }
            }
            else if (currentPoint == LocationType.Charon)
            {
                // Checks for Biscuit and Fire
                if (Collectable.hasBiscuit && Collectable.hasLiquidFire)
                {
                    Collectable.hasBiscuit = false;
                    Collectable.hasLiquidFire = false;

                    Collectable.hasObol = true;
                    rewardToSpawn.SetActive(true);
                    Debug.Log("Charon gave you an Obol!");
                }
            }
        }
    }
}
