using UnityEngine;

public class CharonTrade : MonoBehaviour
{
    public GameObject obolPrefab;
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Charon's specific requirement: Biscuit AND Liquid Fire
            if (Collectable.hasBiscuit && Collectable.hasLiquidFire)
            {
                // Consume the items
                Collectable.hasBiscuit = false;
                Collectable.hasLiquidFire = false;

                // Reward the player
                Collectable.hasObol = true;
                SpawnObol();

                Debug.Log("Charon: The heat of the fire and the crunch of the biscuit... a fair trade. Here is your Obol.");
            }
            else
            {
                // Hint to the player what is missing
                if (!Collectable.hasBiscuit && !Collectable.hasLiquidFire)
                    Debug.Log("Charon: You come empty handed? I need a Biscuit and Liquid Fire.");
                else if (!Collectable.hasBiscuit)
                    Debug.Log("Charon: The fire is good, but where is the Biscuit?");
                else
                    Debug.Log("Charon: A dry biscuit? I need Liquid Fire to wash it down.");
            }
        }
    }

    void SpawnObol()
    {
        if (obolPrefab != null && spawnPoint != null)
            Instantiate(obolPrefab, spawnPoint.position, Quaternion.identity);
    }
}
