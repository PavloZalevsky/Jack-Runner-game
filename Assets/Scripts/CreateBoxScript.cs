using UnityEngine;
using System.Collections;
using System.Timers;

public class CreateBoxScript : MonoBehaviour
{

    // Use this for initialization

    public Transform box1;
    public Transform box2;
    public Transform box3;

    private Transform _obj;
    private float _timeCreateBox;

    private int _count;
    private int _rand;
    private float _speed;
    private float _xY;

    private GameScript gameScript;
    private int speed;
    void Awake()
    {
        gameScript = GameObject.Find("Game").GetComponent<GameScript>();
    }
    public IEnumerator CreateBox()
    {
        while (true)
        {
            _count = Random.Range(1, 4);
            switch (_count)
            {
                case 1:
                    _obj = box1;
                    break;
                case 2:
                    _obj = box2;
                    break;
                case 3:
                    _obj = box3;
                    break;
            }

            speed = (int)gameScript.speed;

            switch (speed)
            {
                case 6:
                    _timeCreateBox = Random.Range(0.7f, 1.4f);
                    _xY = Random.Range(0.4f, 0.55f);
                    break;
                case 7:
                    _timeCreateBox = Random.Range(0.7f, 1.4f);
                    _xY = Random.Range(0.4f, 0.55f);
                    break;
                case 8:
                    _timeCreateBox = Random.Range(0.7f, 1.4f);
                    _xY = Random.Range(0.4f, 0.65f);
                    break;
                case 9:
                    _timeCreateBox = Random.Range(0.73f, 1.2f);
                    _xY = Random.Range(0.4f, 0.68f);
                    break;
                case 10:
                    _timeCreateBox = Random.Range(0.59f, 1f);
                    _xY = Random.Range(0.4f, 0.75f);
                    break;
                case 11:
                    _timeCreateBox = Random.Range(0.59f, 0.85f);
                    _xY = Random.Range(0.4f, 0.80f);
                    break;
                case 12:
                    _timeCreateBox = Random.Range(0.59f, 0.78f);
                    _xY = Random.Range(0.5f, 0.87f);
                    break;
                case 13:
                    _timeCreateBox = Random.Range(0.59f, 0.78f);
                    _xY = Random.Range(0.5f, 0.87f);
                    break;
                case 14:
                    _timeCreateBox = Random.Range(0.59f, 0.80f);
                    _xY = Random.Range(0.63f, 0.95f);
                    break;
                case 15:
                    _timeCreateBox = Random.Range(0.59f, 0.80f);
                    _xY = Random.Range(0.60f, 1f);
                    break;
                case 16:
                    _timeCreateBox = Random.Range(0.63f, 0.85f);
                    _xY = Random.Range(0.70f, 1.1f);
                    break;
                case 17:
                    _timeCreateBox = Random.Range(0.65f, 0.85f);
                    _xY = Random.Range(0.75f, 1.15f);
                    break;
                case 18:
                    _timeCreateBox = Random.Range(0.65f, 0.85f);
                    _xY = Random.Range(0.83f, 1.2f);
                    break;
                default:
                    _timeCreateBox = Random.Range(0.68f, 0.85f);
                    _xY = Random.Range(0.83f, 1.2f);
                    break;
            }
            _obj.localScale = new Vector3(_xY, _xY, -1);

            var clone = Instantiate(_obj, new Vector3(8.514f, -1.998f, 5), Quaternion.identity);
            clone.name = "Box";

            yield return new WaitForSeconds(_timeCreateBox);
        }
    }


}
