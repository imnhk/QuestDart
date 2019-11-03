using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public Transform center;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        Physics.gravity = new Vector3(0, -5.0F, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
