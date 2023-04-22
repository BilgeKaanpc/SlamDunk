using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("basket"))
        {
            _GameManager.Basket();
        }
        else if (other.CompareTag("gameOver"))
        {
            _GameManager.GameOver();
        }
    }
}
