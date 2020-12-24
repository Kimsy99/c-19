using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            SceneLoader.Instance.LoadScene("OtherCharacterMovementScene");
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            SceneLoader.Instance.LoadScene("MasterSampleScene");
        }
        
    }
}
