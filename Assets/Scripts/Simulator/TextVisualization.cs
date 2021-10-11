using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextVisualization : MonoBehaviour
{
    GameController gameController;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("_Manager").GetComponent<GameController>();
    }

    public void TextUpdate(string info)
    {
        text = this.GetComponent<Text>();
        text.text = info;
    }

    public void TextUpdate(string current, string max)
    {
        text = this.GetComponent<Text>();
        text.text = current + " / "+ max;
    }

}
