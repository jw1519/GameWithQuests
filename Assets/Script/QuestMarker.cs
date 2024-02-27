using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestMarker : MonoBehaviour
{
    public string questName;
    public string questDescription;
    public string questCompletionMessage;

    public TextMeshProUGUI questMenu;

    // Start is called before the first frame update
    void Start()
    {
        QuestManager.instance.RegisterQuestMarker(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            QuestManager.instance.CompleteQuest(questName);
            gameObject.SetActive(false);
            DisplayQuests();
        }
    }
    private void DisplayQuests()
    {
        string displayText = "Quests: \n" + questName + " (Complete)";
        questMenu.text = displayText;
    }

}
