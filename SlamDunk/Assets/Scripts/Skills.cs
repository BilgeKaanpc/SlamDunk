using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skills : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private int startTime;
    [SerializeField] private GameManager _GameManager;
    IEnumerator Start()
    {
        time.text = startTime.ToString();
        while (true)
        {
            yield return new WaitForSeconds(1);
            startTime--;
            time.text = startTime.ToString();
            if (startTime == 0)
            {
                gameObject.SetActive(false);
                break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _GameManager.GrowPota(transform.position);
        gameObject.SetActive(false);
    }
}
