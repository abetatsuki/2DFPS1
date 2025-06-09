
using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;

    public int inspectorscore;
    public static int score;
   





    // Start is called before the first frame update
    void Start()
    {

        textMeshProUGUI = GetComponent<TextMeshProUGUI>();

    }


    // Update is called once per frame
    void Update()
    {
        score=inspectorscore;

        textMeshProUGUI.text = ("Score") + score;
    }
}

 