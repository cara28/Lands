using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// Copiar y pegar esta clase
//Es una clase generica para poder refrescar los componentes en tiempo real 
//mediante el INotifyPropertyChanged

//En la clase que queramos refrescar los componentes, tenemos que crearle el atributo privado
//y la propiedad con su get,set de esta forma: get { return this.password; } set { SetValue(ref this.password, value); }
//Tambien recordar heredar esta misma clase en la clase que queramos implementar: public class LoginViewModel : BaseViewModel



namespace Lands.ViewModels
{
   public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }


        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }
            backingField = value;
            OnPropertyChanged(propertyName);
        }

        


    }
}
