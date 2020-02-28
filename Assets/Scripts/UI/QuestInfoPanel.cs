using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestInfoPanel : MonoBehaviour
{
    public GameObject infoPanel, takeQuestButton, finishQuestButton;
    public TextMeshProUGUI nameText, infoText;

    public struct QuestInfo
    {
        public int questId;
        public string questName, questText;
        public bool isDone, isTook;

        public QuestInfo(int questId, string questName, string questText, bool isDone, bool isTook)
        {
            this.questId = questId;
            this.questName = questName;
            this.questText = questText;
            this.isDone = isDone;
            this.isTook = isTook;
        }
    }
    List<QuestInfo> QuestsInfo = new List<QuestInfo>();

    void Awake()
    {
        QuestInfo defaultQuest1 = new QuestInfo(0, "Default Quest1", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            false, false);
        QuestInfo defaultQuest2 = new QuestInfo(1, "Default Quest2", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            false, true);
        QuestInfo defaultQuest3 = new QuestInfo(2, "Default Quest3", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            true, true);

        QuestsInfo.Add(defaultQuest1);
        QuestsInfo.Add(defaultQuest2);
        QuestsInfo.Add(defaultQuest3);
    }

    public void OpenInfoPanel(int questId)
    {
        foreach (QuestInfo questInfo in QuestsInfo)
        {
            if (questInfo.questId == questId)
            {
                infoPanel.SetActive(true);
                nameText.text = questInfo.questName;
                infoText.text = questInfo.questText;

                //jesli quest wziety lub nie
                if (questInfo.isTook == false)
                {
                    takeQuestButton.SetActive(true);
                }
                else
                {
                    takeQuestButton.SetActive(false);
                }
                //jesli quest wziety ale nie zrobiony    
                if (questInfo.isDone == false && questInfo.isTook == true) //?
                {
                    finishQuestButton.SetActive(true);
                }
                //jesli quest zrobiony
                else
                {
                    finishQuestButton.SetActive(false);
                }
            }
        }
    }

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }

    public void AcceptQuest(int questId)
    {
        CloseInfoPanel();
    }

    public void FinishQuest(int questId)
    { 
        CloseInfoPanel();
    }

}
