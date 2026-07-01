using UnityEditor.EditorTools;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PoolManager pool;
    public Player player;
    public GameObject aim;

    public static GameManager instance = null;
    //public CinemachineCamera cam;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
