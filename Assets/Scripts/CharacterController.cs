using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] NavMeshAgent myAgent;
    [SerializeField] Animator animator;

    private Camera _myCamera;
    private bool _isActive;
    private float _currentSpeed;
    private void Start()
    {
        _currentSpeed = myAgent.speed;
    }

    void Update()
    {
        if (!_isActive)
        {
            MoveAgent();
        }
    }
    public void SetCameraMain()
    {
        if (this.gameObject.activeSelf)
        {
            _myCamera.tag = "MainCamera";
            _myCamera.enabled = true;
        }
        else
        {
            _myCamera.tag = "Untagged";
            _myCamera.enabled = false;
        }
    }

    public void SetCamera(Camera camera)
    {
        if(camera == null) return;

        _myCamera = camera;
        camera.transform.SetParent(cameraTransform);
        camera.transform.position = cameraTransform.position;
        camera.transform.rotation = cameraTransform.rotation;

        _isActive = true;
    }
    public void DisableCamera()
    {
        _myCamera = null;
    }
    public void Deactivate()
    {
        _isActive = false; 
    }
    private void MoveAgent()
    {
        if(_myCamera == null) return;
        if (Input.GetMouseButtonDown(0))
        {
            // Sending a ray from the camera to the floor collider
            Ray myRay = _myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit myHit;

            // Moving to that ray position
            if (Physics.Raycast(myRay, out myHit))
            {
                myAgent.SetDestination(myHit.point);
            }
        }
        animator.SetBool("IsPath", myAgent.hasPath); // Handle Animation
    }

}
