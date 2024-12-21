using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CharacterController barbCharcter;
    [SerializeField] CharacterController magCharcter;
    [SerializeField] Camera mainCamera;

    private void Start()
    {
        //SetAgentsArea();
        SetBarbCharacter();
        SetMagCharacter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetMagCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetBarbCharacter();
        }
    }

    private void SetBarbCharacter()
    {
        magCharcter.Deactivate();
        barbCharcter.SetCamera(mainCamera); 
    }

    private void SetMagCharacter()
    {
        barbCharcter.Deactivate();
        magCharcter.SetCamera(mainCamera); 
    }

    private void SetAgentsArea()
    {
        barbCharcter.MyAgent.SetAreaCost(6, 1);
        magCharcter.MyAgent.SetAreaCost(6, 99);
        print($"Barb {barbCharcter.MyAgent.GetAreaCost(6)}");
        print($"Mage {magCharcter.MyAgent.GetAreaCost(6)}");
    }

}
