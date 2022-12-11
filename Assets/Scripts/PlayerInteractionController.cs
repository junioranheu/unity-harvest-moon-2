using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    PlayerController playerController;

    void Start()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            OnInteractableHit(hit);
        }
    }

    void OnInteractableHit(RaycastHit hit)
    {
        Debug.Log(hit);
    }
}
