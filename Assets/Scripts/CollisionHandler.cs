using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
   // [SerializeField] float sceneLoadDelay = 2f;

    GameSceneManager gameSceneManager;

    private void Start() 
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver" /*sceneLoadDelay*/);
    }
}
