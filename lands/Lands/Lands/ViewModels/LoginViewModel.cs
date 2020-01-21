using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;

namespace Lands.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

       

        #region Attributes
        //aqui vamos a llamar a los objetos que ocupamos que refresquen en el view
        //esta es una propiedad privada y para diferenciar usamos el nombre minuscula
        private string password;
        private bool isRunning;
        private bool isEnabled;


        #endregion


        #region Properties

        public string Email 
        { get; set; }

        public string Password 
            //todo esto nos sirve para refrescar las propiedades en tiempo de ejecucion
            //este get, set nos llama a la clase BaseViewModel para refrescar los componentes
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning 
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }


        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsRemember
        { get; set; }
        #endregion


        #region Constructor

        public LoginViewModel()
        {
            this.IsRemember = true;
            this.IsEnabled = true;
        }


        #endregion



        #region Commands
        public ICommand LoginCommand 
        {
            get 
            {
                return new RelayCommand(Login);
                //Cambiamos el nombre a Login para que no fuera el mismo del boton LoginCommand
                //Necesita ser llamado en algun metodo que creamos abajo  
                //hay que importar la libreria using GalaSoft.MvvmLight.Command; para este comando: RelayCommand
            }

        }

       

        private async void Login()
        { //Aqui generamos el metodo para la sentancia login de arriba 
          // El metodo async (asincrono) se usa para generar pausas durante la ejecucion del codigo 
          // Se usa para que el hilo de ejecucion no se bloquee mientras se estan haciendo otras cosas en background 
          // En un metodo normal, la computadora se bloquea en cada statement hasta que se complete correctamente antes de seguir con 
          //la siguiente sentencia 
          // basicamente la computadora ejecuta las instrucciones en forma de fila: una detras de otra. 
          // Si queremos que haga otra accion mientras se ejecuta otra a la misma vez hay que usar el async.
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/


            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter your Password",
                    "Accept");
                
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;


            if (this.Email != "patitos3" || this.Password !="123" )
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Your credentials are incorrect",
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert(
                    "OK",
                    "Todo bien",
                    "Accept");
            return;

        }

        #endregion

    }
}
