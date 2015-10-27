using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateBoxScript : MonoBehaviour
{

    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;
    public int BoxCount = 10;

    private float timeCreateBox;
    private int x = 0;
    private int count;
    private int rand;
    private float speed;
    private float xY;
    private int tmp;

    private GameObject obj;
    private List<GameObject> listbox;
    private GameScript gameScript;

    void Awake()
    {
        gameScript = GameObject.Find("Game").GetComponent<GameScript>();
        InitBoxList();
    }
    public void InitBoxList()
    {
        listbox = new List<GameObject>();
        for (int i = 0; i < BoxCount; i++)
        {
            count = Random.Range(1, 4);
            switch (count)
            {
                case 1:
                    obj = Box1;
                    break;
                case 2:
                    obj = Box2;
                    break;
                case 3:
                    obj = Box3;
                    break;
            }
            GameObject temp = Instantiate(obj);
            temp.name = "Box";
            temp.SetActive(false);
            listbox.Add(temp);
        }
    }

    public IEnumerator CreateBox() 
    {
        while (true)
        {
            int speed = (int)gameScript.speed;

            switch (speed) // для кожної скорості різний розмір ящіка
            {
                case 7:
                    timeCreateBox = Random.Range(0.7f, 1.4f);
                    xY = Random.Range(0.4f, 0.65f);
                    break;
                case 8:
                    timeCreateBox = Random.Range(0.7f, 1.4f);
                    xY = Random.Range(0.4f, 0.65f);
                    break;
                case 9:
                    timeCreateBox = Random.Range(0.73f, 1.2f);
                    xY = Random.Range(0.4f, 0.65f);
                    break;
                case 10:
                    timeCreateBox = Random.Range(0.59f, 1f);
                    xY = Random.Range(0.4f, 0.75f);
                    break;
                case 11:
                    timeCreateBox = Random.Range(0.59f, 0.85f);
                    xY = Random.Range(0.4f, 0.80f);
                    break;
                case 12:
                    timeCreateBox = Random.Range(0.59f, 0.78f);
                    xY = Random.Range(0.5f, 0.87f);
                    break;
                case 13:
                    timeCreateBox = Random.Range(0.59f, 0.78f);
                    xY = Random.Range(0.5f, 0.87f);
                    break;
                case 14:
                    timeCreateBox = Random.Range(0.59f, 0.80f);
                    xY = Random.Range(0.63f, 0.95f);
                    break;
                case 15:
                    timeCreateBox = Random.Range(0.59f, 0.80f);
                    xY = Random.Range(0.60f, 1f);
                    break;
                case 16:
                    timeCreateBox = Random.Range(0.63f, 0.85f);
                    xY = Random.Range(0.70f, 1.1f);
                    break;
                case 17:
                    timeCreateBox = Random.Range(0.65f, 0.85f);
                    xY = Random.Range(0.75f, 1.15f);
                    break;
                case 18:
                    timeCreateBox = Random.Range(0.65f, 0.85f);
                    xY = Random.Range(0.83f, 1.2f);
                    break;
                default:
                    timeCreateBox = Random.Range(0.68f, 0.85f);
                    xY = Random.Range(0.83f, 1.2f);
                    break;
            }

            listbox[x].transform.localScale = new Vector3(xY, xY, -1);
            listbox[x].transform.position = new Vector3(8.514f, -1.998f, 5);
            listbox[x].SetActive(true);

            x++;
            if (x == BoxCount - 1)
            {
                x = 0;
            }

            yield return new WaitForSeconds(timeCreateBox);
        }
    }
}