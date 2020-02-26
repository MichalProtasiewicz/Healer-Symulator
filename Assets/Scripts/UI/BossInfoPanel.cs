using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class BossInfoPanel : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI nameText;
    public GameObject debuff1;
    public GameObject debuff2;
    public Image image1;
    public Image image2;
    public TextMeshProUGUI debuf1InfoText;
    public TextMeshProUGUI debuf2InfoText;
    public TextMeshProUGUI tipText;
    public string sceneToChangeName = "";

    public Sprite[] sprites;

    public struct BossInfo
    {
        public int bossId;
        public string bossName;
        public string debuf1InfoText;
        public string debuf2InfoText;
        public string tipText;
        public string sceneName;

        public BossInfo(int bossId, string bossName, string debuf1InfoText, string debuf2InfoText, string tipText, string sceneName)
        {
            this.bossId = bossId;
            this.bossName = bossName;
            this.debuf1InfoText = debuf1InfoText;
            this.debuf2InfoText = debuf2InfoText;
            this.tipText = tipText;
            this.sceneName = sceneName;
        }
    }

    List<BossInfo> BossesInfo = new List<BossInfo>();

    void Awake()
    {
        //Boss id co 2, bo dwie ikony debufu
        BossInfo defaultBoss = new BossInfo(0, "Default Boss", "You need to dispel it.", "", "Heal better, thats all.", "BossScene");
        BossInfo arthas = new BossInfo(2, "Arthas", "Defile on me.", "Dispel it", "Use renew on tanks", "copyBoss");
        
        BossesInfo.Add(defaultBoss);
        BossesInfo.Add(arthas);
        
    }

    public void OpenBossInfo(int bossId)
    {
        foreach (BossInfo bossInfo in BossesInfo)
        {
            if (bossInfo.bossId == bossId)
            {
                infoPanel.SetActive(true);
                nameText.text = bossInfo.bossName;
                tipText.text = bossInfo.tipText;
                sceneToChangeName = bossInfo.sceneName;
                if (bossInfo.debuf1InfoText != "")
                {
                    debuff1.SetActive(true);
                    debuf1InfoText.text = bossInfo.debuf1InfoText;
                    image1.sprite = sprites[bossId];
                }
                else
                    debuff1.SetActive(false);
                if (bossInfo.debuf2InfoText != "")
                {
                    debuff2.SetActive(true);
                    debuf2InfoText.text = bossInfo.debuf2InfoText;
                    image2.sprite = sprites[bossId + 1];
                }
                else
                    debuff2.SetActive(false);
            }
        }
    }

    public void CloseWindow()
    {
        infoPanel.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToChangeName);
    }

}
