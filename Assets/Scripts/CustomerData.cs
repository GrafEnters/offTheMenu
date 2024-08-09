using System;
using System.Collections.Generic;

[Serializable]
public class CustomerData {
    public string Uid;
    public string Name;
    public int Body = -1, Eyes = -1, Mouth = -1, Hat = -1;
    public int Patience;
    public int MaxPatience;
    public OrderData BasicOrder;
    public OrderData QualityOrder;
}

[Serializable]
public class OrderData {
    public int MinDelicious;
    public List<CardTag> GreenTags = new List<CardTag>();
    public List<CardTag> RedTags = new List<CardTag>();
}