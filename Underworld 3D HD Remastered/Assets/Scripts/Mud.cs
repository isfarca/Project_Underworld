using UnityEngine;

public class Mud : MonoBehaviour
{
    #region Declare variables

    // Value types
    private bool canSink = false;
    private float jumpSpeed = 0.1f;

    // Reference types
    private CharacterMotorC characterMotorCScript;
    private GameObject playerAsset;

    #endregion

    #region Main function "Start()"

    void Start()
    {
        // Algorithm
        GetCharacterMotorCScript();
        GetPlayerAsset();
    }

    #endregion

    #region Main function "Update()"

    void Update()
    {
        // Algorithm
        JumpPlayerAsset();
    }

    #endregion

    #region System functions

    private void OnTriggerEnter(Collider other)
    {
        canSink = true;

        if (characterMotorCScript != null)
        {
            // Slow it down
            characterMotorCScript.movement.maxForwardSpeed /= 2;
            characterMotorCScript.movement.maxSidewaysSpeed /= 2;
            characterMotorCScript.movement.maxBackwardsSpeed /= 2;

            // No gravity
            characterMotorCScript.movement.gravity = 0f;
            characterMotorCScript.movement.maxFallSpeed = 1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canSink = false;

        if (characterMotorCScript != null)
        {
            // Restore original speed
            characterMotorCScript.movement.maxForwardSpeed *= 2;
            characterMotorCScript.movement.maxSidewaysSpeed *= 2;
            characterMotorCScript.movement.maxBackwardsSpeed *= 2;

            // Set gravity
            characterMotorCScript.movement.gravity = 20f;
            characterMotorCScript.movement.maxFallSpeed = 20f;
        }
    }

    #endregion

    #region Custom functions

    #region Functions for "Start()"

    void GetCharacterMotorCScript()
    {
        characterMotorCScript = FindObjectOfType<CharacterMotorC>();
    }

    void GetPlayerAsset()
    {
        playerAsset = GameObject.FindGameObjectWithTag("Player");
    }

    #endregion

    #region Functions for "Update()"

    void JumpPlayerAsset()
    {
        if (canSink)
        {
            if (playerAsset != null)
            {
                if (Input.GetAxis("Jump") > 0)
                {
                    playerAsset.transform.position = new Vector3
                    (
                        playerAsset.transform.position.x,
                        playerAsset.transform.position.y + jumpSpeed,
                        playerAsset.transform.position.z
                    );
                }
            }
        }
    }

    #endregion

    #endregion
}
