using UnityEngine;

public class Player : MonoBehaviour
{
    #region Declare variables

    // Value types
    private int lives = 3;
    private float resetPoint = -30f;
    public const float POS_X = 0.011f;
    public const float POS_Y = 1.16f;

    // Reference types
    private GameObject respawnAsset;
    private Respawn respawnScript;

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

        ResetPlayerPosition();
    }

    #endregion

    #region Custom functions

    #region Functions for "Start()"

    void GetRespawnGameObject()
    {
        respawnAsset = GameObject.FindGameObjectWithTag("Respawn");
    }

    #endregion

    #region Functions for "Update()"

    void SetPlayerPositionX()
    {
        if (transform.position.x != (respawnAsset.transform.position.x - POS_X))
        {
            transform.position = new Vector3
            (
                (respawnAsset.transform.position.x - POS_X),
                transform.position.y,
                transform.position.z
            );
        }
    }

    void ResetPlayerPosition()
    {
        if (transform.position.y < resetPoint)
        {
            respawnScript = FindObjectOfType<Respawn>();

            respawnScript.StartPosition();
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
