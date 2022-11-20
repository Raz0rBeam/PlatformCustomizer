using System;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;
using Zenject;
using UnityEngine.Sprites;

namespace PlatformCustomizer.CustomFeet
{
    public class TexChanger : IInitializable
    {
        public void Initialize()
        {
            var feet = GameObject.Find("Feet");
            var loadTexture = feet.GetComponent<SpriteRenderer>();
            /* Texture2D newTexture = new Texture2D(1024, 1024, TextureFormat.RGBA32, true);
             Sprite blankSprite = Sprite.Create(newTexture, new Rect(0, 0, 1024, 1024), new Vector2(0.5f, 0.5f));
             loadTexture.sprite = blankSprite;*/

            var newFeet = new GameObject("ReplacedFeet");
            newFeet.GetComponent<Tex>
        }
    }
}
