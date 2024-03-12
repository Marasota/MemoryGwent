using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using DG.Tweening;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;

    [SerializeField] private SceneController controller;
    private int _id;
    public int id
    {
        get { return _id; }
    }
    public void SetCard(int id, Sprite image)
    { 
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image; 
    }
    public void OnMouseDown()
    {
        if (cardBack.activeSelf && controller.canReveal)
        {
            Debug.Log($"ID = {_id}");

            //gameObject.SetActive(false);

            /*   transform.DOLocalRotate(new Vector3(0, 180, 0), 0.5f).OnComplete(() =>
               {
                   cardBack.SetActive(false);
               });
   */

            transform.DOLocalRotate(new Vector3(0, 180f, 0), 0.5f, RotateMode.LocalAxisAdd);

              cardBack.SetActive(false);
            controller.CardRevealed(this); 

        }
    }
    public void Unreveal()
    {
        /* transform.DOLocalRotate(new Vector3(0, -180, 0), 0.5f).OnComplete(() =>
         {
             cardBack.SetActive(true);
         });*/

        transform.DOLocalRotate(new Vector3(0, -180f, 0), 0.5f, RotateMode.LocalAxisAdd);
        cardBack.SetActive(true);
    }
}
