using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSCene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(1);
    }
}
