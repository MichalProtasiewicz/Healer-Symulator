using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdScript : MonoBehaviour
{

    public string gameId = "3360460";
    public string placementId = "bannerPlacement";
    public bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
        yield return new WaitForSeconds(10.0f);
        Advertisement.Banner.Hide();
    }
}