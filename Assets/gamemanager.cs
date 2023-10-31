using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    [Header("Level Stats")]
    public int level = 1;
    public int nyawa = 3;

    [Header("Item Drops")]
    public List<GameObject> itemDropsLvl1;
    public List<GameObject> itemDropsLvl2;
    public List<GameObject> itemDropsLvl3;

    [Header("Level Question Field")]
    public string[] fieldQuestionLvl1;
    public string[] fieldQuestionLvl2;
    public string[] fieldQuestionLvl3;

    [Header("Level Answer Field")]
    public string[] fieldAnswerLvl1;
    public string[] fieldAnswerLvl2;
    public string[] fieldAnswerLvl3;

    [Header("UI")]
    public GameObject UIResult;
    public TextMeshProUGUI textResult;
    public TextMeshProUGUI textKesempatan;
    public GameObject UIGameOver;
    public GameObject[] itemsLvl1;
    public GameObject[] itemsLvl2;
    public GameObject[] itemsLvl3;

    [Header("List Level")]
    public List<GameObject> LevelGameObject;

    public void check()
    {
        switch (level)
        {
            case 1:
                if (fieldQuestionLvl1[0] == fieldAnswerLvl1[0] && fieldQuestionLvl1[1] == fieldAnswerLvl1[1] && fieldQuestionLvl1[2] == fieldAnswerLvl1[2] && fieldQuestionLvl1[3] == fieldAnswerLvl1[3])
                {
                    UIResult.SetActive(true);
                    textResult.text = "Correct!";
                    StartCoroutine(LevelCorrect());
                }
                else
                {
                    UIResult.SetActive(true);
                    textResult.text = "Incorrect!";
                    StartCoroutine(LevelIncorrect());
                }
                break;
            case 2:
                if (fieldQuestionLvl2[0] == fieldAnswerLvl2[0] && fieldQuestionLvl2[1] == fieldAnswerLvl2[1] && fieldQuestionLvl2[2] == fieldAnswerLvl2[2])
                {
                    UIResult.SetActive(true);
                    textResult.text = "Correct!";
                    StartCoroutine(LevelCorrect());
                }
                else
                {
                    UIResult.SetActive(true);
                    textResult.text = "Incorrect!";
                    StartCoroutine(LevelIncorrect());
                }
                break;
            case 3:
                if (fieldQuestionLvl3[0] == fieldAnswerLvl3[0] && fieldQuestionLvl3[1] == fieldAnswerLvl3[1] && fieldQuestionLvl3[2] == fieldAnswerLvl3[2] && fieldQuestionLvl3[3] == fieldAnswerLvl3[3] && fieldQuestionLvl3[4] == fieldAnswerLvl3[4])
                {
                    UIResult.SetActive(true);
                    textResult.text = "Correct!";
                    StartCoroutine(LevelCorrect());
                }
                else
                {
                    UIResult.SetActive(true);
                    textResult.text = "Incorrect!";
                    StartCoroutine(LevelIncorrect());
                }
                break;
            default:
                break;
        }
    }

    IEnumerator LevelCorrect()
    {
        yield return new WaitForSeconds(2.0f);

        level += 1;
        UIResult.SetActive(false);

        switch (level)
        {
            case 2:
                LevelGameObject[0].SetActive(false);
                LevelGameObject[1].SetActive(true);
                break;
            case 3:
                LevelGameObject[1].SetActive(false);
                LevelGameObject[2].SetActive(true);
                break;
            default:
                break;
        }
    }

    IEnumerator LevelIncorrect()
    {
        yield return new WaitForSeconds(2.0f);
        nyawa -= 1;
        textKesempatan.text = "Kesempatan : " + nyawa + "x";
        UIResult.SetActive(false);

        if (nyawa == 0)
        {
            UIGameOver.SetActive(true);
        }
        else
        {
            resetAnswer();
        }
    }

    public void resetAnswer()
    {
        switch (level)
        {
            case 1:
                for (int i = 0; i < fieldAnswerLvl1.Length; i++)
                {
                    fieldAnswerLvl1[i] = "";
                    itemsLvl1[i].transform.localPosition = itemsLvl1[i].GetComponent<draganddrop>().itemPos;
                    itemsLvl1[i].GetComponent<draganddrop>().isPlaced = false;
                }
                break;
            case 2:
                for (int i = 0; i < fieldAnswerLvl2.Length; i++)
                {
                    fieldAnswerLvl1[i] = "";
                    itemsLvl2[i].transform.localPosition = itemsLvl2[i].GetComponent<draganddrop>().itemPos;
                    itemsLvl2[i].GetComponent<draganddrop>().isPlaced = false;
                }
                break;
            case 3:
                for (int i = 0; i < fieldAnswerLvl3.Length; i++)
                {
                    fieldAnswerLvl1[i] = "";
                    itemsLvl3[i].transform.localPosition = itemsLvl3[i].GetComponent<draganddrop>().itemPos;
                    itemsLvl3[i].GetComponent<draganddrop>().isPlaced = false;
                }
                break;
            default:
                break;
        }
    }

    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
