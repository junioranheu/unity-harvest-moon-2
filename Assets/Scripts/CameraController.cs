using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerPos;
    private readonly float offsetZ = 5f;
    private readonly float smoothing = 1f;

    void Start()
    {
        // Encontrar o game object do personagem na cena e tranformá-lo em um componente;
        playerPos = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = new(playerPos.position.x, transform.position.y, (playerPos.position.z - offsetZ));
        transform.position = Vector3.Lerp(transform.position, targetPosition, (smoothing * Time.deltaTime));
    }
}
