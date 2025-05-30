using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ClientProduct.ViewModels;
using ClientProduct.Views;
using ClientProductCore.DataAccess.SqlServer;
using ClientProductCore.Domain.Interfaces;


namespace ClientProduct
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
           IUnitOfWork db = new SqlUnitOfWork("localhost", "ClientProduct");
            Dispatcher.UnhandledException += OnUnhandledException;
           var mainPageViewModel = new MainPageViewModel(db);
            var mainPage = new MainPage();
           mainPage.DataContext = mainPageViewModel;
           mainPage.Show();
        }

        private void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            MessageBox.Show("Что-то пошло не так, попробуйте еще раз.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }
    }
}
