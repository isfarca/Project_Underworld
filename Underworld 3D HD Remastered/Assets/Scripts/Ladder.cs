using UnityEngine;

public class Ladder : MonoBehaviour
{
    #region Declare variables

    // Value types
    private bool canClimb = false;
    private float speed = 100f;

    // Reference types
    private GameObject player;

    #endregion

    #region Main function "Start()"

    // Use this for initialization
    void Start ()
    {
        // Algorithm
        GetPlayerGameObject();
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
        canClimb = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canClimb = false;
    }

    #endregion

    #region Custom functions

    #region Functions for "Start()"

    void GetPlayerGameObject()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    #endregion

    #region Functions for "Update()"

    void ClimbLadder()
    {
        if (player != null)
        {
            if (canClimb)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    player.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }

    #endregion

    #endregion
}
