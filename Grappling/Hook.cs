using UnityEngine;

public class Hook : MonoBehaviour
{   

    public Grappling grappling;
    public DistanceJoint2D distanceJoint;
    public bool hookmode;
    void Awake()
    {
        grappling = GameManager.Instance.player.GetComponent<Grappling>();
        hookmode = GameManager.Instance.player.GetComponent<Player1>().Hookmode;
        distanceJoint = GameManager.Instance.distanceJoint.GetComponent<DistanceJoint2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if (hookmode)
        {
            grappling.isAttach = true;
            distanceJoint.enabled = true;
            Debug.Log("Hook Triggered");
        }
        else 
        {
            if (collision.CompareTag("Ring"))
            {
                grappling.isAttach = true;
                grappling.isLineMax = true;
                distanceJoint.enabled = true;
            }
        }
        
    }
}
