using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


public class ItemScrollView : MonoBehaviour
{
    [Header("아이템 스크롤 뷰")]
    [SerializeField] private GameObject _itemDisplayPrefab;
    [SerializeField] private Transform _contentPanel;

    private ScrollRect _scrollRect;

    private void Start()
    {
        if (_scrollRect == null)
            _scrollRect = GetComponent<ScrollRect>();
    }


    public void AddItem(ItemData itemData)
    {
        GameObject itemDisplay = Instantiate(_itemDisplayPrefab, _contentPanel);
        ItemDisplay itemDisplayScript = itemDisplay.GetComponent<ItemDisplay>();
        itemDisplayScript.SetupItem(itemData);
    }

    public void ClearItems()
    {
        foreach (Transform child in _contentPanel)
        {
            Destroy(child.gameObject);
        }
    }
}
