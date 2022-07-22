using UnityEngine;

//Sempre segue a hierarquia no click
[SelectionBase]
[HelpURL("https://unity.com/")]
//adiciona o script no menu de componentes
[AddComponentMenu("Seu script")]

//[ExecuteInEditMode]
public class Attributes : MonoBehaviour
{
    //Nao funciona com properties, somente fields
    [SerializeField] private int DownWork { get; set; }

    public int Field;

    [Space, SerializeField] private int _serializeField;
    [Space(20), SerializeField] private int m_serializeField;

    [Header("Nao remove k_")]
    [SerializeField] private int k_serializeField;

    [Header("Hidden")]
    [HideInInspector] public int HiddenPublicField;

    //==============

    [Header("Control Attributes")]
    [Range(1f, 3f), SerializeField] private float RangeValue;
    [Min(10), SerializeField] public int MinValue;

    [Header("List")]
    [NonReorderable] public int[] Numbers = new int[] { 1, 2, 3, 4, 5 };

    //==============

    [Header("Text Attributes")]
    [Multiline(5)] public string MultiLineText;

    [Tooltip("Explicação da Variavel")]
    [TextArea] public string TextArea;

    //==============

    //atualiza somente com enter
    [Delayed] public int SetValueDelayed;

    public enum MyEnum
    {

        [InspectorName("Primeiro")] First = 0,
        [InspectorName("Segundo")] Second = 1
    }

    //=========

    [ContextMenuItem("Get a random number", "GetRandomNumber")]
    public int RandomNumber;

    private void GetRandomNumber()
    {
        RandomNumber = Random.Range(0, 42);
    }

    //=========

    [ContextMenu("Setar valores no inspector")]
    void NewThing()
    {
        Field = 2;
        MinValue = 13;
        RangeValue = 2;
    }




}
