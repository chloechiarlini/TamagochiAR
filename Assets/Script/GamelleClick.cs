using UnityEngine;

public class GamelleClick : MonoBehaviour
{
    public FeedManager feedManager;

    void OnMouseDown()
    {
        if (feedManager != null)
        {
            feedManager.SpawnFraises();
        }
    }
}