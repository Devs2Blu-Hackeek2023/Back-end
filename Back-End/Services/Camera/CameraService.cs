namespace Back_End.Services.Camera
{
    public class CameraService : ICameraService
    {
        private readonly Random _random;

        public CameraService() { _random = new Random(); }

        private readonly int _minSecs = 300;
        private readonly int _maxSecs = 1200;

        public DateTime SetInicio() { return DateTime.Now; }

        public DateTime SetFinal()
        {
            DateTime inicio = SetInicio();
            DateTime final = inicio.AddSeconds(_random.Next(_minSecs, _maxSecs + 1));

            return final;
        }
    }
}
