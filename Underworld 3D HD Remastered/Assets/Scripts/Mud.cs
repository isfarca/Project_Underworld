using UnityEngine;

public class Mud : MonoBehaviour
{
    #region Declare variables

    // Value types
    private bool isMud = false;

    // Reference types
    private GameObject player;

    #endregion

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null && isMud)
        {
            CharacterController controller = GetComponent<CharacterController>();
            Vector3 horizontalVelocity = controller.velocity;

            horizontalVelocity = new Vector3(controller.velocity.x, controller.velocity.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isMud = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isMud = false;
    }
}
