using System;
using TMPro;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //made a canvas and TMP to ddisplay for player.
    private int score = 0;
    public TMP_Text scoreText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            //followed as done in 3d but unsure why it not work on 2d, is it cuz i did it as a static object? 
            //withouth the score it was working fine, object got removed. also idk how to get the console tab back.
            AddScore(1);
            Destroy(other.gameObject);
            Debug.Log("Item collected");
        }
    }
//trying to get a point system
    private void AddScore(int points)
    {
        score = score + points;
        scoreText.text = $"<b>Score: </b>{score}";
    }
}
