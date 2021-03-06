﻿using KuchaMobile.Logic;
using KuchaMobile.UI;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KuchaMobile
{
    public class App : Application
    {
        public App()
        {
        }

        /// <summary>
        /// This is the App Start in the shared project. Will be called by Android/iOS Project
        /// </summary>
        protected override void OnStart()
        {
            Task.Run(() => Kucha.LoadPersistantData());

            MainPage = new LoadingScreenUI();
        }

        /// <summary>
        /// Called from LoadingScreen once the local database has been loaded
        /// </summary>
        public void LoadingPersistantDataFinished()
        {
            if (!Kucha.KuchaContainerIsValid() || !Internal.Connection.HasLegitSessionID())
                MainPage = new LoginPage();
            else
                MainPage = new MainPage();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}