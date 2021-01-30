using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public float timerEndLevelSecond;
    
    public int timerEndLevelMinute;
    public int numbersObjectsToFind;

    private string _txtSecond;
    
    public GameObject timerTxt;
    
    public List<GameObject> allGameObjects = new List<GameObject>();
    public List<GameObject> objectsToCatch = new List<GameObject>();
    public List<GameObject> objectsCatchByPlayer = new List<GameObject>();
    public List<Transform> spawnPoints;

    private bool _playOnce = true;

    #region singleton

    public static GameManager gm;


    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        timerTxt.transform.DOScale(new Vector3(1.2f, 1.2f, 0), 1).SetLoops(60, LoopType.Yoyo);
        for (int i = 0; i < numbersObjectsToFind; i++)
        {
            int randomObjectIndex = Random.Range(0, allGameObjects.Count);
            objectsToCatch.Add(allGameObjects[randomObjectIndex]);
            if (allGameObjects[randomObjectIndex].GetComponent<PickUpObject>() != null)
            {
                allGameObjects[randomObjectIndex].GetComponent<PickUpObject>().isPickable = true;
            }
            allGameObjects.RemoveAt(randomObjectIndex);
        }

        for (int i = 0; i < objectsToCatch.Count; i++)
        {
            int randomPos = Random.Range(0, spawnPoints.Count);
            objectsToCatch[i].transform.position = spawnPoints[randomPos].position;
            spawnPoints.RemoveAt(randomPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerEndLevelSecond -= Time.deltaTime;
        timerTxt.GetComponent<TextMeshProUGUI>().text = timerEndLevelMinute + " : " + _txtSecond;
        if (timerEndLevelSecond <= 0 && timerEndLevelMinute <= 0)
        {
            timerEndLevelSecond = 0;
            //TODO le game over
            Debug.Log("GAME OVER");
        }
        else if (timerEndLevelSecond <= 0 && timerEndLevelMinute > 0)
        {
            timerEndLevelMinute--;
            timerEndLevelSecond = 59;
        }

        if (timerEndLevelSecond <= 9.5)
        {
            _txtSecond = "0" + timerEndLevelSecond.ToString("F0");
        }
        else
        {
            _txtSecond = timerEndLevelSecond.ToString("F0");
        }

        if (timerEndLevelMinute == 0 && timerEndLevelSecond <= 30 && _playOnce)
        {
            _playOnce = false;
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(timerTxt.transform.DORotate(new Vector3(0, 0,30),.1f));
            mySequence.Append(timerTxt.transform.DORotate(new Vector3(0, 0, -30), 1f).SetLoops(30, LoopType.Yoyo));
            timerTxt.transform.DOScale(new Vector3(1.5f,1.5f,1),1f ).SetLoops(30, LoopType.Yoyo);
            timerTxt.transform.GetComponent<TextMeshProUGUI>().DOColor(Color.red, 1).SetLoops(30, LoopType.Yoyo);
        }
    }

    public void CheckIfVictory()
    {
        if (objectsCatchByPlayer.Count == objectsToCatch.Count)
        {
            //TODO C'est la win
            Debug.Log("VICTOIRE");
        }
    }
}