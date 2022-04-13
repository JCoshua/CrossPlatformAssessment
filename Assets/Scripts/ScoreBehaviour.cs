using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        float height = _player.transform.position.y * 100;
        if (height < 0) height = 0;
        _text.text = "Height: " + height + "ft";
    }
}
