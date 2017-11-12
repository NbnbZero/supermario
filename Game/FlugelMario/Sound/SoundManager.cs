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
        private bool local_mute = false;




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
            if (!local_mute)
            {
                MediaPlayer.Stop();
                marioDyingSound.Play();
            }
            
        }
        public void PlayCoinSound()
        {
            if (!local_mute)
            {
                coinSound.Play();
            }
            
        }
        public void Play1UpSound()
        {
            if (!local_mute)
            {
                oneUpSound.Play();
            }
            
        }
        public void PlayPowerUpAppearsSound()
        {
            if (!local_mute)
            {
                powerUpAppearsSound.Play();
            }
            
        }
        public void PlayPowerUpSound()
        {
            if (!local_mute)
            {
                powerUpSound.Play();
            }
            
        }
        public void PlayGameOverSound()
        {
            if (!local_mute)
            {
                MediaPlayer.Stop();
                gameOverSound.Play();
            }
            
        }
        public void PlayStompSound()
        {
            if (!local_mute)
            {
                stompSound.Play();
            }
        }
        public void PlayBrickBreakSound()
        {
            if (!local_mute)
            {
                brickBreakSound.Play();
            }
            
        }
        public void PlayBumpSound()
        {
            if (!local_mute)
            {
                bumpSound.Play();
            }
            
        }
        public void PlayPipeSound()
        {
            if (!local_mute)
            {
                pipeSound.Play();
            }

        }
        public void PlaySmallJumpSound()
        {
            if (!local_mute)
            {
                smallJumpSound.Play();
            }
            
        }
        public void PlaySuperJumpSound()
        {
            if (!local_mute)
            {superJumpSound.Play();

            }
            
        }

        public void PlayWarningSound()
        {
            if (!local_mute)
            {warningSound.Play();

            }
            
        }
        public void StopAllSound()
        {
            MediaPlayer.Stop();

        }
        public void PlayStageClearSound()
        {
            throw new NotImplementedException();
        }

        public void muteAndUnmute(bool muted)
        {
            if (muted)
            {
                MediaPlayer.Volume = 0.0f;
                local_mute = true;
            }
            else
            {
                MediaPlayer.Volume = 1.0f;
                local_mute = false;
            }
        }
        

        public void PlayOverWorldSong()
        {
            if (!local_mute)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(overworldSong);
                MediaPlayer.IsRepeating = true;
            }
            
        }

        public void PlayStarSong()
        {
            if (!local_mute)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(starSong);
            }
            
        }
    }
}
