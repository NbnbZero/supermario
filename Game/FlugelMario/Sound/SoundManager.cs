using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;

namespace SuperMario.Sound
{
    class SoundManager
    {
        private SoundEffect marioDyingSound;
        private SoundEffect coinSound;
        private SoundEffect oneUpSound;
        private SoundEffect mushStarSound;
        private SoundEffect powerUpSound;
        private SoundEffect gameOverSound;
        private SoundEffect brickBreakSound;
        private SoundEffect stompSound;

        private SoundEffect bumpSound;
        private SoundEffect pipeSound;
        private SoundEffect smallJumpSound;
        private SoundEffect superJumpSound;
        private SoundEffect warningSound;
        private SoundEffect gameCompleteSound;
        private SoundEffect flagSound;
        private SoundEffect marioScream;
        private Song undergroundSong;
        private Song overworldSong;
        private Song starSong;
        private Song underwaterSound;
        private SoundEffect flash;
        private bool IsMuted = false;

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
            mushStarSound = content.Load<SoundEffect>("v_powerupApp");
            powerUpSound = content.Load<SoundEffect>("v_powerup");
            gameOverSound = content.Load<SoundEffect>("v_gameover");
            stompSound = content.Load<SoundEffect>("v_stomp");
            brickBreakSound = content.Load<SoundEffect>("v_breakblock");
            bumpSound = content.Load<SoundEffect>("v_bump");
            pipeSound = content.Load<SoundEffect>("v_pipe");
            smallJumpSound = content.Load<SoundEffect>("v_jump-small");
            superJumpSound = content.Load<SoundEffect>("v_A");
            warningSound = content.Load<SoundEffect>("v_warning");
            overworldSong = content.Load<Song>("v_theNextEp");
            starSong = content.Load<Song>("v_starmario");
            undergroundSong = content.Load<Song>("v_doudizhu");
            gameCompleteSound = content.Load<SoundEffect>("v_gameComplete");
            flagSound = content.Load<SoundEffect>("v_flag");
            marioScream = content.Load<SoundEffect>("v_AA");
            underwaterSound = content.Load<Song>("My_Jinji");
            flash = content.Load<SoundEffect>("flash" );
;       }
        public void PlayMarioDyingSound()
        {
            if (!IsMuted)
            {
                MediaPlayer.Stop();
                marioScream.Play();
                marioDyingSound.Play();
            }
        }
        public void PlayCoinSound()
        {
            if (!IsMuted)
            {
                coinSound.Play();
            }
        }
        public void Play1UpSound()
        {
            if (!IsMuted)
            {
                oneUpSound.Play();

            }
        }
        public void PlayMushStarSound()
        {
            if (!IsMuted)
            {
                mushStarSound.Play();
            }
        }
        public void PlayPowerUpSound()
        {
            if (!IsMuted)
            {
                powerUpSound.Play();
            }
        }

        public void PlayFlashSound()
        {
            if (!IsMuted)
            {
                flash.Play();
            }
        }
        public void PlayGameOverSound()
        {
                if (!IsMuted)
                {
                    MediaPlayer.Stop();
                    gameOverSound.Play();
                }
        }

        public void PlayStompSound()
        {
            if (!IsMuted)
            {
                stompSound.Play();
            }
        }
        public void PlayBrickBreakSound()
        {
            if (!IsMuted)
            {
                brickBreakSound.Play();
            }
        }
        public void PlayBumpSound()
        {
            if (!IsMuted)
            {
                bumpSound.Play();
            }
        }
        public void PlayPipeSound()
        {
            if (!IsMuted)
            {
                pipeSound.Play();
            }
        }
        public void PlaySmallJumpSound()
        {
            if (!IsMuted)
            {
                smallJumpSound.Play();
            }
        }
        public void PlaySuperJumpSound()
        {
            if (!IsMuted)
            {
                superJumpSound.Play();
            }
        }

        public void PlayWarningSound()
        {
            if (!IsMuted)
            {
                warningSound.Play();
            }
        }
        public void StopAllSound()
        {
            if (!IsMuted)
            {
                MediaPlayer.Stop();
            }
        }
        public void PlayGameCompleteSound()
        {
            if (!IsMuted)
            {
                gameCompleteSound.Play();
            }
        }

        public void muteAndUnmute(bool Muted)
        {
            if (Muted)
            {
                MediaPlayer.Pause();
                IsMuted = true;
            }
            else
            {
                MediaPlayer.Resume();
                IsMuted = false;
            }
        }
        

        public void PlayOverWorldSong()
        {
            if (!IsMuted)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(overworldSong);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayStarSong()
        {
            if (!IsMuted)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(starSong);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayFlagSong()
        {
            if (!IsMuted)
            {
                flagSound.Play();
            }
        }

        public void PlayUndergroundSong()
        {
            if (!IsMuted)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(undergroundSong);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayUnderwaterSong()
        {
            if (!IsMuted)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(underwaterSound);
                MediaPlayer.IsRepeating = true;
            }
        }
    }
}
