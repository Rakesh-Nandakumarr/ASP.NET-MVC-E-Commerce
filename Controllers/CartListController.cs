using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.DTO;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class CartListController : Controller
    {
        private readonly ApplicationDbContext _context;
        // Identity
        private readonly UserManager<IdentityUser> _userManager;

        public CartListController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CartList
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CartItems.Include(c => c.Cart).Include(c => c.Product).Where(c => c.Cart.UserId == _userManager.GetUserId(User));
            ViewBag.isAddressOrContactEmpty = string.IsNullOrEmpty(_context.Carts.FirstOrDefault(c => c.UserId == _userManager.GetUserId(User) && !c.IsCheckedOut)?.Address) || string.IsNullOrEmpty(_context.Carts.FirstOrDefault(c => c.UserId == _userManager.GetUserId(User) && !c.IsCheckedOut)?.ContactNumber);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CartList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .Include(c => c.Cart)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // GET: CartList/addToCart/5 custom route
        // [Authorize]
        // public IActionResult Create(int productId)
        // {
        //     //
        //     ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id");
        //     ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
        //     return View();
        // }
        //
        // // POST: CartList/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //
        
        [Authorize]
        public async Task<IActionResult> Create(int productId)
        {
            // Check if user has a cart
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == _userManager.GetUserId(User) && !c.IsCheckedOut);

            // If user has no cart, create a new cart
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = _userManager.GetUserId(User),
                };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            // Check if product exists
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            // Check if product is already in cart
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.CartId == cart.Id && c.ProductId == productId);

            // If product is already in cart, increase quantity by 1
            if (cartItem != null)
            {
                cartItem.Quantity++;
                _context.Update(cartItem);
            }
            else
            {
                // If product is not in cart, add product to cart
                cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = 1,
                    ItemTax = product.Price * 0.1m
                };
                _context.CartItems.Add(cartItem);
            }

            // Update cart total
            cart.SubTotal += product.Price;

            // Update cart total tax
            cart.TotalTax += product.Price * 0.1m;

            // Update cart total
            cart.Total = cart.SubTotal + cart.TotalTax + cart.ShippingFee;

            _context.Update(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] UpdateQuantityRequest request)
        {
            var cartItem = _context.CartItems
                .Include(ci => ci.Product)
                .FirstOrDefault(ci => ci.Id == request.CartId);

            if (cartItem == null)
                return Json(new { success = false });
            // quantity should be less than product stock
            if (cartItem.Quantity + request.Change > cartItem.Product.Stock)
                return Json(new { success = false });

            // Update quantity and handle edge cases (e.g., minimum quantity = 1)
            cartItem.Quantity = Math.Max(1, cartItem.Quantity + request.Change);

            _context.SaveChanges();

            // Calculate totals
            var itemTotal = (cartItem.Product.Price * cartItem.Quantity) + cartItem.ItemTax;
            var grandTotal = _context.CartItems.Sum(ci => (ci.Product.Price * ci.Quantity) + ci.ItemTax);

            return Json(new 
            { 
                success = true, 
                newQuantity = cartItem.Quantity, 
                itemTotal = itemTotal.ToString("C"), 
                grandTotal = grandTotal.ToString("C") 
            });
        }


        // GET: CartList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", cartItem.CartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", cartItem.ProductId);
            return View(cartItem);
        }

        // POST: CartList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CartId,ProductId,Quantity,ItemTax")] CartItem cartItem)
        {
            if (id != cartItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartItemExists(cartItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", cartItem.CartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", cartItem.ProductId);
            return View(cartItem);
        }

        // GET: CartList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .Include(c => c.Cart)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // POST: CartList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartItemExists(int id)
        {
            return _context.CartItems.Any(e => e.Id == id);
        }

        public IActionResult UpdateAddress(UpdateAddressRequest request)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == _userManager.GetUserId(User) && !c.IsCheckedOut);
            if (cart == null)
                return Json(new { success = false });

            cart.Address = request.Address;
            cart.ContactNumber = request.ContactNumber;

            _context.SaveChanges();

            ViewBag.Address = cart.Address;
            ViewBag.ContactNumber = cart.ContactNumber;
            return RedirectToAction(nameof(Index));
        }
    }
}
