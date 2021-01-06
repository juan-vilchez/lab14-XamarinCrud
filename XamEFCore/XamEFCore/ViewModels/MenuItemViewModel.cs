using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XamEFCore.Views;
using XamEFCore.Models;
using XamEFCore.Services;

namespace XamEFCore.ViewModels
{
    public class MenuItemViewModel
    {
        #region Attributes
        public int Id { get; set; }
        public string Option { get; set; }
        public string Icon { get; set; }
        #endregion Attributes

        #region Commands
        public ICommand SelectMenuItemCommand
        {
            get
            {
                return new Command(SelectMenuItemExecute);
            }
        }
        #endregion Commands

        #region Methods
        private void SelectMenuItemExecute()
        {
            /*if (this.Id == 1)
                Application.Current.MainPage.Navigation.PushAsync(new PersonaPage());

            else
                Application.Current.MainPage.Navigation.PushAsync(new PersonasPage());*/
            if (this.Id == 1)
                Application.Current.MainPage.Navigation.PushAsync(new PersonaPage());
            if (this.Id == 2)
                Application.Current.MainPage.Navigation.PushAsync(new PersonasPage());
            if (this.Id == 3)
                DelePersonaList();
            if (this.Id == 4)
                Application.Current.MainPage.Navigation.PushAsync(new EditPersonaPage());
        }

        DBDataAccess<Persona> dataService = new DBDataAccess<Persona>();
        private void DelePersonaList()
        {
            var Personass = dataService.Get().ToList();
            dataService.DeleteList(Personass);
        }

        #endregion Methods
    }
}
