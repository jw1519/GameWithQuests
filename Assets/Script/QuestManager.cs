using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    [SerializeField] public List<Quest> quests = new List<Quest>();
    public Dictionary<string, QuestMarker> questMarkers = new Dictionary<string, QuestMarker>();

    private List<string> Quests;
    private void Awake()
    {
        instance = this;
        Quests = new List<string>();
    }


    //quest table
    public TMP_Text QuestMenu;

    
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

        //Add Quest name to pannel
        Quests.Add(name);
        string itemtext = name.ToString();
        QuestMenu.text += itemtext + "\n";
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
