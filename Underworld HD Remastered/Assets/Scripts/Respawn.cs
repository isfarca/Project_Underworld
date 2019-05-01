using UnityEngine;

public class Respawn : MonoBehaviour
{
    #region Custom functions

    public void StartPosition()
    {
        // Declare variables
        GameObject playerAsset = GameObject.FindGameObjectWithTag("Player");
        GameObject respawnAsset = GameObject.FindGameObjectWithTag("Respawn");

        if (playerAsset != null && respawnAsset != null)
        {
            playerAsset.transform.position = new Vector3
            (
                respawnAsset.transform.position.x - Player.POS_X,
                respawnAsset.transform.position.y + Player.POS_Y,
                respawnAsset.transform.position.z
             );
        }
    }

    #endregion
}
