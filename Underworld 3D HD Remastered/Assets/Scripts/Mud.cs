using UnityEngine;

public class Mud : MonoBehaviour
{
    #region Declare variables

    // Reference types
    private CharacterMotorC characterMotorCScript;

    #endregion

    #region System functions

    private void OnTriggerEnter(Collider other)
    {
        GetCharacterMotorCScript();

        // Slow it down
        characterMotorCScript.movement.maxForwardSpeed /= 2;
        characterMotorCScript.movement.maxSidewaysSpeed /= 2;
        characterMotorCScript.movement.maxBackwardsSpeed /= 2;
    }

    private void OnTriggerExit(Collider other)
    {
        GetCharacterMotorCScript();

        // Restore original speed
        characterMotorCScript.movement.maxForwardSpeed *= 2;
        characterMotorCScript.movement.maxSidewaysSpeed *= 2;
        characterMotorCScript.movement.maxBackwardsSpeed *= 2;
    }

    #endregion

    #region Custom functions

    #region Other auxiliary functions

    void GetCharacterMotorCScript()
    {
        characterMotorCScript = FindObjectOfType<CharacterMotorC>();
    }

    #endregion

    #endregion
}
