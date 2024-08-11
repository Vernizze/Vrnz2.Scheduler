using System.Media;

namespace Vrnz2.Scheduler.Sounds
{
    internal class Player
    {
        #region Enums

        public enum TSound 
        {
            Unknow = 0,
            EventNoritification = 1
        }

        #endregion

        #region Variables

        private static readonly Lazy<Player> _instance = new(() => new Player());

        private Dictionary<TSound, SoundPlayer> _sounds;

        #endregion

        #region Constructors

        private Player() 
        {
            var path = Path.Combine(Consts.AppPath, "Sounds", "event_notification.wav");

            _sounds = new Dictionary<TSound, SoundPlayer> 
            {
                { TSound.EventNoritification, new SoundPlayer(path) }
            };
        }

        #endregion

        #region Attributes

        public static Player Instance => _instance.Value;

        #endregion

        #region Methods

        public void Play(TSound soundType) 
        {
            if (_sounds.TryGetValue(soundType, out SoundPlayer? soundPlayer))
                soundPlayer.Play();
        }

        #endregion
    }
}
