using UnityEngine;

public class LiveDisplay : MonoBehaviour
{
    #region Declare variables

    // Value types
    private const float PlayerPositionDistanceFactorZ = 0.1f;

    // Reference types
    private GameObject playerAsset;
    private Player playerScript;
    public GameObject[] liveSprites;

    #endregion

    #region Main function "Start()"

    void Start()
    {
        // Algorithm
        GetPlayerAsset();
        GetPlayerScript();

        FirstHeartsInstantiate();
    }

    #endregion

    #region Custom functions

    #region Functions for "Start()"

    void GetPlayerAsset()
    {
        playerAsset = GameObject.FindGameObjectWithTag("Player");
    }

    void GetPlayerScript()
    {
        playerScript = FindObjectOfType<Player>();
    }

    void FirstHeartsInstantiate()
    {
        InstantiateInGameObject
        (
            Instantiate(liveSprites[0], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), GetPlayerPositionDistanceZ()), transform.rotation),
            Instantiate(liveSprites[0], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + PlayerPositionDistanceFactorZ)), transform.rotation),
            Instantiate(liveSprites[0], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + (PlayerPositionDistanceFactorZ * 2))), transform.rotation)
        );
    }

    #endregion

    #region Other auxiliary functions

    /// <summary>
    /// Instantiate hearts in empty game object of the hierarchy.
    /// </summary>
    /// <param name="firstHeart"></param>
    /// <param name="secondHeart"></param>
    /// <param name="thirdHeart"></param>
    private void InstantiateInGameObject(GameObject firstHeart, GameObject secondHeart, GameObject thirdHeart)
    {
        // Declare variables
        GameObject liveDisplayEmpty = GameObject.Find("LiveDisplay");

        firstHeart.transform.parent = liveDisplayEmpty.transform;
        firstHeart.transform.localScale = GetHeartScaleValues();

        secondHeart.transform.parent = liveDisplayEmpty.transform;
        secondHeart.transform.localScale = GetHeartScaleValues();

        thirdHeart.transform.parent = liveDisplayEmpty.transform;
        thirdHeart.transform.localScale = GetHeartScaleValues();
    }

    /// <summary>
    /// Instantiate hearts and transfer to the function.
    /// </summary>
    public void SetHearts()
    {
        if (playerScript != null)
        {
            switch (playerScript.Live)
            {
                case 2:

                    InstantiateInGameObject
                    (
                        Instantiate(liveSprites[0], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), GetPlayerPositionDistanceZ()), transform.rotation),
                        Instantiate(liveSprites[0], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + PlayerPositionDistanceFactorZ)), transform.rotation),
                        Instantiate(liveSprites[1], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + (PlayerPositionDistanceFactorZ * 2))), transform.rotation)
                    );

                    break;

                case 1:

                    InstantiateInGameObject
                    (
                        Instantiate(liveSprites[0], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), GetPlayerPositionDistanceZ()), transform.rotation),
                        Instantiate(liveSprites[1], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + PlayerPositionDistanceFactorZ)), transform.rotation),
                        Instantiate(liveSprites[1], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + (PlayerPositionDistanceFactorZ * 2))), transform.rotation)
                    );

                    break;

                case 0:

                    InstantiateInGameObject
                    (
                        Instantiate(liveSprites[1], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), GetPlayerPositionDistanceZ()), transform.rotation),
                        Instantiate(liveSprites[1], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + PlayerPositionDistanceFactorZ)), transform.rotation),
                        Instantiate(liveSprites[1], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + (PlayerPositionDistanceFactorZ * 2))), transform.rotation)
                    );

                    break;
            }
        }
    }

    #endregion

    #endregion

    #region Return values

    /// <summary>
    /// Instantiate heart vertical value.
    /// </summary>
    /// <returns>Position Y</returns>
    private float GetPlayerPositionDistanceY()
    {
        return (playerAsset.transform.position.y + 0.55f);
    }

    /// <summary>
    /// Instantiate heart horizontal value.
    /// </summary>
    /// <returns>Position Z</returns>
    private float GetPlayerPositionDistanceZ()
    {
        return (playerAsset.transform.position.z - 1.1f);
    }

    /// <summary>
    /// Instantiate heart scale values.
    /// </summary>
    /// <returns>Scale X Y Z</returns>
    private Vector3 GetHeartScaleValues()
    {
        return (new Vector3(0.3f, 0.3f, 0.3f));
    }

    #endregion
}
