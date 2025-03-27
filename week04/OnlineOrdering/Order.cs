 using System;
 using System.Collections.Generic;
 public class Order
    {
        private Customer _customer;
        private List<Product> _products;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal GetTotalCost()
        {
            decimal productCost = 0;
            foreach (var product in _products)
            {
                productCost += product.GetTotalCost();
            }

            decimal shippingCost = _customer.IsInUSA() ? 5m : 35m;
            return productCost + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "PACKING LABEL:\n";
            foreach (var product in _products)
            {
                label += $"{product.Name} (ID: {product.ProductId})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"SHIPPING LABEL:\nShip to: {_customer.Name}\n{_customer.Address.GetFullAddress()}";
        }
    }