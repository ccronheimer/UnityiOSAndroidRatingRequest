## Unity iOS and Android Rating Request ⭐️

1. To use Android's rating request you need to import [Google Play Plugins](https://github.com/google/play-unity-plugins)❗
2. Drag the **RatingRequest** prefab into your scene 📦
3. Call `RatingRequest.RequestReview()` from any script when you want to request a review from the user. 

## Example

```C#
RatingRequest ratingRequest;

void Start(){
    ratingRequest = FindObjectOfType<RatingRequest>();
}

// eg. request rating after x amount of games
void RequestRating(){
   if(ratingRequest != null) {
     ratingRequest.RequestReview();
  }
}

```
#### Notes
<li>Ratings prompt will only pop up once in your apps life cylce.
<li>Android rating prompt will only pop up when app is live or using an internal test track.
<li>Google Play Plugins <strong>MUST</strong> be imported for the prompt to work on Android.
<li>RatingRequest prefab or script attached to a object <strong>MUST</strong> be in your scene.


## Output
  ### Android
<img src="https://gloify.com/wp-content/uploads/2020/09/in-app-review.jpg"
     alt="Markdown Monster icon" width="600px" />
   ### iOS
  <img src="https://developer.apple.com/design/human-interface-guidelines/ios/images/AppRating_2x.png"
     alt="Markdown Monster icon" height="400px" />
