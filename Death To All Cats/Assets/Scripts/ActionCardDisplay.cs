using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionCardDisplay : MonoBehaviour
{

    public ActionCard actionCard;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    public TextMeshProUGUI actionDuration;
    public bool minimized;

    // Start is called before the first frame update
    void Start()
    {
        title.text = actionCard.title;
        description.text = actionCard.description;
        actionDuration.text = actionCard.actionDuration.ToString();

        minimized = false;
    }

    private void Update()
    {
        if (minimized)
        {
            description.text = "min";
        }
        else
        {
            description.text = "max";
        }
    }

    public void minimize()
    {
        minimized = true;
    }

    public void maximize()
    {
        minimized = false;
    }
}
