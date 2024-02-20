using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    [SerializeField] public List<Quest> quests = new List<Quest>();
    public Dictionary<string, QuestMarker> questMarkers = new Dictionary<string, QuestMarker>();

    private void Awake()
    {
        instance = this;
    }

    //quest table
    public TMP_Text QuestMenu;

    private void Start()
    {
        DisplayQuests();
    }

    private void DisplayQuests()
    {
        string displayText = "Quests: \n";


        QuestMenu.text = displayText;
    }
    //

    public void RegisterQuestMarker(QuestMarker marker)
    {
        if (!questMarkers.ContainsKey(marker.questName))
        {
            questMarkers.Add(marker.questName, marker);
            marker.gameObject.SetActive(false); //disable the marker 
        }
    }

    public void AddQuest(string name, string description)
    {
        quests.Add(new Quest(name, description));
        EnableQuestMarker(name);

    }

    public void EnableQuestMarker(string name)
    {
        if (questMarkers.ContainsKey(name))
        {
            questMarkers[name].gameObject.SetActive(true);
        }
    }

    public void CompleteQuest(string name)
    {
        Quest quest = quests.Find(q => q.questName == name);

        if(quest != null)
        {
            quest.isCompleted = true;
        }
    }
}
