using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{
    [SerializeField]
    private Canvas _winText;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        //Set the height to the player's y position x 100
        float height = _player.transform.position.y * 100;

        //If the height is below 0, set to 0
        if (height < 0) height = 0;

        //Set the text to display the height
        _text.text = "Height: " + height + "ft";

        //If the player hits the ground
        if (height < 60)
        {
            //Show the win screen
            _winText.gameObject.SetActive(true);
        }
    }
}
