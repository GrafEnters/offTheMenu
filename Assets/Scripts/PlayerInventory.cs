using System;
using System.Collections.Generic;

[Serializable]
public class PlayerInventory {
    public Deck Deck = new Deck();
    public int Coins;
    public List<Artefact> Artefacts = new List<Artefact>();
    public int Energy, MaxEnergy;
    public int Hp;
}