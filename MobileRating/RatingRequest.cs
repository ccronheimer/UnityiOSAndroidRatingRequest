using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ANDROID
using Google.Play.Review;
#endif

#if UNITY_IPHONE
using UnityEngine.iOS;
#endif

public class RatingRequest : MonoBehaviour
{
#if UNITY_ANDROID
    private ReviewManager reviewManager;
    private PlayReviewInfo playReviewInfo;
#endif

   public void RequestReview()
   {
#if UNITY_ANDROID

        if(PlayerPrefs.GetInt("Rating") == 0)
        {
            StartCoroutine(RequestReviewAndroid());
            PlayerPrefs.SetInt("Rating", 1);
        }
#endif

#if UNITY_IPHONE

        if(PlayerPrefs.GetInt("Rating") == 0)
        {
            RequestReviewiOS();
            PlayerPrefs.SetInt("Rating", 1);
        }
#endif
    }

   private void RequestReviewiOS()
    {
#if UNTIY_IPHONE

         Device.RequestStoreReview();
          
#endif

    }

#if UNITY_ANDROID
    private IEnumerator RequestReviewAndroid()
    {

        reviewManager = new ReviewManager();

        // Request a ReviewInfo Object
        var requestFlowOperation = reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;

        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            yield break;
        }

        playReviewInfo = requestFlowOperation.GetResult();

        // Launch InApp Review Flow
        var launchFlowOperation = reviewManager.LaunchReviewFlow(playReviewInfo);
        yield return launchFlowOperation;
        playReviewInfo = null;
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            yield break;
        }
    }
#endif
}
