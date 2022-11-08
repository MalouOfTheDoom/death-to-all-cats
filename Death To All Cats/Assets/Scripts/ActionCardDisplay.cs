using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActionCardDisplay : MonoBehaviour
{

    public ActionCard actionCard;

    public Image background; 
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

        minimized = false;
        actionName = actionCard.actionName;
        actionDirection = actionCard.actionDirection;
    }

    public void minimize()
    {
        minimized = true;

        //transparency
        gameObject.GetComponent<CanvasGroup>().alpha = 0.8f;

        //description
        description.enabled = false;

        //background
        RectTransform rectTransf = background.GetComponent<RectTransform>();
        rectTransf.sizeDelta = new Vector3(150, 150, 0);

        //title
        rectTransf = title.GetComponent<RectTransform>();
        rectTransf.sizeDelta = new Vector3(160, 150, 0);
        rectTransf.localPosition = new Vector3(0, -20, 0);

        //remainingDuration
        rectTransf = remainingDurationTMP.GetComponent<RectTransform>();
        rectTransf.sizeDelta = new Vector3(200, 50, 0);
        rectTransf.localPosition = new Vector3(0, 40, 0);



    }

    public void maximize()
    {
        minimized = false;

        //transparency
        gameObject.GetComponent<CanvasGroup>().alpha = 1;

        //description
        description.enabled = true;

        //background
        RectTransform rectTransf = background.GetComponent<RectTransform>();
        rectTransf.sizeDelta = new Vector3(200, 300, 0);

        //title
        rectTransf = title.GetComponent<RectTransform>();
        rectTransf.sizeDelta = new Vector3(150, 50, 0);
        rectTransf.localPosition = new Vector3(0, 50, 0);

        //remainingDuration
        rectTransf = remainingDurationTMP.GetComponent<RectTransform>();
        rectTransf.sizeDelta = new Vector3(200, 50, 0);
        rectTransf.localPosition = new Vector3(60, 115, 0);

    }

    public void consumeOneDuration()
    {
        remainingDuration -= 1;
        remainingDurationTMP.text = remainingDuration.ToString();
        if (remainingDuration == 0)
        {
            destroyCardAction();
        }
    }

    public void destroyCardAction()
    {
        Destroy(gameObject);
    }
}
