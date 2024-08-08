using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TagFactory : MonoBehaviour {

    public static TagFactory Instance;
    
    [SerializeField]
    private List<TagPrefabPair> _tagsTable;

    private void Awake() {
        Instance = this;
    }

    public TagView GetTagView(CardTag tag) {
        TagView prefab = _tagsTable.FirstOrDefault(t => t.Tag == tag).TagView;
        return Instantiate(prefab);
    }
}

[Serializable]
public class TagPrefabPair {
    public CardTag Tag;
    public TagView TagView;
}

