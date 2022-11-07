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

    // Start is called before the first frame update
    void Start()
    {
        title.text = actionCard.title;
        description.text = actionCard.description;
        actionDuration.text = actionCard.actionDuration.ToString();
    }

    
}
