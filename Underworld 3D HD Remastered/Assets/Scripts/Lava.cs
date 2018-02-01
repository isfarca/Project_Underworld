using UnityEngine;
using UnityEngine.SceneManagement;

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
                        respawn.transform.position.x - Player.POS_X,
                        respawn.transform.position.y + Player.POS_Y,
                        respawn.transform.position.z
                     );
                }
            }
            else
            {
                SceneManager.LoadScene(3); // Load lose screen
            }
        }
    }

    #endregion
}
