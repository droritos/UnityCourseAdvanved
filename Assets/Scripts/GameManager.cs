using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public event UnityAction<int> OnCounterChanged;

    [SerializeField] CameraGun cameraGun;
    [SerializeField] UIManager uiManager;

    private int robotDieCounter = 0;
    void Start()
    {
        cameraGun.OnBulletInstantiated += BulletInstantiatedHandler;
        //uiManager.OnCounterAdded += UpdatedCounter;
        //uiManager.OnCounterAdded += UpdateUIManager;
    }

    private void BulletInstantiatedHandler(Bullet bullet)
    {
        bullet.OnCollisionEventAction += BulletHitHandle;
    }

    private void BulletHitHandle(RobotBehaivor robotBehaivor)
    {
        robotBehaivor.Die();
        UpScaleCounter();
    }

    private void UpScaleCounter()
    {
        robotDieCounter++;
        OnCounterChanged.Invoke(robotDieCounter);
    }
}
