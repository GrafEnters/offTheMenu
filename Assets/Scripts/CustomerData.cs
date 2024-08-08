using System.Collections.Generic;

public class CustomerData {
    public string Uid;
    public string Name;
    public int Patience;
    public int MaxPatience;
    public OrderData BasicOrder;
    public OrderData QualityOrder;
}

public class OrderData {
    public int MinDelicious;
    public List<CardTag> GreenTags = new List<CardTag>();
    public List<CardTag> RedTags = new List<CardTag>();
}