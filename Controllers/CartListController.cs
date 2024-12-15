using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class CartListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CartList
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CartItems.Include(c => c.Cart).Include(c => c.Product);
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
        
        // [ValidateAntiForgeryToken] 
        [Authorize]
        public async Task<IActionResult> Create(int productId)
        {
            //check if user has a cart
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == User.Identity.Name && !c.IsCheckedOut);
            
            //if user has no cart, create a new cart
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = User.Identity.Name,
                    IsCheckedOut = false,
                    SubTotal = 0,
                    Discount = 0,
                    TotalTax = 0,
                    Total = 0
                };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }
            
            //check if product is there in productId
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            
            //check if product is already in cart
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.CartId == cart.Id && c.ProductId == productId);
            
            //if product is already in cart, increase quantity by 1
            if (cartItem != null)
            {
                cartItem.Quantity++;
                _context.Update(cartItem);
            }
            else
            {
                //if product is not in cart, add product to cart
                cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = 1,
                    ItemTax = product.Price * 0.1m
                };
                _context.CartItems.Add(cartItem);
            }
            
            //update cart total 
            cart.SubTotal += product.Price;
            
            //update cart total tax
            cart.TotalTax += product.Price * 0.1m;
            
            //update cart total
            cart.Total = cart.SubTotal + cart.TotalTax + cart.ShippingFee;  
            
            _context.Update(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

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
    }
}
