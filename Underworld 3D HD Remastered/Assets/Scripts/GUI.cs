using UnityEngine;

public class GUI : MonoBehaviour
{
    #region System functions

    private void OnGUI()
    {
        // Declare variables
        Player player = FindObjectOfType<Player>();

        if (player != null)
        {
            GUILayout.Label("Lives: " + player.Live);
        }
    }

    #endregion
}
