using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSquare : MonoBehaviour
{

    [SerializeField] AudioClip blockBreakClip;
    Level level;
    GameStatus gameStatus;
    [SerializeField] GameObject blockSparkles;
    int hitTimes;
    [SerializeField] Sprite[] blockBreakSprite;
    [SerializeField] GameObject []  specPow;
     GameObject  spcPow;

    
    
    

    private void Start()
    {
        
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
        
    }


    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShowHitSprite();

    }
    void DestroyForNewLevel()
    {
        AudioSource.PlayClipAtPoint(blockBreakClip, Camera.main.transform.position);
        Destroy(gameObject);
        level.DestroyBlocks();
        if (tag == "Breakable")
        {
            gameStatus.AddToScore15();
        }
        if(tag == "2Breakable")
        {
            gameStatus.AddToScore30();

        }
        if (tag == "3Breakable")
        {
            gameStatus.AddToScore45();

        }

        TriggerBlockSparkles();
        SpecPowInstantiate();
        
    }


    private void TriggerBlockSparkles()
    {
        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 0.5f);
    }

    private void ShowHitSprite()
    {
        if (tag == "Breakable")
        {
            DestroyForNewLevel();
        }

        if (tag == "2Breakable")
        {
            hitTimes++;
            if (hitTimes == 2)
            {
                DestroyForNewLevel();
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = blockBreakSprite[0];
            }
        }

        if (tag == "3Breakable")
        {
            hitTimes++;
            if (hitTimes == 3)
            {
                DestroyForNewLevel();
            }
            if (hitTimes == 1)
            {
                GetComponent<SpriteRenderer>().sprite = blockBreakSprite[0];
            }
            if (hitTimes == 2)
            {
                GetComponent<SpriteRenderer>().sprite = blockBreakSprite[1];
            }
        }

    }

    public void SpecPowInstantiate()
    {
        int randomNum = UnityEngine.Random.Range(10, 11  );
        if(randomNum == 10)
        {
            spcPow = Instantiate(specPow[Random.Range(0, specPow.Length)] , transform.position, transform.rotation) ;
            Destroy(spcPow, 5f);
        }
        

    }

    









}
