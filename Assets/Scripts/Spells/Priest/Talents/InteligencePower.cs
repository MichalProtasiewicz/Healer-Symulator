using UnityEngine;

public class InteligencePower : TalentController
{
    public override void TalentFunction()
    {
        PlayerPrefs.SetFloat("PlayerSpellPower", PlayerPrefs.GetFloat("PlayerSpellPower") + 2f);
    }
    public override void DeactivateTalentFunction()
    {
        PlayerPrefs.SetFloat("PlayerSpellPower", PlayerPrefs.GetFloat("PlayerSpellPower") - 2f);
    }
}
