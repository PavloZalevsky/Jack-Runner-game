using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

    public Transform Jeck;

    public float speed;

    private CreateBoxScript createBoxScript;
    private UIScript uiScript;
    private Score score;
    private ScrollingScript scrollingScript;
    private AdsScript adsScript;

    private GameObject road;
    private GameObject road1;
    private int dieJuck = 0;

    private float time;
    

    void Awake()
    {
        createBoxScript = GetComponent<CreateBoxScript>();
        uiScript = GameObject.Find("UI").GetComponent<UIScript>();
        score = GameObject.Find("Score").GetComponent<Score>();
        scrollingScript = GameObject.Find("2 - Middleground").GetComponent<ScrollingScript>();
        adsScript = GetComponent<AdsScript>();

        road = GameObject.Find("road");
        road1 = GameObject.Find("road1");
    }

    void Start()
    {     
        InitGame();    
    }

    public void StartGame()
    {
        createBoxScript.StartCoroutine("CreateBox");
        StartCoroutine("IncreasingSpeed");
        score.ResetScore();
    }
    void Update()
    {
        speed = scrollingScript.speed.x;
    }
    public void InitGame()
    {
        var clone = Instantiate(Jeck, new Vector3(-1.8f, -2.790582f, 0), Quaternion.identity);
        clone.name = "Juck";
    }

    public void StopCreateBox()
    {
        createBoxScript.StopCoroutine("CreateBox");
    }

    public void DieJeck() // delete Jeck 
    {
        dieJuck ++;
        CheckAdsInterstitialAds();
        StopCoroutine("IncreasingSpeed");

       uiScript.showButton();

        scrollingScript.speed.x = 6;
        Destroy(GameObject.Find("Juck").gameObject);
        DeleteChildObject();

        InitGame();
    }

    void CheckAdsInterstitialAds()
    {
        if(dieJuck >= adsScript.FrequencyDisplayAds)
        {
            bool show = adsScript.ShowInterstitial();
            if (show)
            {
                dieJuck = 0;
            }
        }
    }

    public IEnumerator IncreasingSpeed()
    {
        while (speed < 19)
        {
            time = Random.Range(8.0f,16.1f);
            scrollingScript.speed.x += 1;
            speed = scrollingScript.speed.x;
            yield return new WaitForSeconds(time);  
        }
    }

    public void OffMusic()
    {
        GetComponent<AudioSource>().enabled = false;
    }
    public void OnMusic()
    {
        GetComponent<AudioSource>().enabled = true;
    }

    private void DeleteChildObject() // delete box on road
    {
        if (road.transform.childCount != 0)
        {
            for (int i = 0; i < road.transform.childCount; i++)
            {
                Destroy(road.transform.GetChild(i).gameObject);
            }
        }
        if (road1.transform.childCount != 0)
        {
            for (int i = 0; i < road1.transform.childCount; i++)
            {
                Destroy(road1.transform.GetChild(i).gameObject);
            }
        }
    }

}
