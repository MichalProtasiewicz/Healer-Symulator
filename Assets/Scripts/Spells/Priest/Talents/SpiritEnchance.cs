using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritEnchance : TalentController
{
    public override void TalentFunction()
    {
        PlayerPrefs.SetFloat("PlayerManaRegenerate", PlayerPrefs.GetFloat("PlayerManaRegenerate") + 0.1f);
    }
    public override void DeactivateTalentFunction()
    {
        PlayerPrefs.SetFloat("PlayerManaRegenerate", PlayerPrefs.GetFloat("PlayerManaRegenerate") - 0.1f);
    }
}
