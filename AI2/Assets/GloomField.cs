using UnityEngine;

public class GloomField : MonoBehaviour
{
    public GameObject plantToSpawn; // The Gloomroot asset that appears

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Original logic: Use a Soul to sprout the root
            if (Collectable.hasSoul)
            {
                Collectable.hasSoul = false;

                if (plantToSpawn != null)
                {
                    plantToSpawn.SetActive(true);
                    Debug.Log("The Soul has bloomed into a Gloomroot!");
                }
            }
            else
            {
                Debug.Log("The field is empty. It needs a Soul.");
            }
        }
    }
}
