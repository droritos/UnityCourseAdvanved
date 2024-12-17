using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CharacterController barbCharcter;
    [SerializeField] CharacterController magCharcter;

    private void Start()
    {
        SetBarbCharacter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetBarbCharacter();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetMagCharacter();
        }

    }

    private void SetBarbCharacter()
    {
        barbCharcter.SetCameraMain();
        magCharcter.gameObject.SetActive(false);

        barbCharcter.gameObject.SetActive(true);
    }

    private void SetMagCharacter()
    {
        magCharcter.SetCameraMain();
        barbCharcter.gameObject.SetActive(false);

        magCharcter.gameObject.SetActive(true);
    }

}
