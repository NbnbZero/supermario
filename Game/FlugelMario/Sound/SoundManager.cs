using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Sound
{
    class SoundManager
    {
        private SoundEffect marioDyingSound;
        private SoundEffect coinSound;
        private SoundEffect oneUpSound;
        private SoundEffect powerUpAppearsSound;
        private SoundEffect powerUpSound;
        private SoundEffect gameOverSound;
        private SoundEffect brickBreakSound;
        private SoundEffect stompSound;

        private SoundEffect bumpSound;
        private SoundEffect pipeSound;
        private SoundEffect smallJumpSound;
        private SoundEffect superJumpSound;
        private SoundEffect warningSound;

        private Song overworldSong;
        private Song starSong;

        private static SoundManager instance = new SoundManager();

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundManager()
        {

        }

        public void LoadAllSounds(ContentManager content)
        {
            marioDyingSound = content.Load<SoundEffect>("v_mariodying");
            coinSound = content.Load<SoundEffect>("v_coin");
            oneUpSound = content.Load<SoundEffect>("v_1-up");
            powerUpAppearsSound = content.Load<SoundEffect>("v_powerupApp");
            powerUpSound = content.Load<SoundEffect>("v_powerup");
            gameOverSound = content.Load<SoundEffect>("v_gameover");
            stompSound = content.Load<SoundEffect>("v_stomp");
            brickBreakSound = content.Load<SoundEffect>("v_breakblock");
            bumpSound = content.Load<SoundEffect>("v_bump");
            pipeSound = content.Load<SoundEffect>("v_pipe");
            smallJumpSound = content.Load<SoundEffect>("v_jump-small");
            superJumpSound = content.Load<SoundEffect>("v_jump-super");
            warningSound = content.Load<SoundEffect>("v_warning");
            overworldSong = content.Load<Song>("v_overworld");
            starSong = content.Load<Song>("v_starmario");
        }
        public void PlayMarioDyingSound()
        {
            MediaPlayer.Stop();
            marioDyingSound.Play();
        }
        public void PlayCoinSound()
        {
            coinSound.Play();
        }
        public void Play1UpSound()
        {
            oneUpSound.Play();
        }
        public void PlayPowerUpAppearsSound()
        {
            powerUpAppearsSound.Play();
        }
        public void PlayPowerUpSound()
        {
            powerUpSound.Play();
        }
        public void PlayGameOverSound()
        {
            gameOverSound.Play();
        }
        public void PlayStompSound()
        {
            stompSound.Play();
        }
        public void PlayBrickBreakSound()
        {
            brickBreakSound.Play();
        }
        public void PlayBumpSound()
        {
            bumpSound.Play();
        }
        public void PlayPipeSound()
        {
            pipeSound.Play();
        }
        public void PlaySmallJumpSound()
        {
            smallJumpSound.Play();
        }
        public void PlaySuperJumpSound()
        {
            superJumpSound.Play();
        }
 
        public void PlayWarningSound()
        {
            warningSound.Play();
        }
        public void StopAllSound()
        {
            MediaPlayer.Stop();

        }
        public void PlayStageClearSound()
        {
            throw new NotImplementedException();
        }

        public void PlayOverWorldSong()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(overworldSong);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayStarSong()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(starSong);
        }
    }
}
