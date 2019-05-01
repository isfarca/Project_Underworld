using UnityEngine;

public class Ladder : MonoBehaviour
{
    #region Declare variables

    // Value types
    private bool canClimb = false;
    private float speed = 13f;

    // Reference types
    private GameObject playerAsset;
    private CharacterMotorC characterMotorCScript;

    #endregion

    #region Main function "Start()"

    // Use this for initialization
    void Start ()
    {
        // Algorithm
        GetPlayerGameObject();
        GetCharacterMotorCScript();

    }

    #endregion

    #region Main function "Update()"

    // Update is called once per frame
    void Update()
    {
        // Algorithm
        ClimbLadder();
    }

    #endregion

    #region System functions

    private void OnTriggerEnter(Collider other)
    {
        // Gravity off
        characterMotorCScript.movement.maxFallSpeed = 0f;

        canClimb = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // Gravity on
        characterMotorCScript.movement.maxFallSpeed = 20f;

        canClimb = false;
    }

    #endregion

    #region Custom functions

    #region Functions for "Start()"

    void GetPlayerGameObject()
    {
        playerAsset = GameObject.FindGameObjectWithTag("Player");
    }

    void GetCharacterMotorCScript()
    {
        characterMotorCScript = FindObjectOfType<CharacterMotorC>();
    }

    #endregion

    #region Functions for "Update()"

    void ClimbLadder()
    {
        if (playerAsset != null)
        {
            if (canClimb)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    playerAsset.transform.Translate(Vector3.up * speed * Time.deltaTime);
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    characterMotorCScript.movement.maxFallSpeed = 6f;
                else
                    characterMotorCScript.movement.maxFallSpeed = 0f;
            }
        }
    }

    #endregion

    #endregion
}
