using UnityEngine;

public class Reroad : MonoBehaviour
{
    public Vector3 aimPos;
    public GameObject bullet = null;
    public Vector3 dir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BulletSpawn();
        }
    }
    void BulletSpawn()
    {
        GameObject flame = GameManager.instance.pool.Get(0);
        bullet = GameManager.instance.pool.Get(1);
        flame.transform.position = transform.position;
        //flame.transform.localRotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.transform.position = transform.position;
        //bullet.GetComponent<Bullet>().Init();

        Fire();
        flame.GetComponent<Bullet>().Disapear();
    }   
    void Fire()
    {
        aimPos = GameManager.instance.aim.transform.position;
        dir = aimPos - transform.position;
        dir = dir.normalized;
        //bullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(dir*10);

    }
}
