using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StoryGoal : MonoBehaviour
{
     [SerializeField] Color defaultColor = Color.red;
    [SerializeField] Color unlockColor = Color.blue;
    [SerializeField] float levelLoadDelay = 1f;
    SpriteRenderer spriteRenderer;
    bool isUnlocked;
    
    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
    }

    void Update()
    {       
        isUnlocked = true;
        spriteRenderer.color = unlockColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(isUnlocked)
        {         
            //Load next level
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }

}
