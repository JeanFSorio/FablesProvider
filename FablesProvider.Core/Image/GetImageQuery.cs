using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FablesProvider.Core.Image;

public class GetImageQuery ()
{
    public IActionResult Handle(string imageName){
        var imagePath = $"D:/pessoal/{imageName}";

        if (!File.Exists(imagePath))
        {
            throw new FileNotFoundException("deu ruim");
        }

        var imageBytes = System.IO.File.ReadAllBytes(imagePath);

        return new FileContentResult(imageBytes, "image/jpeg"); // Adjust the content type based on your image format

        //return File(imageBytes, "image/jpeg"); // Adjust the content type based on your image format

      
    }

    public Byte[] GetImageByteArray(string imageName) {
        var imagePath = $"D:/pessoal/{imageName}";
        var imageBytes = System.IO.File.ReadAllBytes(imagePath);
        return imageBytes;
    }
}

