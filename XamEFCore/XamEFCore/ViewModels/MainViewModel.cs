﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using XamEFCore.Models;
using XamEFCore.Services;

namespace XamEFCore.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MenuItemViewModel> menu;
        #endregion Attributes

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu
        {
            get { return this.menu; }
            set { SetValue(ref this.menu, value); }
        }
        #endregion Properties

        #region Constructor
        public MainViewModel()
        {
            this.LoadMenu();

            //this.SaveArtistasList();
        }
        #endregion Constructor

        #region Methods
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();

            this.Menu.Clear();
            this.Menu.Add(new MenuItemViewModel { Id = 1, Option = "Crear" });
            this.Menu.Add(new MenuItemViewModel { Id = 2, Option = "Lista de Registros" });
            this.Menu.Add(new MenuItemViewModel { Id = 3, Option = "Eliminar Registros" });
            this.Menu.Add(new MenuItemViewModel { Id = 4, Option = "Editar Registro" });
        }
        #endregion Methods

        /*DBDataAccess<Artista> dataService = new DBDataAccess<Artista>();
        private void SaveArtistasList()
        {
            var artistas = new List<Artista>()
            {
                new Artista{ Nombre = "Maroon 5" },
                new Artista{ Nombre = "Jason Upton" },
                new Artista{ Nombre = "Twenty one Pilot" }
            };

            dataService.SaveList(artistas);
        }*/
    }
}
