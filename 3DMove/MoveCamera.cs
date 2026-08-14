using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameramPosition;
    //public Transform FirstPos;
    public void Awake()
    {
        //FirstPos = GetComponentInParent<Transform>();
        
    }
    void Start()
    {
        //transform.position =  FirstPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameramPosition.position;
    }
}
