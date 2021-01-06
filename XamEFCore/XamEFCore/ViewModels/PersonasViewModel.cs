using System.Text;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XamEFCore.Models;
using XamEFCore.Services;

namespace XamEFCore.ViewModels
{
    public class PersonasViewModel : BaseViewModel
    {
        #region Services
        //private readonly DBDataAccess<Artista> dataServiceArtistas;
        private readonly DBDataAccess<Persona> dataServicePersonas;
        #endregion Services

        #region Attributes
        //private ObservableCollection<Artista> artistas;
        private ObservableCollection<Persona> personas;
        //private Artista selectedArtista;
        /*private string titulo;
        private double precio;
        private int anio;*/
        private string nombre;
        private DateTime nacimiento;
        private int edad;
        private Boolean profesional;
        #endregion Attributes

        #region Properties
        /*public ObservableCollection<Artista> Artistas
        {
            get { return this.artistas; }
            set { SetValue(ref this.artistas, value); }
        }*/

        public ObservableCollection<Persona> Personas
        {
            get { return this.personas; }
            set { SetValue(ref this.personas, value); }
        }

        /*public Artista SelectedArtista
        {
            get { return this.selectedArtista; }
            set { SetValue(ref this.selectedArtista, value); }
        }*/

        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public DateTime Nacimiento
        {
            get { return this.nacimiento; }
            set { SetValue(ref this.nacimiento, value); }
        }

        public int Edad
        {
            get { return this.edad; }
            set { SetValue(ref this.edad, value); }
        }
        public Boolean Profesional
        {
            get { return this.profesional; }
            set { SetValue(ref this.profesional, value); }
        }
        #endregion Properties

        #region Constructor
        public PersonasViewModel()
        {
            //this.dataServiceArtistas = new DBDataAccess<Artista>();
            this.dataServicePersonas = new DBDataAccess<Persona>();

            //this.CreateArtistas();

            //this.LoadArtistas();
            this.LoadPersonas();

            //this.Edad = DateTime.Now.Year;
            this.Edad = 0;

        }
        #endregion Constructor

        #region Commands
        public ICommand CreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var newPersona = new Persona()
                    {
                        //ArtistaID = this.SelectedArtista.ArtistaID,
                        Nombre = this.Nombre,
                        Nacimiento = this.Nacimiento,
                        Edad = this.Edad,
                        Profesional = this.Profesional
                    };

                    if (newPersona != null)
                    {
                        if (this.dataServicePersonas.Create(newPersona))
                        {
                            await Application.Current.MainPage.DisplayAlert("Operación Exitosa",
                                                                            $"Nombre de persona: {this.Nombre} " +
                                                                            $"creado correctamente en la base de datos",
                                                                            "Ok");

                            //this.SelectedArtista = null;
                            this.Nombre = string.Empty;
                            this.Nacimiento = DateTime.Now;
                            this.Edad = 0;
                            this.Profesional = true;
                        }

                        else
                            await Application.Current.MainPage.DisplayAlert("Operación Fallida",
                                                                            $"Error al crear el Persona en la base de datos",
                                                                            "Ok");
                    }
                });
            }
        }
        #endregion Commands
        // de aqui para abao falta corregir
        #region Methods
       /* private void LoadArtistas()
        {
            var artistasDB = this.dataServiceArtistas.Get().ToList() as List<Artista>;
            this.Artistas = new ObservableCollection<Artista>(artistasDB);
        }*/

        private void LoadPersonas()
        {
            /*var personasDB = this.dataServicePersonas.Get(null, null, "").ToList() as List<Persona>;
            this.Personas = new ObservableCollection<Persona>(personasDB);*/
            var personasDB = this.dataServicePersonas.Get().ToList() as List<Persona>;
            this.Personas = new ObservableCollection<Persona>(personasDB);
        }

        /*private void CreateArtistas()
        {
            var artistas = new List<Artista>()
            {
                new Artista { Nombre = "Ricardo Arjona" },
                new Artista { Nombre = "Kalimba" },
                new Artista { Nombre = "Luis Miguel" }
            };

            this.dataServiceArtistas.SaveList(artistas);
        }*/
        #endregion Methods
    }
}

