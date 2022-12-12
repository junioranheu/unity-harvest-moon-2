using UnityEngine;

public class LandController : MonoBehaviour
{
    public enum LandStatus
    {
        Padrao, Soil, Mud
    }

    public LandStatus landStatus;
    public Material padraoMat, soilMat, mudMat;
    new Renderer renderer;
    public GameObject select;

    void Start()
    {
        renderer = GetComponent<Renderer>();

        // Seleciona o "LandStatus.Padrao" por padrão;
        SwitchLandStatus(LandStatus.Padrao);

        // Desseleciona por padrão;
        Select(false);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;
        Material materialToSwitch = padraoMat;

        switch (statusToSwitch)
        {
            case LandStatus.Padrao:
                materialToSwitch = padraoMat;
                break;
            case LandStatus.Soil:
                materialToSwitch = soilMat;
                break;
            case LandStatus.Mud:
                materialToSwitch = mudMat;
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
        //Interaction 
        SwitchLandStatus(LandStatus.Soil);
    }
}
