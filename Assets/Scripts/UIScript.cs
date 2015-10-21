using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {


    public Button Run;
    public Button Exit;
    public Button OnMusic;
    public Button OffMusic;
    public Image Touch;
    public Text ScoreText;
    public Text NewRecordText;
 

    private GameScript gameScript;

    private bool music = true;
    bool _flag = false;

 
    void Awake()
    {
        gameScript = GameObject.Find("Game").GetComponent<GameScript>();
    }

    void Start()
    {
        Touch.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        OnMusic.GetComponentInChildren<Image>().enabled = false;
        OnMusic.enabled = false;
    }

    public void updateRecord(string score , bool newRecord)
    {
        ScoreText.text = score;
        if (newRecord)
        {
            NewRecordText.text = "New";
        }
        else
        {
            NewRecordText.text = "";
        }
    }

    public void clickButtonRun()
    {
        hideButton();
        Touch.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
        _flag = true;
    }

    public void clickButtonExit()
    {
        Application.Quit();
    }

    public void clickButtonOffMusic()
    {
        gameScript.OffMusic();
        OnMusic.GetComponentInChildren<Image>().enabled = true;
        OnMusic.enabled = true;
        OffMusic.GetComponentInChildren<Image>().enabled = false;
        OffMusic.enabled = false;
        music = false;
    }

    public void clickButtonOnMusic()
    {
        gameScript.OnMusic();
        OnMusic.GetComponentInChildren<Image>().enabled = false;
        OnMusic.enabled = false;
        OffMusic.GetComponentInChildren<Image>().enabled = true;
        OffMusic.enabled = true;
        music = true;
    }

    void Update()
    {
        if (_flag)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == 0  && touch.phase == TouchPhase.Began)
                {
                    Touch.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
                    _flag = false;
                    gameScript.StartGame();
                }
            }

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                Touch.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
                 _flag = false;
                gameScript.StartGame();
            }

        }
    }


    private void hideButton()
    {
        Run.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        Run.enabled = false;
        Exit.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        Exit.enabled = false;
        OnMusic.GetComponentInChildren<Image>().enabled = false;
        OnMusic.enabled = false;
        OffMusic.GetComponentInChildren<Image>().enabled = false;
        OffMusic.enabled = false;
    }
    public void showButton()
    {
        Run.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
        Run.enabled = true;
        Exit.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
        Exit.enabled = true;

        if (!music)
        {
            OnMusic.GetComponentInChildren<Image>().enabled = true;
            OnMusic.enabled = true;
        }
        else
        {
            OffMusic.GetComponentInChildren<Image>().enabled = true;
            OffMusic.enabled = true;
        }
    }
}
