using Bibliothek.Model.Entity;
using Bibliothek.UI.Areas.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliothek.UI.Areas.Web.Models
{
    public class ProductCart
    {
        private Dictionary<Guid, ProductVM> _cart = null;

        public ProductCart()
        {
            _cart = new Dictionary<Guid, ProductVM>();
        }

        public List<ProductVM> CartProductList
        {
            get
            {
                return _cart.Values.ToList();
            }
        }

        public void AddCart(ProductVM item)
        {
            if (item.UnitsInStock > 0)
            {
                if (!_cart.ContainsKey(item.ID))
                {
                    _cart.Add(item.ID, item);
                }
                else
                {
                    _cart[item.ID].Quantity++;
                }
            }
            else
            return;
        }

        public void IncreaseCart(Guid id)
        {
            var s = _cart[id].UnitsInStock;
            if (s > _cart[id].Quantity)
            {
                _cart[id].Quantity++;
            }
        }

        public void DecreaseCart(Guid id)
        {
            _cart[id].Quantity--;
            if (_cart[id].Quantity <= 0)
                _cart.Remove(id);
        }

        public void RemoveCart(Guid id)
        {
            _cart.Remove(id);
        }        
    }
}