using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PathButton : MonoBehaviour {
    [SerializeField]
    private Button _button;

    private DayConfig _config;

    [SerializeField]
    private List<TypeSpritePair> _sprites;

    [SerializeField]
    private Image _iconImage;
    [SerializeField]
    private RectTransform _rectTransform;

    public RectTransform RectTransform => _rectTransform;
    public string Uid => _config?.Uid ?? "";

    public void Init(DayConfig config) {
        _config = config;

        _iconImage.sprite = _sprites.FirstOrDefault(p => p.Type == config.DayType)!.Sprite;

        _button.onClick.AddListener(OnSelected);
        gameObject.SetActive(true);
    }

    public void SetAsEntryDay(DayConfig config) {
        Init(config);
        _button.interactable = false;
    }

    public void SetInteractable(bool isInteractable) {
        _button.interactable = isInteractable;
    }

    public void OnSelected() {
        PathManager.Instance.SelectLevel(_config);
    }
}

[Serializable]
public class TypeSpritePair {
    public DayType Type;
    public Sprite Sprite;
}