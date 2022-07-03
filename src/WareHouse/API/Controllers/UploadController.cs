namespace LasMarias.WareHouse.Controllers;

using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Net;    
using System.Net.Http;    
using System.Web;    
using LasMarias.WareHouse.Domain.Repositories;
using Orun;

[Route("upload/")]
public partial class UploadController : Controller
{
    private readonly IProductPhotoRepository _repository;

    public UploadController(IProductPhotoRepository repository)
    {
        _repository = repository.IsNullOrEmpty("Repository could not be null or empty");
    }

    [HttpPost("product_photos")]
    public async Task < IActionResult > ImportProductPhoto([FromForm] IFormFile file, [FromForm]long productId) 
    {
        // TODO: finish the upload file endpoint
        string name = file.FileName;
        string extension = Path.GetExtension(file.FileName);
        //read the file
        using(var memoryStream = new MemoryStream()) {
            file.CopyTo(memoryStream);
        }
        //do something with the file here
        return Ok();
    }
}