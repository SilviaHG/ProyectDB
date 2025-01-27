using System.Timers;
using System;

namespace ProyectDB.Presentation.Components.Pages
{
    public class Debouncer<T>
    {
        private readonly System.Timers.Timer _timer;


        private readonly Action<T> _action;
        private T _lastValue;  // Variable para almacenar el último valor

        public Debouncer(Action<T> action, int delayMilliseconds)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _timer = new System.Timers.Timer(delayMilliseconds)
            {
                AutoReset = false  // Solo ejecuta una vez después de cada retraso
            };
            _timer.Elapsed += OnTimerElapsed;
        }

        public void Trigger(T value)
        {
            _lastValue = value;  // Guardar el último valor recibido
            if (_timer.Enabled)
            {
                _timer.Stop();  // Detener el temporizador si ya estaba corriendo
            }
            _timer.Start();  // Iniciar el temporizador
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _action(_lastValue);  // Ejecutar la acción con el último valor después del retraso
        }
    }
}
