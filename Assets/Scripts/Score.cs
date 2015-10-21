using UnityEngine;


public class Score : MonoBehaviour
{
    private int score;
    private int recordScore = 0;

    private UIScript uiScript;


    void Awake()
    {
        uiScript = GameObject.Find("UI").GetComponent<UIScript>();
    }


    void Start()
    {
        score = 0;        
         if (PlayerPrefs.GetInt("rec") != 0)
         {
             recordScore = PlayerPrefs.GetInt("rec");
         }
        uiScript.updateRecord(string.Format("Best {0} Score {1}", recordScore, score), false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Box")
        {
            score++;
            Check();
        }
    }
    
    public void Check()
    {
        if (score > recordScore)
        {
            recordScore = score;
            PlayerPrefs.SetInt("rec", recordScore);
            uiScript.updateRecord(string.Format("Best {0} Score {1}", recordScore, score), true);
        }
        else
        {
            uiScript.updateRecord(string.Format("Best {0} Score {1}", recordScore, score), false);
        }
    }
    public void ResetScore()
    {    
        score = 0;
        uiScript.updateRecord(string.Format("Best {0} Score {1}", recordScore, score), false);
    }
}
