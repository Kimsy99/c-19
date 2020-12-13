using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            SceneLoader._instance.LoadScene("OtherCharacterMovementScene");
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            SceneLoader._instance.LoadScene("MasterSampleScene");
        }
        
    }
}
