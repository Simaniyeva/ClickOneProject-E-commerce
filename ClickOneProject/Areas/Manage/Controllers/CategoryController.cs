﻿
using IResult = BusinessLogicLayer.Utilities.Results.IResult;

namespace ClickOneProject.Areas.Manage.Controllers;

[Area("Manage")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        IDataResult<List<CategoryGetDto>> result = await _categoryService.GetAllAsync(true);
        return View(result);
    }

    public async Task<IActionResult> Get(int id)
    {
        IDataResult<CategoryGetDto> result = await _categoryService.GetByIdAsync(id);
        return View(result);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryPostDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        IResult result = await _categoryService.CreateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        IDataResult<CategoryGetDto> result = await _categoryService.GetByIdAsync(id);
        return View(_mapper.Map<CategoryUpdateDto>(result.Data));
    }
    [HttpPost]
    public async Task<IActionResult> Update(CategoryUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        await _categoryService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        CategoryGetDto result = (await _categoryService.GetByIdAsync(id)).Data;
        if (result == null) { return RedirectToAction(nameof(Index)); }
        await _categoryService.SoftDeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Recover(int id)
    {
        CategoryGetDto result = (await _categoryService.GetByIdAsync(id)).Data;
        if (result == null) { return RedirectToAction(nameof(Index)); }
        await _categoryService.RecoverByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> HardDelete(int id)
    {
        CategoryGetDto result = (await _categoryService.GetByIdAsync(id)).Data;
        if (result == null) { return RedirectToAction(nameof(Index)); }
        await _categoryService.HardDeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }

}

