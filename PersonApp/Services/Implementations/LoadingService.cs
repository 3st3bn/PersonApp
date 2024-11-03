using Mopups.Interfaces;
using Mopups.Services;
using PersonApp.Popup;
using PersonApp.Services.Interfaces;

namespace MovieApp.Services.Implementations
{
    public class LoadingService : ILoadingService
    {
        //private bool _isShowing;

        //public async Task Show(string message = "")
        //{
        //    if (!_isShowing)
        //    {
        //        _isShowing = true;
        //        await Application.Current.MainPage.DisplayAlert("Cargando", message, "OK");
        //    }
        //}

        //public async Task Hide()
        //{
        //    if (_isShowing)
        //    {
        //        _isShowing = false;
        //    }
        //}
        private readonly IPopupNavigation _popupNavigation;


        public LoadingService()
        {
            _popupNavigation = MopupService.Instance;

        }
        public async Task Hide()
        {
            await _popupNavigation.PopAsync(true);

        }

        public async Task Show(string message = "Loading...")
        {
            try
            {
                await _popupNavigation.PushAsync(new LoadingPopup(message), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
