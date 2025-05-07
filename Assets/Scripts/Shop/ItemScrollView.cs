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
    private float _scrollSpeed = 200f;

    private void Start()
    {
        if (_scrollRect == null)
            _scrollRect = GetComponent<ScrollRect>();
    }
    private void Update()
    {
        // 마우스 휠로 스크롤 처리
        float scrollInput = Mouse.current.scroll.ReadValue().y;
        if (scrollInput != 0 && _scrollRect != null)
        {
            Vector2 scrollPosition = _scrollRect.normalizedPosition;
            scrollPosition.y += scrollInput * _scrollSpeed * Time.deltaTime;
            scrollPosition.y = Mathf.Clamp01(scrollPosition.y);  // 0~1 사이 값으로 제한
            _scrollRect.normalizedPosition = scrollPosition;
        }
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
