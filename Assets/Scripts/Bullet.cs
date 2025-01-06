using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public event UnityAction<RobotBehaivor> OnCollisionEventAction;


    [SerializeField] float speed = 10f; 
    //[SerializeField] UnityEvent onCollisionEvent;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            Destroy(this.gameObject);
            RobotBehaivor robotCollided = other.GetComponent<RobotBehaivor>();
            OnCollisionEventAction.Invoke(robotCollided);
        }
    }
}
