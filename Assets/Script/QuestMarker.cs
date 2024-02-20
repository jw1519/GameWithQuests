using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarker : MonoBehaviour
{
    public string questName;
    public string questDescription;
    public string questCompletionMessage;

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
        }
    }
}
