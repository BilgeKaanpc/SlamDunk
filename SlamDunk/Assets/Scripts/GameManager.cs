using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("---Level Objects")]
    public GameObject platform;
    public GameObject[] potas;
    public GameObject growPota;
    public GameObject[] skillPositions;
    [Header("---UI Objects")]
    [SerializeField] private Image[] missionImages;
    [SerializeField] private Sprite missionCompleted;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    [SerializeField] AudioSource[] sounds;
    [SerializeField] GameObject[] effects;
    [SerializeField] public int goalBall;
    public int basketCount;
    float touchPosX;
    void Start()
    {
        Time.timeScale = 1;
        for (int i = 0; i < goalBall; i++)
        {
            missionImages[i].gameObject.SetActive(true);
        }
        InvokeRepeating("CreateSkill", 20,30);
    }

    void Update()
    {
        /* For Mobile Devices
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,0));

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchPosX = touchPosition.x - platform.transform.position.x;
                    break;
                case TouchPhase.Moved:
                    if(touchPosition.x - touchPosX > -1.9f && touchPosition.x - touchPosX < 1.9f)
                    {
                        platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(touchPosition.x - touchPosX, platform.transform.position.y, platform.transform.position.z), 5f);
                    }
                    break;

            }
        }
        */
        if(Time.timeScale != 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (platform.transform.position.x > -1.9f)
                {
                    platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x - .3f, platform.transform.position.y, platform.transform.position.z), .05f);
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (platform.transform.position.x < 1.9f)
                {
                    platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x + .3f, platform.transform.position.y, platform.transform.position.z), .05f);
                }
            }
        }
    }

    void CreateSkill()
    {
        if (potas[0].transform.localScale.x != 55 && basketCount != goalBall)
        {
            int randomIndex = Random.Range(0, skillPositions.Length);
            growPota.transform.position = skillPositions[randomIndex].transform.position;
            growPota.SetActive(true);
        }
    }
    public void GrowPota(Vector3 position)
    {
        sounds[0].Play();
        effects[1].transform.position = position;
        effects[1].SetActive(true);
        foreach (var item in potas)
        {
            item.transform.localScale = new Vector3(55, 55, 55);
        }
    }
    public void Basket(Vector3 position)
    {
        sounds[3].Play();
        basketCount++;
        missionImages[basketCount - 1].sprite = missionCompleted;
        effects[0].transform.position = position;
        effects[0].SetActive(true);
        if (basketCount == goalBall)
        {
            Win();
        }

        if(basketCount == 1)
        {
            CreateSkill();
        }
    }
    public void Win()
    {
        winPanel.SetActive(true);
        sounds[2].Play();
        StartCoroutine(stopTime());
    }
    public void GameOver()
    {
        losePanel.SetActive(true);
        sounds[1].Play();
        StartCoroutine(stopTime());

    }
    IEnumerator stopTime()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0;

    }
    public void Buttons(bool next)
    {
        if (next)
        {
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
