using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using upload_img.Tools;

public class PostDTO
{
	public int UserId { get; set; }

    [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg", ".webp" }, ErrorMessage = "Os arquivos \"{}\" possuem uma extensão invalida.\nSó são permitidos arquivos pdf, jpg, png ou gif”")]
    public IFormFile Img { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public int TagId { get; set; }
}
