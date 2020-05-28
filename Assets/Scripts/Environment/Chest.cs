using UnityEngine;

public class Chest : Interactable
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite openChest, closedChest;

    public GameObject[] itemsDrop;

    //private bool isOpen = false;

    public override void Interact()
    {
        /*if (isOpen)
        {
            isOpen = false;
            spriteRenderer.sprite = closedChest;
        }
        else
        {
            isOpen = true;*/
            spriteRenderer.sprite = openChest;
        //}

        for (int i = 0; i < 2; i++)
        {
            itemsDrop[i].SetActive(true);
        }

        /*
        itemsDrop[0].SetActive(true);
        itemsDrop[0].GetComponent<Animator>().enabled = true;
        */

        gameObject.GetComponent<Animator>().enabled = true;
    }

    void SetChestToInactive()
    {
        gameObject.SetActive(false);
    }
}
