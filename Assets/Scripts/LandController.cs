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

    void Start()
    {
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(LandStatus.Padrao);
    }

    void Update()
    {

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
}
