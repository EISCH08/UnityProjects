using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gameManger;

   void OnTriggerEnter()
    {
        gameManger.CompleteLevel();
    }
}
