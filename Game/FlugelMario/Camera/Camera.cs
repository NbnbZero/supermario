using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using System.Collections.ObjectModel;
using SuperMario.SpriteFactories;
using SuperMario.Interfaces;

namespace FlugelMario
{
    public class Camera
    {
        public static Collection<int> LimitationList { get; } = new Collection<int>();
        private static int centerOfScreen = 240;
        private static int centerOfCamera = 240;
        private static int CameraXPos = 0;
        private static int scale = 1;

        public Camera()
        {
            Position = Vector2.Zero;
            Rotation = 0;
            Zoom = 1.0f;
        }

        public static int CenterOfScreen
        {
            get
            {
                return centerOfScreen;
            }
            set
            {
                centerOfScreen = value;
            }
        }

        public static int CenterOfCamera
        {
            get
            {
                return centerOfCamera;
            }
            set
            {
                centerOfCamera = value;
            }
        }

        public static int CameraX
        {
            get
            {
                return CameraXPos;
            }
            set
            {
                CameraXPos = value;
            }
        }

        public static Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }

        public float Zoom { get; set; }

        public float Rotation { get; set; }

        public Matrix GetViewMatrix(Vector2 parallax)
        {
            return Matrix.CreateTranslation(new Vector3(-Position * parallax, 0.0f)) *
                   Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(Zoom, Zoom, 1.0f) *
                   Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }

        public void LookAt(Vector2 position)
        {
            Position = position - new Vector2(_viewport.Width / 2.0f, _viewport.Height / 2.0f);
        }

        public void Move(IMario mario)
        {
            int fullWidthOfScreen = 2 * CenterOfScreen;
            int x = (int)-Position.X;

            foreach (int limitation in LimitationList)
            {
                if (x >= limitation - fullWidthOfScreen && x < limitation)
                {
                    Position = new Vector2(-(limitation - fullWidthOfScreen), 0);
                    return;
                }

            }

            int halfOfMarioWidth = MarioSpriteFactory.Instance.NormalMarioWidth / 2;

            if (((mario.Destination.X + halfOfMarioWidth) > centerOfCamera) && mario.Velocity.X >= 0)
            {
                Vector2 tempNewPos = new Vector2(-(mario.Location.X + halfOfMarioWidth - centerOfScreen), 0);
                if (-Position.X > -tempNewPos.X)
                {
                    return;
                }
                Position = new Vector2(-(mario.Location.X + halfOfMarioWidth - centerOfScreen), 0);
                CameraXPos = (int)-Position.X;
                centerOfCamera = CameraXPos + centerOfScreen;
            }
        }

        public static void SetCamera(Vector2 location)
        {
            CameraXPos = (int)location.X;
            centerOfCamera = (int)location.X + centerOfScreen;
            Position = new Vector2(-location.X, location.Y);
        }

        public static void ResetCamera()
        {
            CameraXPos = 0;
            centerOfCamera = centerOfScreen;
            Position = Vector2.Zero;
        }

        private readonly Viewport _viewport;
        private Vector2 _position;
        private Rectangle? _limits;
    }
}
