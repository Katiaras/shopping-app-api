using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingApp.API.Data;
using ShoppingApp.API.Models;

namespace ShoppingApp.API.Controllers {
  [ApiController]
  [Route ("[controller]")]
  public class ShoppingListController : ControllerBase {

    private readonly ILogger<ShoppingListController> _logger;
    private readonly DataContext _context;

    public ShoppingListController (ILogger<ShoppingListController> logger, DataContext context) {
      this._context = context;
      _logger = logger;
    }

    [HttpGet]
    public async  Task<IActionResult> GetShoppingLists () {
        var shoppingLists = await _context.ShoppingLists.ToListAsync();

        return Ok(shoppingLists);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetShoppingList (int id) {
        _logger.LogDebug(id.ToString());
        var shoppingList = await _context.ShoppingLists
            .FirstOrDefaultAsync(sl => sl.Id == id);

        if(shoppingList == null) {
          string message = $"Couldn't find the List with Id {id}";
          _logger.LogError(message);
          return NotFound(message);
        }
        return Ok(shoppingList);
    }
  }
}