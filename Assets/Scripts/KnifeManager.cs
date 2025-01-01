using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> KnifeList = new List<GameObject> ();
    [SerializeField] private List<GameObject> KnifeIconList = new List<GameObject> ();
    [SerializeField] private GameObject KnifePrefab;
    [SerializeField] private GameObject KnifeIconPrefab;

    [SerializeField] private Color activeColor;
    [SerializeField] private Color disabledColor;

    [SerializeField] private Vector2 KnifeIconPosition;


    [SerializeField] private int KnifeCount;

    private int KnifeIndex= 0;

    private void Start(){
        CreateKnifes();
        CreateKnifesIcons();
    }

    private void CreateKnifes(){
        for( int i = 0; i< KnifeCount; i++)
        {
            GameObject newKnife = Instantiate(KnifePrefab,transform.position,Quaternion.identity);
            newKnife.SetActive(false);
            KnifeList.Add(newKnife);
        }
        KnifeList[0].SetActive(true);

    }
    private void CreateKnifesIcons(){
        for( int i = 0; i< KnifeCount; i++)
        {
            GameObject newKnifeIcon = Instantiate(KnifeIconPrefab,KnifeIconPosition,KnifeIconPrefab.transform.rotation);
           newKnifeIcon.GetComponent<SpriteRenderer>().color = activeColor;
           KnifeIconPosition.y +=0.5f;
           KnifeIconList.Add(newKnifeIcon);
        }
        KnifeList[0].SetActive(true);
    }

    public void SetDisableKnifeIconColor(){
        KnifeIconList[(KnifeIconList.Count - 1) - KnifeIndex ].GetComponent<SpriteRenderer>().color = disabledColor;

    }
    public void SetActiveKnife(){
        if(KnifeIndex < KnifeCount - 1 ){
            KnifeIndex++;
            KnifeList[KnifeIndex].SetActive(true);
        }

    }
}
