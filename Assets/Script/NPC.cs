using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public QuestMarker questMarker;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Quest quest = QuestManager.instance.quests.Find(q => q.questName == questMarker.questName);

            if(quest == null) // quest not yet started
            {
                QuestManager.instance.AddQuest(questMarker.questName, questMarker.questDescription);
                questMarker.gameObject.SetActive(true);
                Debug.Log(questMarker.questDescription);
            }
            else if (quest.isCompleted)
            {
                Debug.Log(questMarker.questCompletionMessage);
                QuestManager.instance.questMenu.text = " Quests: \n";
                foreach (string questName in QuestManager.instance.Quests) // doesnt work with more than two questsa
                {
                    string itemtext = questName.ToString();
                    QuestManager.instance.questMenu.text += itemtext + "\n";
                }
            }

        
        }
    }
}
