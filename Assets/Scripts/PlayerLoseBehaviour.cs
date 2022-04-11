using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLoseBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _failTimer = 0;
    private float _timeInAir = 0;
    [SerializeField]
    private Canvas _text = null;

    // Update is called once per frame
    void Update()
    {
        _timeInAir += Time.deltaTime;

        if(_timeInAir >= _failTimer)
        {
            gameObject.SetActive(false);
            _text.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            QuitGame();
        else if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    [SerializeField]
    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnCollisionStay(Collision collision)
    {
        _timeInAir = 0;
    }
}
