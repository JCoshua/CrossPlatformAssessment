using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLoseBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _failTimer = 0;
    private float _timeInAir = 0;
    private Vector3 _lastPosition = Vector3.zero;
    private float _moveTimer = 0;

    [SerializeField]
    private Canvas _text = null;

    // Update is called once per frame
    void Update()
    {
        _timeInAir += Time.deltaTime;

        //If the player spends too much time in the air...
        if(_timeInAir >= _failTimer)
        {
            //Show the game over menu
            gameObject.SetActive(false);
            _text.gameObject.SetActive(true);
        }

        //If the player's current position is equal to their last position...
        if (transform.position == _lastPosition)
        {
            //Increase the move timer
            _moveTimer += Time.deltaTime;
        }
        else
            //else reset the move timer
            _moveTimer = 0;

        //If the player stands still to long
        if(_moveTimer > 2)
        {
            //Show the game over menu
            gameObject.SetActive(false);
            _text.gameObject.SetActive(true);
        }

        //Set the player's last position to the player's current position
        _lastPosition = transform.position;

        //If the player hits escape (PC only)
        if (Input.GetKeyDown(KeyCode.Escape))
            QuitGame();

        //If the player hits R (PC Only
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
