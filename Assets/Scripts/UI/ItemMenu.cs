using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    [SerializeField] private List<Item> itemsPrefabs;
    [SerializeField] private Text title;
    [SerializeField] private RectTransform viewport;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject itemPrefab; // Prefab przedmiotu

    // Metoda dodaj�ca przedmioty do menu
    public void AddItems(List<Item> items)
    {
        ClearItems();

        foreach (Item item in items)
        {
            GameObject newItem = Instantiate(itemPrefab, content);
            Item itemComponent = newItem.GetComponent<Item>();

            if (itemComponent != null)
            {
                itemComponent.SetItemInfo(newItem.GetComponent<Image>(), newItem.GetComponentInChildren<Text>());
            }
        }
    }

    // Metoda czyszcz�ca list� przedmiot�w
    public void ClearItems()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
