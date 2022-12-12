using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    LandController selectedLand = null;

    void Start()
    {

    }

    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1))
        {
            OnInteractableHit(hit);
        }
    }

    // Quando o Interection toca algo;
    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        // Se o usuário estiver em cima de uma land;
        if (other.CompareTag("Land"))
        {
            // Debug.Log("O personagem está em cima de uma land");
            LandController land = other.GetComponent<LandController>();
            SelectLand(land);
            return;
        }

        // Desseleciona o land se o player não estiver em cima de nenhuma land;
        if (selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }
    }

    // Processo de selecionar uma land;
    void SelectLand(LandController land)
    {
        if (selectedLand != null)
        {
            selectedLand.Select(false);
        }

        selectedLand = land;
        land.Select(true);
    }

    // Quando o player apertar o botão para interagir;
    public void Interact()
    {
        if (selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }

        Debug.Log("Não está em nenhuma land!");
    }
}
