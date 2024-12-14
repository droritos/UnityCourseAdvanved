using UnityEngine;
using UnityEngine.AI;

public class MouseHandller : MonoBehaviour
{
    [SerializeField] Camera myCamera;
    [SerializeField] NavMeshAgent myAgent;

    private float _currentSpeed;
    private void Start()
    {
        _currentSpeed = myAgent.speed;
    }

    void Update()
    {
        MoveAgent();
    }

    private void MoveAgent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Sending a ray from the camera to the floor collider
            Ray myRay = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit myHit;

            // Moving to that ray position
            if (Physics.Raycast(myRay, out myHit))
            {
                myAgent.SetDestination(myHit.point);
                print($"Hit - {myHit.point}");
            }
        }
    }
    bool IsOnNavMeshLink(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 1.0f, NavMesh.AllAreas))
        {
            print(hit.mask);
            return hit.mask == NavMesh.GetAreaFromName("NavMeshLink");
        }
        return false;
    }

}
