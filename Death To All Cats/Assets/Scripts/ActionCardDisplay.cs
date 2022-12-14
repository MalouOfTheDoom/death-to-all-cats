using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActionCardDisplay : MonoBehaviour
{

    public ActionCard actionCard;
    // directional buttons
    public GameObject arrow;
    public bool hasDirection;
    public Image chosenButton;

    public Image background; 
    public Image icone;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI remainingDurationTMP;
    public int remainingDuration;
    public string actionName;
    public Vector2 actionDirection;
    public bool minimized;


    // Start is called before the first frame update
    void Start()
    {
        
        title.text = actionCard.title;
        description.text = actionCard.description;
        remainingDuration = actionCard.remainingDuration;
        remainingDurationTMP.text = remainingDuration.ToString();
        icone.sprite = actionCard.icone;

        minimized = false;
        actionName = actionCard.actionName;
        actionDirection = actionCard.actionDirection;

        hasDirection = actionCard.hasDirection;
    
        if(!hasDirection)
        {
            arrow.SetActive(false);
        }


    }

    public void minimize()
    {
        minimized = true;

        //transparency
        gameObject.GetComponent<CanvasGroup>().alpha = 0.8f;

        //description
        description.enabled = false;
        //icone
        var tempColor = icone.color;
        tempColor.a = 255;
        icone.color = tempColor;
        icone.transform.localPosition += new Vector3(0,50,0);

        RectTransform rectTransf;

        //background
        rectTransf = background.GetComponent<RectTransform>();
        rectTransf.sizeDelta = new Vector3(150, 150, 0);

        //title
        title.enabled = false;

        //remainingDuration
        rectTransf = remainingDurationTMP.GetComponent<RectTransform>();
        rectTransf.sizeDelta = new Vector3(150, 85, 0);
        remainingDurationTMP.fontSize = 60;

        rectTransf.localPosition = new Vector3(0, 40, 0);


        // arrow
        arrow.SetActive(false);
        // chosen button
        if(hasDirection)
        {
            chosenButton.enabled = true;
        }

    }

    public void maximize()
    {
        minimized = false;
        var tempColor = icone.color;
        tempColor.a = 0.5f;
        icone.color = tempColor;
        icone.transform.localPosition = new Vector3(0,-71,0);
        //transparency
        gameObject.GetComponent<CanvasGroup>().alpha = 1;

        //description
        description.enabled = true;

        //background
        RectTransform rectTransf = background.GetComponent<RectTransform>();
        rectTransf.sizeDelta = new Vector3(200, 300, 0);

        //title
        title.enabled = true;

        //remainingDuration
        rectTransf = remainingDurationTMP.GetComponent<RectTransform>();
        rectTransf.sizeDelta = new Vector3(200, 50, 0);
        rectTransf.localPosition = new Vector3(60, 115, 0);

        // chosen button
        chosenButton.enabled = false;

        // arrow
        if(hasDirection)
        {
            arrow.SetActive(true);
        }

    }

    public void consumeOneDuration()
    {
        remainingDuration -= 1;
        remainingDurationTMP.text = remainingDuration.ToString();
    }
    
    public void upDirection()
    {
        actionDirection = new Vector2(0,1);
		chosenButton.transform.eulerAngles = new Vector3(0,0,90);

    }
    public void downDirection()
    {
        actionDirection = new Vector2(0,-1);
		chosenButton.transform.eulerAngles = new Vector3(0,0,-90);
    }
    public void leftDirection()
    {
        actionDirection = new Vector2(-1,0);
		chosenButton.transform.eulerAngles = new Vector3(0,0,180);
    }
    public void rightDirection()
    {
        actionDirection = new Vector2(1,0);
		chosenButton.transform.eulerAngles = new Vector3(0,0,0);
    }

}
