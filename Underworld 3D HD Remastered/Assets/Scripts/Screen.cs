using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen : MonoBehaviour
{
    #region Main function "Update()"

    void Update()
    {
        // Algorithm
        PressEnterKey();
    }

    #endregion

    #region Custom functions

    #region Functions for "Update()"

    void PressEnterKey()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            LoadLevel();
    }

    #endregion

    #region Other auxiliary functions

    public void LoadLevel()
    {
        SceneManager.LoadScene(1); // Load level 1
    }

    #endregion

    #endregion
}
