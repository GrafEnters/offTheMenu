using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerPanel : MonoBehaviour {
    [SerializeField]
    private Customer _customerPrefab;

    private Queue<CustomerData> _datas;

    [SerializeField]
    private Customer[] CurrentCustomers = new Customer[3];

    private CustomerData[] CurrentCustomersDatas = new CustomerData[3];

    //Separate view from logic; Queue must be saved in customrersManager and passed here via action

    private void Awake() {
        CurrentCustomers[0].OnLeave += LeaveCustomer;
        CurrentCustomers[1].OnLeave += LeaveCustomer;
        CurrentCustomers[2].OnLeave += LeaveCustomer;
    }

    public void QueueCustomers(List<CustomerData> datas) {
        _datas = new Queue<CustomerData>(datas);
        TryFillSlots();
    }

    public void QueueCustomer(CustomerData data) {
        _datas.Enqueue(data);
        TryFillSlots();
    }

    private void TryFillSlots() {
        TryAddCustomer(0);
        TryAddCustomer(1);
        TryAddCustomer(2);
    }

    private void TryEndDay() {
        if (_datas.Count != 0 || CurrentCustomersDatas[0] != null || CurrentCustomersDatas[1] != null || CurrentCustomersDatas[2] != null) {
            return;
        }

        EndDay();
    }

    private void EndDay() {
        SceneManager.LoadScene("PathScene");
    }

    private void TryAddCustomer(int pos) {
        if (_datas.Count <= 0 || CurrentCustomersDatas[pos] != null) {
            return;
        }

        CustomerData data = _datas.Dequeue();

        CurrentCustomersDatas[pos] = data;
        CurrentCustomers[pos].InitData(data, pos);
    }

    public IEnumerator LoseCustomersPatience() {
        if (CurrentCustomersDatas[0] != null) {
            yield return StartCoroutine(CurrentCustomers[0].LosePatience());
        }

        if (CurrentCustomersDatas[1] != null) {
            yield return StartCoroutine(CurrentCustomers[1].LosePatience());
        }

        if (CurrentCustomersDatas[2] != null) {
            yield return StartCoroutine(CurrentCustomers[2].LosePatience());
        }
    }

    private void LeaveCustomer(int pos, bool isAngry = false) {
        if (isAngry) {
            Game.Instance.GameManager.LoseHp();
        }

        CurrentCustomersDatas[pos] = null;
        TryAddCustomer(pos);
        
        TryEndDay();
    }
}