using UnityEngine;
using UnityEngine.Events;

public class CameraGun : MonoBehaviour
{
    public event UnityAction<Bullet> OnBulletInstantiated;

    [SerializeField] Bullet bullet;
    [SerializeField] Camera myCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit myHit;

            // Moving to that ray position
            if (Physics.Raycast(myRay, out myHit))
            {
                Bullet instadBullet = Instantiate(bullet, myHit.point, Quaternion.identity);
                OnBulletInstantiated.Invoke(instadBullet);
            }
        }
    }

}
