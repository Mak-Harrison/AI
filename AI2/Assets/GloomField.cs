using UnityEngine;

public class GloomField : MonoBehaviour
{
    public GameObject plantToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the thing touching the field is the Player OR the AI
        if (other.CompareTag("Player") || other.CompareTag("AI"))
        {
            if (Collectable.hasSoul)
            {
                Collectable.hasSoul = false;

                if (plantToSpawn != null)
                {
                    plantToSpawn.SetActive(true);
                    Debug.Log("The AI or Player delivered a Soul! Gloomroot appeared.");
                }
            }
        }
    }
}
