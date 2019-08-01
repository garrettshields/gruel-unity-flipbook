using UnityEngine;

namespace Gruel.Flipbook {
	public class SpriteFlipbook : Flipbook {
		
#region Properties
		public Color Tint {
			get => _spriteRenderer.color;
			set => _spriteRenderer.color = value;
		}

		public SpriteFlipbookData SpriteFlipbookData {
			get => _flipbookData;
			set => _flipbookData = value;
		}
#endregion Properties

#region Fields
		[Header("Sprite Flipbook Player Settings")]
		[SerializeField] private SpriteFlipbookData _flipbookData;
		
		[Header("Renderer")]
		[SerializeField] private SpriteRenderer _spriteRenderer;
#endregion Fields

#region Public Methods
		public void Play(SpriteFlipbookData flipbookData) {
			_flipbookData = flipbookData;
			
			Play(true);
		}

		public override void Play(bool play) {
			if (play) {
				_flipbookBaseData = _flipbookData;
				_spriteRenderer.material = _flipbookData.Material;
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
				_spriteRenderer.sprite = null;
			}
		}

		protected override void FrameChanged() {
			_spriteRenderer.sprite = _flipbookData[_frame];
		}

		protected override void ClearFrame() {
			_spriteRenderer.sprite = null;
		}
#endregion Protected Methods

	}
}