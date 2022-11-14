using BusinessLayer.Repository;
using DataLayer.Models;
using DataLayer.RedirectModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OldFashionShop_PRN221_GroupProject.Helpers;

namespace OldFashionShop_PRN221_GroupProject.Pages.Products
{
    public class CartModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        public List<OrderDetail> Cart { get; set; }
        public CartModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void OnGet()
        {
            Cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
        }
        public IActionResult OnGetBuy(int id, int quantity)
        {
            var product = _productRepository.GetProductById(id);
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<OrderDetail>();
                cart.Add(new OrderDetail()
                {
                    Product = product,
                    Quantity = quantity,
                    Total = product.Price * quantity,
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var index = Exists(cart, product.ProductId);
                if (index == -1)
                {
                    cart.Add(new OrderDetail()
                    {
                        Product = product,
                        Quantity = quantity,
                        Total = product.Price * quantity,
                    });
                }
                else
                {
                    var newQuantity = cart[index].Quantity + quantity;
                    var newTotal = cart[index].Product.Price * newQuantity;
                    cart[index].Quantity = newQuantity;
                    cart[index].Total = newTotal;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Cart");
        }

        private int Exists(List<OrderDetail> cart, int id)
        {
            if (cart != null)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].Product.ProductId.Equals(id))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}