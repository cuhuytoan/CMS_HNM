using AutoMapper;
using Blazored.Toast.Services;
using CMS.Common;
using CMS.Data.ModelDTO;
using CMS.Data.ModelEntity;
using CMS.Data.ModelFilter;
using CMS.Website.Areas.Admin.Pages.Shared.Components;
using CMS.Website.Logging;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using Telerik.Blazor.Components.Editor;
using FontFamily = Telerik.Blazor.Components.Editor.FontFamily;
namespace CMS.Website.Areas.Admin.Pages.Advertising
{
    public partial class Edit : IDisposable
    {
        #region Inject

        [Inject]
        private IMapper Mapper { get; set; }

        [Inject]
        private ILoggerManager Logger { get; set; }

        [Inject]
        private UserManager<IdentityUser> UserManager { get; set; }

        #endregion Inject

        #region Parameter

        

        public string PreviewImage { get; set; }
        public List<int> SelectedCateValue { get; set; } = new List<int>();
        public List<string> SelectedCateName { get; set; } = new List<string>();
        private List<string> imageDataUrls = new List<string>();

        public IReadOnlyList<IBrowserFile> MainImages { get; set; }
        string outMessage = "";
        private bool isCropMainImage { get; set; }

        // setup upload endpoints
        public string SaveUrl => ToAbsoluteUrl("api/upload/save");

        public string RemoveUrl => ToAbsoluteUrl("api/upload/remove");

        //Modal Crop Image
        protected ImageCropper imageCropperModal { get; set; }


        [CascadingParameter]
        private GlobalModel globalModel { get; set; }

        #endregion Parameter

        #region LifeCycle

