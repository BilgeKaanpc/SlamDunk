using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("---Level Objects")]
    public GameObject platform;
    public GameObject pota;
    public GameObject growPota;
    public GameObject[] skillPositions;
    [Header("---UI Objects")]
    [SerializeField] private Image[] missionImages;
    [SerializeField] private Sprite missionCompleted;

    [SerializeField] AudioSource[] sounds;
    [SerializeField] GameObject[] effects;
    [SerializeField] private int goalBall;
    int basketCount;
    float touchPosX;
    void Start()
    {
        for (int i = 0; i < goalBall; i++)
        {
            missionImages[i].gameObject.SetActive(true);
        }
        Invoke("CreateSkill",3);
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(platform.transform.position.x > -1.9f)
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

    void CreateSkill()
    {
        int randomIndex = Random.Range(0, skillPositions.Length);
        growPota.transform.position = skillPositions[randomIndex].transform.position;
        growPota.SetActive(true);
    }
    public void GrowPota(Vector3 position)
    {
        sounds[0].Play();
        effects[1].transform.position = position;
        effects[1].SetActive(true);
        pota.transform.localScale = new Vector3(55, 55, 55);
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

        }

        if(basketCount == 1)
        {
            CreateSkill();
        }
    }
    public void Win()
    {
        sounds[2].Play();
    }
    public void GameOver()
    {
        sounds[1].Play();

    }
}
