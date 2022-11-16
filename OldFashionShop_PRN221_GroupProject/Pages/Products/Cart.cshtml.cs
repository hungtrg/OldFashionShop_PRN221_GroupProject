using BusinessLayer.Repository;
using DataLayer.Models;
using DataLayer.RedirectModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
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

        public int FinalAmount { get; set; }
        public CartModel(IProductRepository productRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public void OnGet()
        {
            Cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (Cart != null)
            {
                foreach (var item in Cart)
                {
                    var product = _productRepository.GetProductById((int) item.ProductId);
                    FinalAmount += (int) product.Price * (int) item.Quantity;
                }
            }
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
                    Thumb = product.Thumb,
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
                        Thumb = product.Thumb,
                        Total = product.Price * quantity,
                        ProductId = product.ProductId,
                    });
                }
                else
                {
                    var newQuantity = cart[index].Quantity + quantity;
                    var newTotal = product.Price * newQuantity;
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
                var newTotal = product.Price * newQuantity;
                cart[index].Quantity = newQuantity;
                cart[index].Total = newTotal;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            Cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (Cart != null)
            {
                foreach (var item in Cart)
                {
                    var products = _productRepository.GetProductById((int)item.ProductId);

                    FinalAmount += (int)products.Price * (int)item.Quantity;
                }
            }
            return Page();
        }

        public IActionResult OnPostCheckOut()
        {
            var accountId = HttpContext.Session.GetString("ACCOUNT_ID");
            if (accountId == null)
            {
                return RedirectToPage("../LoginPage");
            }
            Cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            //var accountId = int.Parse(HttpContext.Session.GetString("ACCOUNT_ID"));
            var order = new Order()
            {
                Status = 1,
                OrderDate = DateTime.Now,
                OrderDetails = Cart,
                Deleted = false,
                AccountId = int.Parse(accountId),
                Note = "",
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
                    if (cart[i].ProductId.Equals(id))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public IActionResult OnPostDelete(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            var product = _productRepository.GetProductById(id);

            var index = Exists(cart, id);
            if (index == -1)
            {
                return NotFound();
            }
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            Cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            //return RedirectToPage("Cart");
            return Page();
        }

    }
}