using UnityEngine;

public class Player : MonoBehaviour
{
    #region Declare variables

    // Value types
    private int lives = 3;
    public const float POS_X = 0.011f;
    public const float POS_Y = 1.16f;

    // Reference types
    private GameObject respawn;

    #endregion

    #region Main function "Start()"

    void Start()
    {
        // Algorithm
        GetRespawnGameObject();
    }

    #endregion

    #region Main function "Update()"

    void Update()
    {
        // Algorithm
        SetPlayerPositionX();
    }

    #endregion

    #region Custom functions

    #region Functions for "Start()"

    void GetRespawnGameObject()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn");
    }

    #endregion

    #region Functions for "Update()"

    void SetPlayerPositionX()
    {
        if (transform.position.x != (respawn.transform.position.x - POS_X))
        {
            transform.position = new Vector3
            (
                (respawn.transform.position.x - POS_X),
                transform.position.y,
                transform.position.z
            );
        }
    }

    #endregion

    #endregion

    #region Return values

    public int Live
    {
        get { return lives; }
        set { lives = value; }
    }

    #endregion
}
