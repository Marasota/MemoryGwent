using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 4f;
    public const float offsetY = 5f;

    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMeshPro scoreLabel;
    [SerializeField] private Canvas _menu;

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;

    private int _score = 0;
    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }
    public void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch()); 
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            Debug.Log("Score: " + _score);
            if (_score == 4)
            {
                Invoke("EndGame", 2f);
            }
        }
        else
        {
            yield return new WaitForSeconds(.8f);
            _firstRevealed.Unreveal(); 
            _secondRevealed.Unreveal();
        }
        _firstRevealed = null; 
        _secondRevealed = null;

        scoreLabel.text = "Score: " + _score;
    }

    void Start()
    {
        _menu.enabled = false;

        scoreLabel.text = "Score: " + _score;

        CloneCards();
    
    }

    public void CloneCards()
    {
        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }
                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);
                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    { 
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    public void EndGame()
    {
        _menu.enabled = true;
    }
}
