using UnityEngine;

public class LandController : MonoBehaviour
{
    public enum LandStatus
    {
        Dirt, Plant, Water
    }

    public LandStatus landStatus;
    public Material dirtMat, plantMat, waterMat;
    new Renderer renderer;
    public GameObject select;

    void Start()
    {
        renderer = GetComponent<Renderer>();

        // Seleciona o "LandStatus.Dirt" por padrão;
        SwitchLandStatus(LandStatus.Dirt);

        // Desseleciona por padrão;
        Select(false);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;
        Material materialToSwitch = dirtMat;

        switch (statusToSwitch)
        {
            case LandStatus.Dirt:
                materialToSwitch = dirtMat;
                break;
            case LandStatus.Plant:
                materialToSwitch = plantMat;
                break;
            case LandStatus.Water:
                materialToSwitch = waterMat;
                break;
            default:
                break;
        }

        // Aplicar as alterações no renderer;
        renderer.material = materialToSwitch;
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    public void Interact()
    {
        // Interação; 
        SwitchLandStatus(LandStatus.Plant);
    }
}
