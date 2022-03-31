using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RocksRow : MonoBehaviour
{
    public GameObject[] rocks;
    public RocksRow[] otherRows;
    public bool active;
    public bool forRestart;
    public int activeCount;
    public int correctCounter;
    private int tryCounter;
    private string activeRock;
    public string rightRock;

    void Start()
    {
        activeRock = null;
        active = false;
        forRestart = false;
        activeCount = 0;
        tryCounter = 0;
        correctCounter = 0;

        for (int i = 0; i < rocks.Length; i++)
        {
            rocks[i].GetComponent<TheRock>().row = gameObject.GetComponent<RocksRow>();
        }
    }

    void Update()
    {
        if (tryCounter < 3)
        {
            if (!(activeRock == rightRock) && activeRock != null)
            {
                forRestart = true;
            }

            if (activeCount == 4 && forRestart)
            {
                tryCounter++;
                restart();
            }

            else if (activeRock == rightRock)
            {
                if (correctCounter == 4)
                {
                    SceneManager.LoadScene("SecondLevel");
                }
            }
        }
        else
        {
            SceneManager.LoadScene("FirstLevel");
        }


    }

    IEnumerator wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }


    public void setActiveRock(string id)
    {
        active = true;
        activeRock = id;
        activeCount++;
        if (activeRock == rightRock)
        {
            correctCounter++;
        }
        foreach (RocksRow row in otherRows)
        {
            row.activeCount++;
            row.correctCounter = correctCounter;
        }
    }

    public void restart()
    {
        activeCount = 0;
        correctCounter = 0;
        foreach (GameObject rock in rocks)
        {
            rock.GetComponent<TheRock>().restartRocks();
        }
        foreach (RocksRow row in otherRows)
        {
            if (row.activeCount != 0)
            {
                row.restart();
            }
        }
        wait(5);
    }
}

