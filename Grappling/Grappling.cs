using UnityEngine;

public class Grappling : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;
    public Vector2 mousedir;

    public bool isHookActive;
    public bool isLineMax;
    public bool isAttach;
    void Start()
    {
        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;
        isAttach = false;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);

        if (Input.GetKeyDown(KeyCode.E) && !isHookActive)
        {   
            
            hook.position = transform.position;
            mousedir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            isHookActive = true;
            isLineMax = false;
            hook.gameObject.SetActive(true);
        }

        if (isHookActive && !isLineMax)  //날라가는 데 아직 다 안감
        {
            hook.Translate(mousedir.normalized * 15f * Time.deltaTime);
            if(Vector2.Distance(transform.position, hook.position) > 3f)
            {
                isLineMax = true;
            }
        }
        else if(isHookActive && isLineMax&& !isAttach)  //날라갔고 줄도 다 펴짐 다만 아직 안붙음

        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 15f);
            //hook.position = Vector2.MoveTowards(transform.position, hook.position, Time.deltaTime * 15f);

            if (Vector2.Distance(transform.position, hook.position) < 0.1f) //다 돌아오면 사라지는
            {
                isHookActive = false;
                isLineMax = false;
                hook.gameObject.SetActive(false);
            }
        }
        else if (isAttach)
        {   
            if (Input.GetKeyDown(KeyCode.E))
            {
                isAttach = false;
                isHookActive = false;
                isLineMax = false;
                hook.GetComponent<DistanceJoint2D>().enabled = false;
                hook.gameObject.SetActive(false);
            }
        }


    }
}
