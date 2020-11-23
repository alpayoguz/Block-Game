using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
   [Range(0.5f, 10f)] [SerializeField] float gametime = 1;
    [SerializeField] float pointsPerBlockBreak = 15;
    [SerializeField] float userScore = 0;
    [SerializeField] TextMeshProUGUI scoreTextMesh;
    [SerializeField] bool autoPlayEnabled;
    


    private void Awake()
    {
        int gameStatusNumber = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusNumber > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    void Start()
    {
        scoreTextMesh.text = userScore.ToString();
        


    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gametime;
        
        



    }

    public void AddToScore15()
    {
        
        userScore = userScore + pointsPerBlockBreak;
        scoreTextMesh.text = userScore.ToString();
    }

    public void AddToScore30()
    {

        userScore = userScore + pointsPerBlockBreak + 15;
        scoreTextMesh.text = userScore.ToString();
    }

    public void AddToScore45()
    {

        userScore = userScore + pointsPerBlockBreak + 30;
        scoreTextMesh.text = userScore.ToString();
    }

    public void Hallelujah()
    {
        Destroy(gameObject);
    }

    public bool AutoPlayEnabled()
    {
        return autoPlayEnabled;
    }
}
