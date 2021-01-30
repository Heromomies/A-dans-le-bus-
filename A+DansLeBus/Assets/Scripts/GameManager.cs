using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cursor = UnityEngine.Cursor;
using Image = UnityEngine.UI.Image;


public class GameManager : MonoBehaviour
{
    public float timerEndLevelSecond;

    public int timerEndLevelMinute;
    public int numbersObjectsToFind;

    private string _txtSecond;

    private bool _playOnce = true;

    public GameObject timerTxt;
    public GameObject panelWin, panelGameOver;

    public List<GameObject> allGameObjects = new List<GameObject>();
    public List<GameObject> objectsToCatch = new List<GameObject>();
    public List<GameObject> objectsCatchByPlayer = new List<GameObject>();

    public List<Transform> bigObjectTransform;
    public List<Transform> spawnPoints;

    public List<Image> imageObjectif;


    #region singleton

    public static GameManager gm;


    private void Awake()
    {
        Init();
        if (gm == null)
        {
            gm = this;
        }
    }

    #endregion

    // Start is called before the first frame update
    void Init()
    {
        timerTxt.transform.DOScale(new Vector3(1.2f, 1.2f, 0), 1).SetLoops(100, LoopType.Yoyo);
        Cursor.visible = false;
        BigObject[] bigObjects;
        bigObjects = FindObjectsOfType<BigObject>();
        foreach (var bigObject in bigObjects)
        {
            bigObjectTransform.Add(bigObject.transform);
        }

        for (int i = 0; i < numbersObjectsToFind; i++)
        {
            int randomObjectIndex = Random.Range(0, allGameObjects.Count);
            objectsToCatch.Add(allGameObjects[randomObjectIndex]);

            imageObjectif[i].sprite = allGameObjects[randomObjectIndex].GetComponent<SpriteRenderer>().sprite;

            if (allGameObjects[randomObjectIndex].GetComponent<PickUpObject>() != null)
            {
                allGameObjects[randomObjectIndex].GetComponent<PickUpObject>().isPickable = true;
            }

            allGameObjects.RemoveAt(randomObjectIndex);
        }

        for (int i = 0; i < objectsToCatch.Count; i++)
        {
            int randomPos = Random.Range(0, spawnPoints.Count);
            int bigObjectOrRandomPos = Random.Range(0, 2);
            if (bigObjectOrRandomPos == 1)
            {
                objectsToCatch[i].transform.position = spawnPoints[randomPos].position;
                spawnPoints.RemoveAt(randomPos);
            }
            else
            {
                objectsToCatch[i].transform.position = bigObjectTransform[randomPos].position;
                bigObjectTransform[randomPos].GetComponent<BigObject>().hasObjectHidden = true;
                bigObjectTransform[randomPos].GetComponent<BigObject>().objectHidden = objectsToCatch[i];
                bigObjectTransform.RemoveAt(randomPos);
            }
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
            panelGameOver.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
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
            mySequence.Append(timerTxt.transform.DORotate(new Vector3(0, 0, 30), .1f));
            mySequence.Append(timerTxt.transform.DORotate(new Vector3(0, 0, -30), 1f).SetLoops(30, LoopType.Yoyo));
            timerTxt.transform.DOScale(new Vector3(1.5f, 1.5f, 1), 1f).SetLoops(30, LoopType.Yoyo);
            timerTxt.transform.GetComponent<TextMeshProUGUI>().DOColor(Color.red, 1).SetLoops(30, LoopType.Yoyo);
        }
    }

    public void CheckIfVictory()
    {
        if (objectsCatchByPlayer.Count == objectsToCatch.Count)
        {
            //TODO C'est la win
            Debug.Log("VICTOIRE");
            Time.timeScale = 0f;
            panelWin.SetActive(true);
            Cursor.visible = true;
        }

        for (int i = 0; i < imageObjectif.Count; i++)
        {
            for (int j = 0; j < objectsCatchByPlayer.Count; j++)
            {
                if (objectsCatchByPlayer[j].GetComponent<SpriteRenderer>().sprite == imageObjectif[i].sprite)
                {
                    imageObjectif[i].sprite = null;
                }
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}