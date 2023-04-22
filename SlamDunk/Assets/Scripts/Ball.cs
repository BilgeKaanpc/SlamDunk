using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("basket"))
        {
            _GameManager.Basket(transform.position);
        }
        else if (other.CompareTag("gameOver"))
        {
            _GameManager.GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        sound.Play();
    }
}
