using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
#if !NETFX_CORE
using Uno.Foundation;
#endif

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WasmTricks
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        async void OnVoicesButtonClicked(object sender, RoutedEventArgs e)
        {
#if __WASM__
            var result = await WebAssemblyRuntime.InvokeAsync("GetVoicesPromise()");
            _textBlock.Text = result;
#endif
        }

        async void OnLibTestButtonClicked(object sender, RoutedEventArgs e)
        {
#if __WASM__
            var result = WasmTricksLib.Test.PerformLibTest();
            _textBlock.Text = result;
#endif
        }

        async void OnHtml2CanvasButtonClicked(object sender, RoutedEventArgs e)
        {
#if __WASM__
            var result = WasmTricksLib.Test.PerformHtml2Canvas();
            _textBlock.Text = result;
#endif
        }
    }
}
