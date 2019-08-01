using UnityEngine;
using UnityEngine.UI;

namespace Gruel.Flipbook {
	public class ImageFlipbook : Flipbook {
		
#region Properties
		public Color Tint {
			get => _image.color;
			set => _image.color = value;
		}
		
		public SpriteFlipbookData SpriteFlipbookData {
			get => _flipbookData;
			set => _flipbookData = value;
		}
#endregion Properties

#region Fields
		[Header("Image Flipbook Player Settings")]
		[SerializeField] private SpriteFlipbookData _flipbookData;
		
		[Header("Renderer")]
		[SerializeField] private Image _image;
#endregion Fields

#region Public Methods
		public void Play(SpriteFlipbookData flipbookData) {
			_flipbookData = flipbookData;
			
			Play(true);
		}

		public override void Play(bool play) {
			if (play) {
				_flipbookBaseData = _flipbookData;
				_image.material = _flipbookData.Material;
			}
			
			base.Play(play);
		}
		
		public override void ClearFlipbookData() {
			base.ClearFlipbookData();
			_flipbookData = null;
		}
#endregion Public Methods
		
#region Protected Methods
		protected override void FinishedPlaying() {
			base.FinishedPlaying();
			
			if (_clearLastFrame) {
				_image.sprite = null;
			}
		}

		protected override void FrameChanged() {
			_image.sprite = _flipbookData[_frame];
		}

		protected override void ClearFrame() {
			_image.sprite = null;
		}
#endregion Protected Methods

	}
}