using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour {
    [SerializeField]
    private CardTarget _cardTarget;

    [SerializeField]
    private CustomerPatience _patienceView;

    [SerializeField]
    private CustomerOrder _orderView;

    private int _patience, _maxPatience;
    private CustomerData _customerData;
    private int _pos;

    public Action<int, bool> OnLeave;

    [SerializeField]
    private Transform _bodyPlace, _mouthPlace, _eyePlace, _hatPlace;
    
    [SerializeField]
    private List<GameObject> _bodies, _mouths, _eyes, _hats;

    private void Awake() {
        _cardTarget.Init(CanEndDragOnMe, OnEndDragOnMe);
    }

    public void InitData(CustomerData data, int pos) {
        _maxPatience = data.MaxPatience;
        _patience = data.Patience;
        _customerData = data;
        _pos = pos;
        _patienceView.SetPercent(_patience, _maxPatience);
        _orderView.SetData(data.BasicOrder, data.QualityOrder);

        RandomizeLook();
        gameObject.SetActive(true);
    }

    private void RandomizeLook() {
        if (_bodyPlace.childCount > 0) {
            Destroy(_bodyPlace.GetChild(0).gameObject);
        }

        int body = _customerData.Body != -1 ? _customerData.Body : Random.Range(0, _bodies.Count); 
        Instantiate(_bodies[body], _bodyPlace);
        
        if (_mouthPlace.childCount > 0) {
            Destroy(_mouthPlace.GetChild(0).gameObject);
        }
        int mouthIndex = _customerData.Mouth != -1 ? _customerData.Mouth : Random.Range(0, _mouths.Count); 
        Instantiate(_mouths[mouthIndex], _mouthPlace);
        
        if (_eyePlace.childCount > 0) {
            Destroy(_eyePlace.GetChild(0).gameObject);
        }
        int eyesIndex = _customerData.Eyes != -1 ? _customerData.Eyes : Random.Range(0, _eyes.Count); 
        Instantiate(_eyes[eyesIndex], _eyePlace);
        
        if (_hatPlace.childCount > 0) {
            Destroy(_hatPlace.GetChild(0).gameObject);
        }
        int hatsIndex = _customerData.Hat != -1 ? _customerData.Hat : Random.Range(0, _hats.Count);  
        Instantiate(_hats[hatsIndex], _hatPlace);
    }

    public IEnumerator LosePatience() {
        yield return new WaitForSeconds(0.1f);
        _patience--;
        _patienceView.SetPercent(_patience, _maxPatience);
        if (_patience <= 0) {
            Leave(true);
        }

        yield return new WaitForSeconds(0.1f);
    }

    private void Leave(bool isAngry) {
        gameObject.SetActive(false);
        OnLeave?.Invoke(_pos, isAngry);
    }

    public bool CanEndDragOnMe(CardView cardView) {
        if (cardView == null) {
            return false;
        }

        if (!CheckEatable(cardView.CardData)) {
            return false;
        }

        if (Game.Instance.GameManager.PlayerInventory.Energy == 0) {
            Debug.Log("No energy!");
            return false;
        }

        return true;
    }

    private void OnEndDragOnMe(CardView cardView) {
        Game.Instance.GameManager.LoseEnergy();
        EatCard(cardView);
    }

    private bool CheckEatable(CardData cardData) {
        return CheckOrder(cardData, _customerData.BasicOrder) || (_customerData.QualityOrder.MinDelicious != -1 && CheckOrder(cardData, _customerData.QualityOrder));
    }

    private bool CheckOrder(CardData cardData, OrderData order) {
        if (cardData.Delicious < order.MinDelicious) {
            return false;
        }

        foreach (CardTag greenTag in order.GreenTags) {
            if (!cardData.CardTags.Contains(greenTag)) {
                return false;
            }
        }

        foreach (CardTag redTag in order.RedTags) {
            if (cardData.CardTags.Contains(redTag)) {
                return false;
            }
        }

        return true;
    }

    private void EatCard(CardView card) {
        Debug.Log("Customer ate " + card.CardData.Name + " Delicious " + card.CardData.Delicious);
        if (_customerData.QualityOrder.MinDelicious != -1 && CheckOrder(card.CardData, _customerData.QualityOrder)) {
            Game.Instance.GameManager.AddCoins(3);
        } else {
            Game.Instance.GameManager.AddCoins(1);
        }
        Debug.Log($"You have {Game.Instance.GameManager.PlayerInventory.Coins} coins!");

        if (card.CardData.CheckMechanics(CardMechanics.BurnAfterAte)) {
            card.BurnCard();
        } else {
            card.StashCard();
        }

        Leave(false);
    }
}