using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragDrop : MonoBehaviour, IPointerDownHandler,
                            IBeginDragHandler, IEndDragHandler, 
                            IDragHandler, IDropHandler
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    public FoodType foodType;
    [SerializeField]
    public FoodStateEnum foodStates;
    private RectTransform rectTransform;
    private Vector2 originRectTransform;

    private CanvasGroup canvasGroup;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originRectTransform = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        if (FoodManager.Instance.GetNbFood(foodStates, foodType) != 0)
        {
            rectTransform.anchoredPosition += eventData.delta / (canvas != null ? canvas.scaleFactor : 1);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        rectTransform.anchoredPosition = originRectTransform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
    }
}
