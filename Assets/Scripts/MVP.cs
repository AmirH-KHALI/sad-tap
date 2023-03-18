using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class MVP : MonoBehaviour
{
    public GameObject rec;
    public Text High;
    public GameObject re;
    public GameObject board;
    public bool finish;
    public gameMap map;
    public GraphicsMap gm;
    public AudioSource audio;
    public List<Image> images;
    int Score;
    public Text scoreb;
    List<bool> data;
    public float time;
    int highScore;
    float startTime;
    public Text timer;
    string scorePath;
    bool record;
    public int MaxTime = 45;
    private void Awake()
    {
        finish = false;
        map = new gameMap();
        Score = 0;
        scoreb.text = Score.ToString();
        Setup();
        startTime = Time.time;
        scorePath = Application.streamingAssetsPath + "/hs.json";
        record = false;
    }
    private void Update()
    {
        setTime();
        setHighScore();
        getHighScore();
        if (map.count == 0)
        {
            getScore();
            Setup();

        }
        if (time <= 0)
        {
            finish = true;
            re.SetActive(true);
            board.SetActive(false);
            if (record)
            {
                rec.SetActive(true);
            }
        }
    }

    void setTime()
    {
        if (!finish)
        {
            time = MaxTime - (Time.time - startTime);
            timer.text = ((int)time).ToString();
        }
    }


    private void Setup()
    {
        map.initMap();
        data = map.getMap();
        for (int i = 0; i < 25; i++)
        {
            if (!data[i])
            {
                images[i].sprite = gm.sprites[0];
            }
            else
            {
                images[i].sprite = gm.sprites[1];
            }
        }
    }

    public void getScore()
    {
        Score++;
        MaxTime += 1;
        Debug.Log(time.ToString());
        scoreb.text = Score.ToString();

    }

    public void thinkClick(int index)
    {
        if (!finish)
        {
            if (data[index])
            {
                data[index] = false;
                images[index].sprite = gm.sprites[0];
                map.count--;
                audio.Play();

            }
        }
    }

    void getHighScore()
    {
        string Data = File.ReadAllText(scorePath);
        hs sc = JsonUtility.FromJson<hs>(Data);
        High.text = sc.highScore.ToString();
    }

    void setHighScore()
    {
        string Data = File.ReadAllText(scorePath);
        hs sc = JsonUtility.FromJson<hs>(Data);
        int highs = sc.highScore;
        if (Score > highs)
        {

            sc.highScore = Score;
            string newData = JsonUtility.ToJson(sc);
            File.WriteAllText(scorePath, newData);
            record = true;
        }
    }
}

[System.Serializable]
public class hs
{
    public int highScore;
}
