using System;

using System.Threading.Tasks;

using Xamarin.Forms;

using XamariNES.UI.App.UWP;

using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using static XamariNES.UI.App.Pages.ViewModels.EmulatorHomeViewModel;

[assembly: Dependency(typeof(XamariNES.UI.App.UWP.FileService))]
namespace XamariNES.UI.App.UWP
{
    // 3 IFileService "interface realization"
    public class FileService : IFileService
    {
        
        public async Task<Stream> GetImageStreamAsync(string[] filetypes)
        {
            // Create and initialize the FileOpenPicker
            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
            };

            //openPicker.FileTypeFilter.Add(".nes");
            //openPicker.FileTypeFilter.Add(".zip");

            
            int L = filetypes.Length;

            for (int i = 0; i < L; i++)
            {
                openPicker.FileTypeFilter.Add(filetypes[i]);
            }
            

            

            // Get a file and return a Stream
            StorageFile storageFile = await openPicker.PickSingleFileAsync();

            if (storageFile == null)
            {
                return null;
            }

            IRandomAccessStreamWithContentType raStream = await storageFile.OpenReadAsync();
            return raStream.AsStreamForRead();
        }
    }
}