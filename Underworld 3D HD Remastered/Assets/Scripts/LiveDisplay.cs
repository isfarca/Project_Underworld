using UnityEngine;

public class LiveDisplay : MonoBehaviour
{
    #region Declare variables

    // Value types
    private const float PlayerPositionDistanceFactorZ = 0.05f;

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

    public void SetHearts()
    {
        if (playerScript != null)
        {
            switch (playerScript.Live)
            {
                case 2:

                    Destroy(liveSprites[0]);
                    Destroy(liveSprites[0]);
                    Destroy(liveSprites[0]);

                    InstantiateInGameObject
                    (
                        Instantiate(liveSprites[0], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), GetPlayerPositionDistanceZ()), transform.rotation),
                        Instantiate(liveSprites[0], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + PlayerPositionDistanceFactorZ)), transform.rotation),
                        Instantiate(liveSprites[1], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + (PlayerPositionDistanceFactorZ * 2))), transform.rotation)
                    );

                    break;

                case 1:

                    Destroy(liveSprites[0]);
                    Destroy(liveSprites[0]);
                    Destroy(liveSprites[1]);

                    InstantiateInGameObject
                    (
                        Instantiate(liveSprites[0], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), GetPlayerPositionDistanceZ()), transform.rotation),
                        Instantiate(liveSprites[1], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + PlayerPositionDistanceFactorZ)), transform.rotation),
                        Instantiate(liveSprites[1], new Vector3(playerAsset.transform.position.x, GetPlayerPositionDistanceY(), (GetPlayerPositionDistanceZ() + (PlayerPositionDistanceFactorZ * 2))), transform.rotation)
                    );

                    break;

                case 0:

                    Destroy(liveSprites[0]);
                    Destroy(liveSprites[1]);
                    Destroy(liveSprites[1]);

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

    private float GetPlayerPositionDistanceY()
    {
        return (playerAsset.transform.position.y + 0.55f);
    }

    private float GetPlayerPositionDistanceZ()
    {
        return (playerAsset.transform.position.z - 0.9f);
    }

    private Vector3 GetHeartScaleValues()
    {
        return (new Vector3(0.3f, 0.3f, 0.3f));
    }

    #endregion
}
