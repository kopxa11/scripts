using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public Text text;

    public enum infotype
    {
        speed,
        state
    }
    public infotype type;
    void Awake()
    {   

        text = GetComponent<Text>();
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.instance != null)
        {
            if (type == infotype.speed)
                text.text = string.Format("{0:F}", GameManager.instance.playerMovement.myspeed);
            else
            {
                text.text = GameManager.instance.playerMovement.state.ToString();

            }
        }
        else 
        { 
            text = GetComponent<Text>();

        }

    }
}
