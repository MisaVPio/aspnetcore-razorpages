using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.IO;


namespace AspNetCoreWebApp
{
    public class AppUtils
    {

        public static async Task ProcessarArquivoDeImagem(int idProduto, IFormFile imagemProduto, IWebHostEnvironment whe)
        {
            var ms = new MemoryStream();
            await imagemProduto.CopyToAsync(ms);

            ms.Position = 0;
            var img = await Image.LoadAsync(ms);
            JpegEncoder jpegEnc = new JpegEncoder();
            img.SaveAsJpeg(ms, jpegEnc);
            ms.Position = 0;
            img = await Image.LoadAsync(ms);
            ms.Close();
            ms.Dispose();

            var tamanho = img;
            Rectangle retanguloCorte;
            if (tamanho.Size.Width > tamanho.Size.Height)
            {
                float x = (tamanho.Size.Height - tamanho.Size.Width) / 2.0F;
                retanguloCorte = new Rectangle((int)x, 0, tamanho.Size.Height, tamanho.Size.Height);
            }
            else
            {
                float y = (tamanho.Size.Height - tamanho.Size.Width) / 2.0F;
                retanguloCorte = new Rectangle(0, (int)y, tamanho.Size.Width, tamanho.Size.Width);
            }

            img.Mutate(img => img.Crop(retanguloCorte));

            var caminhoArquivoImagem = Path.Combine(whe.WebRootPath,
                "img\\produto", idProduto.ToString("D5")+".jpg");
            await img.SaveAsync(caminhoArquivoImagem);  
        }
    }
}