        protected override async Task OnInitializedAsync()
        {          
            await InitControl();
            await InitData();
            StateHasChanged();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion LifeCycle

        #region Init

        protected async Task InitControl()
        {
            
        }

        protected async Task InitData()
        {
           
        }

        #endregion Init

        #region Event


        private async Task PostArticle()
        {
           
            NavigationManager.NavigateTo("/Admin/Article");
        }

     
        private async Task InsertImageEditor(InputFileChangeEventArgs e)
        {
            var imageFiles = e.GetMultipleFiles();
            MainImages = imageFiles;
            var format = "image/png";
            foreach (var item in imageFiles)
            {
                var resizedImageFile = await item.RequestImageFileAsync(format, 500, 500);
                var buffer = new byte[resizedImageFile.Size];
                await resizedImageFile.OpenReadStream().ReadAsync(buffer);
                var imageDataUrl = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                article.Content = article.Content + Environment.NewLine + $"<img src=\"{imageDataUrl}\"/>" + Environment.NewLine;
            }
        }

        //Save MainImage
        protected async Task<string> SaveMainImage(int ArticleId, List<string> imageDataUrls)
        {
            string fileName = "noimages.png";
            foreach (var file in imageDataUrls)
            {
                var imageDataByteArray = Convert.FromBase64String(CMS.Common.Utils.GetBase64Image(file));

                var urlArticle = await Repository.Article.CreateArticleURL(ArticleId);
                var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                fileName = String.Format("{0}-{1}.{2}", urlArticle, timestamp, "webp");
                var physicalPath = Path.Combine(_env.WebRootPath, "data/article/mainimages/original");
                ImageCodecInfo jpgEncoder = CMS.Common.Utils.GetEncoder(ImageFormat.Jpeg);

                // Create an Encoder object based on the GUID  
                // for the Quality parameter category.  
                System.Drawing.Imaging.Encoder myEncoder =
                    System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.  
                // An EncoderParameters object has an array of EncoderParameter  
                // objects. In this case, there is only one  
                // EncoderParameter object in the array.  
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                using (MemoryStream ms = new(imageDataByteArray))
                {
                    using Bitmap bm2 = new(ms);
                    bm2.Save(Path.Combine(physicalPath, fileName), jpgEncoder, myEncoderParameters);
                }
                try
                {
                    Utils.EditSize(Path.Combine(_env.WebRootPath, "data/article/mainimages/original", fileName), Path.Combine(_env.WebRootPath, "data/article/mainimages/small", fileName), 500, 500);
                    Utils.EditSize(Path.Combine(_env.WebRootPath, "data/article/mainimages/original", fileName), Path.Combine(_env.WebRootPath, "data/article/mainimages/thumb", fileName), 120, 120);
                }
                catch
                {
                }
            }
            return fileName;
        }

        public string ToAbsoluteUrl(string url)
        {
            return $"{NavigationManager.BaseUri}{url}";
        }

        public void OnSuccess(UploadSuccessEventArgs args)
        {
            foreach (var file in args.Files)
            {
                ArticleAttachFile item = new ArticleAttachFile();
                item.AttachFileName = file.Name;
                item.FileType = file.Extension;
                item.FileSize = file.Size;
                lstAttachFile.Add(item);
            }
        }

        public void OnRemove(UploadEventArgs args)
        {
            foreach (var file in args.Files)
            {
                var itemDel = lstAttachFile.FirstOrDefault(p => p.AttachFileName == file.Name);
                if (itemDel != null)
                {
                    lstAttachFile.Remove(itemDel);
                }
            }
        }

        private async Task DeleteAttachFile(int articleAttachFileId)
        {
            await Repository.Article.ArticleAttachDelete(articleAttachFileId);
            StateHasChanged();
        }

        private void OnCropImage(bool isMainImages)
        {
            isCropMainImage = isMainImages;

            imageCropperModal.Show();
        }

        protected void ConfirmImageCropper(bool isDone)
        {
            if (isDone)
            {
                if (imageCropperModal.ImgData != null)
                {
                    if (isCropMainImage)
                    {
                        article.Image = null;
                        imageDataUrls.Clear();
                        imageDataUrls.Add(imageCropperModal.ImgData);
                    }
                    else
                    {
                        article.Content = article.Content + Environment.NewLine + $"<img src=\"{imageCropperModal.ImgData}\"/>" + Environment.NewLine;
                    }

                    StateHasChanged();
                }
            }
        }


        bool CheckContentHasBase64(string content)
        {

            var regex = new Regex(@"<img src=""(?<data>.*)""");
            var match = regex.Matches(content).ToList();
            if (match.Count > 0)
            {
                return true;
            }
            return false;
        }

        public string UploadImgBase64Content(string imgName, string pathSave, string content)
        {
            var regex = new Regex(@"<img src=""(?<data>.*)""");
            var match = regex.Matches(content).ToList();
            foreach (var file in match)
            {
                if (file.Groups["data"].Value.StartsWith("data:image"))
                {
                    var imageDataByteArray = Convert.FromBase64String(CMS.Common.Utils.GetBase64Image(file.Groups["data"].Value));
                    var urlArticle = imgName;
                    var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                    string fileName = String.Format("{0}-{1}.{2}", urlArticle, timestamp, "webp");
                    var physicalPath = Path.Combine(_env.WebRootPath, pathSave);
                    if (!System.IO.Directory.Exists(physicalPath))
                    {
                        System.IO.Directory.CreateDirectory(physicalPath);
                    }
                    ImageCodecInfo jpgEncoder = CMS.Common.Utils.GetEncoder(ImageFormat.Jpeg);

                    // Create an Encoder object based on the GUID  
                    // for the Quality parameter category.  
                    System.Drawing.Imaging.Encoder myEncoder =
                        System.Drawing.Imaging.Encoder.Quality;

                    // Create an EncoderParameters object.  
                    // An EncoderParameters object has an array of EncoderParameter  
                    // objects. In this case, there is only one  
                    // EncoderParameter object in the array.  
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    using (MemoryStream ms = new(imageDataByteArray))
                    {
                        using Bitmap bm2 = new(ms);
                        bm2.Save(Path.Combine(physicalPath, fileName), jpgEncoder, myEncoderParameters);
                    }
                    content = content.Replace(file.Groups["data"].Value, $"{pathSave}/{fileName}");
                }

            }
            return content;
        }
        #endregion Event
    }
}
