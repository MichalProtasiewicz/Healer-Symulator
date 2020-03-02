using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class BossInfoPanel : MonoBehaviour
{
    public string sceneToChangeName = "";
    public GameObject infoPanel, debuff1, debuff2, tipText, tipButton;
    public TextMeshProUGUI nameText;
    public Image image1, image2;
    public TextMeshProUGUI debuf1InfoText, debuf2InfoText;
    public Sprite[] sprites;
    private BossInfo opennedBossInfo;

    public struct BossInfo
    {
        public int bossId;
        public string bossName, debuf1InfoText, debuf2InfoText, tipText, sceneName;

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
        BossInfo boss1 = new BossInfo(0, "Wolf", "", "", "If you lose better go afk.", "Boss1");
        BossInfo boss2 = new BossInfo(2, "Goblin", "", "", "Flash Heal - your main single target heal.", "Boss2");
        BossInfo boss3 = new BossInfo(4, "Troll", "", "", "Use renew on tanks.", "Boss3");
        BossInfo boss4 = new BossInfo(6, "Gnoll", "", "", "You dont need heal all time, try safe your mana.", "Boss3.1");
        BossInfo boss5 = new BossInfo(8, "Harpie", "", "", "Heal have higher cast time than Flash Heal, but is more effective.", "Boss4");
        BossInfo boss6 = new BossInfo(10, "Harpie Queen", "", "", "Prayer of Healing is your main AoE heal.", "Boss5");
        BossInfo boss7 = new BossInfo(12, "Murlocs", "", "", "Tanks have a lot of stamina and armor, their main aim is keep agro.", "Boss5.1");
        BossInfo boss8 = new BossInfo(14, "Murlocs", "", "", "Healer and Dps get more damage.", "Boss5.2");
        BossInfo boss9 = new BossInfo(16, "Murloc King", "", "", "Healers in your group help you heal raid.", "Boss5.3");

        ///DEBUFY
        BossInfo boss10 = new BossInfo(18, "Assasin Troll", "", "", "If you are pro heal and previous challenges was easy, you can try kill true raid boss for pass tutorial.", "Boss6");
        BossInfo boss11 = new BossInfo(20, "Hunter Troll", "", "", ".......", "Boss6.1");
        BossInfo boss12 = new BossInfo(22, "Berserker Troll", "", "", ".......", "Boss6.2");
        BossInfo boss13 = new BossInfo(24, "Vodo Troll", "", "", ".......", "Boss6.3");
        BossInfo boss14 = new BossInfo(26, "Ranger Troll", "", "", ".......", "Boss6.4");
        BossInfo boss15 = new BossInfo(28, "King Troll", "", "", ".......", "Boss6.5");
        BossInfo boss16 = new BossInfo(30, "Hunter Gnoll", "", "", ".......", "Boss7");
        BossInfo boss17 = new BossInfo(32, "Rogue Gnoll", "", "", ".......", "Boss7.1");
        BossInfo boss18 = new BossInfo(34, "Assasin Gnoll", "", "", ".......", "Boss7.2");
        BossInfo boss19 = new BossInfo(30, "Kobold", "", "", ".......", "Boss7.3");
        BossInfo boss20 = new BossInfo(32, "Skeleton", "", "", ".......", "Boss8");
        BossInfo boss21 = new BossInfo(34, "Zombie", "", "", ".......", "Boss8.1");
        BossInfo boss22 = new BossInfo(36, "Ghost", "", "", ".......", "Boss8.2");
        BossInfo boss23 = new BossInfo(38, "Abonimation", "", "", ".......", "Boss8.3");
        BossInfo boss24 = new BossInfo(40, "Vampir", "", "", ".......", "Boss8.4");
        BossInfo boss25 = new BossInfo(42, "Lich", "", "", ".......", "Boss8.5");
        BossInfo boss26 = new BossInfo(32, "Nathrezim", "", "", ".......", "Boss9");

        BossesInfo.Add(boss1);
        BossesInfo.Add(boss2);
        BossesInfo.Add(boss3);
        BossesInfo.Add(boss4);
        BossesInfo.Add(boss5);
        BossesInfo.Add(boss6);
        BossesInfo.Add(boss7);
        BossesInfo.Add(boss8);
        BossesInfo.Add(boss9);
        BossesInfo.Add(boss10);
        BossesInfo.Add(boss11);
        BossesInfo.Add(boss12);
        BossesInfo.Add(boss13);
        BossesInfo.Add(boss14);
        BossesInfo.Add(boss15);
        BossesInfo.Add(boss16);
        BossesInfo.Add(boss17);
        BossesInfo.Add(boss18);
        BossesInfo.Add(boss19);
        BossesInfo.Add(boss20);
        BossesInfo.Add(boss21);
        BossesInfo.Add(boss22);
        BossesInfo.Add(boss23);
        BossesInfo.Add(boss24);
        BossesInfo.Add(boss25);
        BossesInfo.Add(boss26);
    }

    public void OpenBossInfo(int bossId)
    {
        foreach (BossInfo bossInfo in BossesInfo)
        {
            if (bossInfo.bossId == bossId)
            {
                opennedBossInfo = bossInfo;
                infoPanel.SetActive(true);
                nameText.text = bossInfo.bossName;
                tipText.GetComponent<TextMeshProUGUI>().text = bossInfo.tipText;
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
        tipText.SetActive(false);
        tipButton.SetActive(true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToChangeName);
    }

    public void AdReward()
    {
        tipText.SetActive(true);
        tipButton.SetActive(false);
    }    
}
