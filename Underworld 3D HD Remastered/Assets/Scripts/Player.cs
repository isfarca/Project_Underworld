using UnityEngine;

public class Player : MonoBehaviour
{
    #region Declare variables

    // Value types
    private int lives = 2;

    #endregion

    #region Return values

    public int Live
    {
        get { return lives; }
        set { lives = value; }
    }

    #endregion
}
