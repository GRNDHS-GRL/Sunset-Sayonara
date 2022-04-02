using UnityEngine;

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialouge/New Speaker")]

public class Speaker : ScriptableObject
{
    [SerializeField] private string speakerName;
    [SerializeField] private Sprite speakerSprite;


    public string GetName()
    {
        return speakerName;
    }

    public Sprite GetSprite()
    {
        return speakerSprite;
    }
}
