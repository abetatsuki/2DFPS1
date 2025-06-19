
using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;

    public int inspectorscore;
    public static int score; //これでエネミーで使える
   





    // Start is called before the first frame update
    void Start()
    {

        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        score = inspectorscore;
    }


    // Update is called once per frame
    void Update()
    {
        

        textMeshProUGUI.text = ("Score") + score;
        
    }
}

 