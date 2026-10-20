using UnityEngine;

public class ButtonGeneric : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnButtonPress()
    {
        print("Button pressed!");
    }
}
