
using Microsoft.AspNetCore.Mvc.Rendering;
using IResult = BusinessLogicLayer.Utilities.Results.IResult;

namespace ClickOneProject.Areas.Manage.Controllers;

[Area("Manage")]
public class SubCategoryController : Controller
{
    private readonly ISubCategoryService _subCategoryService;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public SubCategoryController(ISubCategoryService subCategoryService,ICategoryService categoryService, IMapper mapper)
    {
        _subCategoryService = subCategoryService;
        _categoryService = categoryService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        IDataResult<List<SubCategoryGetDto>> result = await _subCategoryService.GetAllAsync(true);
        return View(result);
    }

    public async Task<IActionResult> Get(int id)
    {
        IDataResult<SubCategoryGetDto> result = await _subCategoryService.GetByIdAsync(id);
        return View(result);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await GetViewBags();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SubCategoryPostDto dto)
    {
        if (!ModelState.IsValid)
        {
            await GetViewBags();
            return View(dto);
        }
        IResult result = await _subCategoryService.CreateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        await GetViewBags();
        IDataResult<SubCategoryGetDto> result = await _subCategoryService.GetByIdAsync(id);
        //await _subCategoryService.UpdateAsync(SubCategoryUpdateDto.Id, subCategoryUpdateDto.subCategoryPostDto);
        return View(_mapper.Map<SubCategoryUpdateDto>(result.Data));
    }
    [HttpPost]
    public async Task<IActionResult> Update(SubCategoryUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            await GetViewBags();
            return View(dto);
        }
        await _subCategoryService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        SubCategoryGetDto result = (await _subCategoryService.GetByIdAsync(id)).Data;
        if (result == null) { return RedirectToAction(nameof(Index)); }
        await _subCategoryService.SoftDeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Recover(int id)
    {
        SubCategoryGetDto result = (await _subCategoryService.GetByIdAsync(id)).Data;
        if (result == null) { return RedirectToAction(nameof(Index)); }
        await _subCategoryService.RecoverByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> HardDelete(int id)
    {
        SubCategoryGetDto result = (await _subCategoryService.GetByIdAsync(id)).Data;
        if (result == null) { return RedirectToAction(nameof(Index)); }
        await _subCategoryService.HardDeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }



    #region Private Methods
    private async Task GetViewBags()
    {
        IDataResult<List<CategoryGetDto>> categories = await _categoryService.GetAllAsync(false);
        ViewBag.Categories = categories.Data.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        });
    }
    #endregion

}