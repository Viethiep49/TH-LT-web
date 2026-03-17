using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using WebsiteBanHang.Models;
using WebsiteBanHang.Repositories.Interfaces;
using WebsiteBanHang.Utility;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileStorageService _fileStorageService;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IFileStorageService fileStorageService)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        public IActionResult Add()
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    product.ImageUrl = await _fileStorageService.SaveFileAsync(imageUrl, "images");
                }

                await _productRepository.AddAsync(product);
                return RedirectToAction("Index");
            }
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product, IFormFile imageUrl)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = await _productRepository.GetByIdAsync(product.Id);
                if (existingProduct == null) return NotFound();

                if (imageUrl != null)
                {
                    // Delete old image if exists
                    _fileStorageService.DeleteFile(existingProduct.ImageUrl);
                    existingProduct.ImageUrl = await _fileStorageService.SaveFileAsync(imageUrl, "images");
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryId = product.CategoryId;

                await _productRepository.UpdateAsync(existingProduct);
                return RedirectToAction("Index");
            }
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
