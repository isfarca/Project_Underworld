using UnityEngine;

public class Lava : MonoBehaviour
{
    #region Declare variables

    // Reference types
    private GameObject respawn;

    #endregion

    #region System functions

    private void OnTriggerEnter(Collider other)
    {
        // Declare variables
        Player player = FindObjectOfType<Player>();

        if (player != null)
        {
            if (player.Live > 0)
            {
                player.Live--;

                respawn = GameObject.FindGameObjectWithTag("Respawn");

                if (respawn != null)
                {
                    player.transform.position = new Vector3
                    (
                        respawn.transform.position.x - 0.011f,
                        respawn.transform.position.y + 1.16f,
                        respawn.transform.position.z
                     );
                }
            }
            else
            {
                // Show LoseScreen
            }
        }
    }

    #endregion
}
