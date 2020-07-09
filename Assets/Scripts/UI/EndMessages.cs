using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMessages : MonoBehaviour
{
    [TextArea]
    public string[] messages;
    public TMPro.TextMeshProUGUI textBoxMessage;
   
    public void SetMessage(int score)
    {
        switch(score)
        {
            case 1:
            textBoxMessage.text = messages[0];
            break;
            case 2:
            textBoxMessage.text = messages[1];
            break;
            case 3:
            textBoxMessage.text = messages[2];
            break;
            default:
            textBoxMessage.text = "Looks like you need to improve your art skills";
            break;
        }
    }
}
