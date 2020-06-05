using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
//using PropertyChanged;

namespace Fasetto.World.Core
{

    /// <summary>
    /// A base view model that first fired Property Changed events as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// This event is fired when any child property changes it's value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged=(sender,e)=> { };


        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Runs a command if the updating flag is not set.
        /// If the flag is true (indicating the function is already running) then the action is not run.
        /// If the flag is false (indicating no running function) then the action is run.
        /// Once the action is finished if it was run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">The boolean property defining if the commmand is running</param>
        /// <param name="action">The command to run if the command is not already running</param>
        /// <returns></returns>
        protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag,Func<Task> action)
        {
            //Check if the flag property is true (meaning the function is already running)
            if (updatingFlag.GetPropertyValue())
                return;

            //Set the property to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                //Run the passed in action
                await action();
            }
            finally
            {
                //Set the property flag back to false now it's finished
                updatingFlag.SetPropertyValue(false);
            }
        }

    }
}
