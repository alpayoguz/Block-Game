using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Level : MonoBehaviour
{
    LoadScene loadScene;

    

    [SerializeField] int blockNum = 0;


    private void Start()
    {
        loadScene = FindObjectOfType<LoadScene>();
        
        
    }
    public void CountBreakableBlocks()
    {
        blockNum++;
    }

    

    public void  DestroyBlocks()
    {

        blockNum--;
        
        if(blockNum <= 0)
        {

            loadScene.LoadNextScene();

        }

    }

    
}
