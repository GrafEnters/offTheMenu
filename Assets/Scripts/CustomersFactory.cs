using System.Collections.Generic;

public class CustomersFactory {
    public List<CustomerData> GetCustomers() {
        return new List<CustomerData>() {
            new CustomerData() {
                MaxPatience = 3,
                Patience = 3,
                Uid = "customer0",
                BasicOrder = new OrderData() {
                    MinDelicious = 2,
                },
                QualityOrder = new OrderData() {
                    MinDelicious = 3,
                    RedTags = new List<CardTag>() { CardTag.Raw }
                }
            },
            new CustomerData() {
                MaxPatience = 5,
                Patience = 5,
                Uid = "customer1",
                BasicOrder = new OrderData() {
                    MinDelicious = 3,
                },
                QualityOrder = new OrderData() {
                    MinDelicious = 3,
                    RedTags = new List<CardTag>() { CardTag.Meaty }
                }
            },
            new CustomerData() {
                MaxPatience = 4,
                Patience = 4,
                Uid = "customer2",
                BasicOrder = new OrderData() {
                    MinDelicious = 2,
                },
                QualityOrder = new OrderData() {
                    MinDelicious = 3,
                    GreenTags = new List<CardTag>() { CardTag.Meaty }
                }
            },
            new CustomerData() {
                MaxPatience = 3,
                Patience = 3,
                Uid = "customer3",
                BasicOrder = new OrderData() {
                    MinDelicious = 2,
                },
                QualityOrder = new OrderData() {
                    MinDelicious = 5
                }
            },
            new CustomerData() {
                MaxPatience = 4,
                Patience = 4,
                Uid = "customer4",
                BasicOrder = new OrderData() {
                    MinDelicious = 2,
                }
            }
        };
    }
}