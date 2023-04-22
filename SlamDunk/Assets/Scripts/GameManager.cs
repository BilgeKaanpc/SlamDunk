using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject platform;
    public GameObject pota;
    [SerializeField] private Image[] missionImages;
    [SerializeField] private Sprite missionCompleted;
    [SerializeField] private int goalBall;
    int basketCount;
    void Start()
    {
        for (int i = 0; i < goalBall; i++)
        {
            missionImages[i].gameObject.SetActive(true);
        }
    }

    void Update()
    {
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

    public void GrowPota()
    {

    }
    public void Basket()
    {
        basketCount++;
        missionImages[basketCount - 1].sprite = missionCompleted;
        if(basketCount == goalBall)
        {

        }
    }
    public void GameOver()
    {

    }
}
