using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    #region System functions

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }

    #endregion
}
