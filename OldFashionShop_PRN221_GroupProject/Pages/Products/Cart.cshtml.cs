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
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public List<OrderDetail> Cart { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Note { get; set; }
        public CartModel(IProductRepository productRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
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
                    //Product = product,
                    ProductName = product.ProductName,
                    Quantity = quantity,
                    Total = product.Price * quantity,
                    ProductId = product.ProductId,
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
                        //Product = product,
                        ProductName = product.ProductName,
                        Quantity = quantity,
                        Total = product.Price * quantity,
                        ProductId = product.ProductId,
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

        public IActionResult OnPostEdit(int id, int quantity)
        {
            var product = _productRepository.GetProductById(Id);
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            var index = Exists(cart, product.ProductId);
            if (index == -1)
            {
                return NotFound();
            }
            else
            {
                var newQuantity = Quantity;
                var newTotal = cart[index].Product.Price * newQuantity;
                cart[index].Quantity = newQuantity;
                cart[index].Total = newTotal;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            Cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            return Page();
        }

        public IActionResult OnPostCheckOut()
        {
            Cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            //var accountId = int.Parse(HttpContext.Session.GetString("ACCOUNT_ID"));
            var order = new Order()
            {
                Status = 1,
                OrderDate = DateTime.Now,
                OrderDetails = Cart,
                Deleted = false,
                AccountId = 2,
                Note = Note,
            };
            try
            {
                var newOrder = _orderRepository.AddOrder(order);
                //foreach (var item in Cart)
                //{
                //    item.OrderId = newOrder.OrderId;
                //    _orderDetailRepository.AddOrderDetail(item);
                //}

                HttpContext.Session.Remove("cart");
                return RedirectToPage("../HomePage");
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "Checkout failed";
                return Page();
            }
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