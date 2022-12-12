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

        // Se o usu�rio estiver em cima de uma land;
        if (other.CompareTag("Land"))
        {
            // Debug.Log("O personagem est� em cima de uma land");
            LandController land = other.GetComponent<LandController>();
            SelectLand(land);
            return;
        }

        // Desseleciona o land se o player n�o estiver em cima de nenhuma land;
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

    // Quando o player apertar o bot�o para interagir;
    public void Interact()
    {
        if (selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }

        Debug.Log("N�o est� em nenhuma land!");
    }
}
