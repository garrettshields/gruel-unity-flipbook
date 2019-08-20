# **About**
A simple Flipbook system that can play a series of frames at a set frame rate.

Using Flipbooks means that Unity animations and controllers don't need to be created for simple one off sprite animations. Simply create a `FlipbookData` file, add the frames you want, the FPS, and material, and play it using a flipbook player like `SpriteFlipbook` on a `SpriteRenderer`.

# **FlipbookPlayers**
## **Flipbook base**

### API
* Properties:
	* `bool` Playing
	* `FlipbookData` FlipbookData
	* `bool` PlayOnStart
	* `bool` PlayAtRandomPlaybackPosition
	* `float` Delay
	* `bool` ClearLastFrame
	* `int` Frame

* Methods:
	* `void` Play(`bool` play)
	* `void` ClearFlipbookData()

## **SpriteFlipbook**
Type: `Component`  
Description: This component plays `SpriteFlipbookData` data files, using a `SpriteRenderer`.  

To use this Flipbook player:
1. Attach it and a `SpriteRenderer` component to a GameObject.
2. Add a reference to the `SpriteRenderer` component to `SpriteFlipbook`'s "SpriteRenderer" serialized field.

### API
* Properties:
	* `Color` Tint
	* `SpriteFlipbookData` SpriteFlipbookData

* Methods:
	* `void` Play(`SpriteFlipbookData` flipbookData)
	* `void` Play(`bool` play)
	* `void` ClearFlipbookData()

## **ImageFlipbook**
Type: `Component`  
Description: This component plays `SpriteFlipbookData` data files, using a `SpriteRenderer`.  

To use this Flipbook player:
1. Attach it and an `Image` component to a GameObject.
2. Add a reference to the `Image` component to `ImageFlipbook`'s "Image" serialized field.

### API
* Properties:
	* `Color` Tint
	* `SpriteFlipbookData` SpriteFlipbookData

* Methods:
	* `void` Play(`SpriteFlipbookData` flipbookData)
	* `void` Play(`bool` play)
	* `void` ClearFlipbookData()

# **FlipbookData**
Type: `Abstract base class`  
Description: This is the base class for all flipbook data files. Variations of it like `SpriteFlipbookData` are used to store information like what frames it has, if it loops, etc..  

Flipbook players can automatically play if a FlipbookData file has been linked in, or manually by calling either `Play(FlipbookData flipbookData)` or `Play(bool play)`.

There is currently only 1 type of concrete FlipbookData, `SpriteFlipbookData`.

## API
* Properties:
	* `bool` Loop
	* `int` FramesPerSecond
	* `float` FrameDelay
	* `float` Duration
	* `int` Length

## **SpriteFlipbookData**
Type: `ScriptableObject`  
Asset creation menu: `Create/Gruel/SpriteFlipbookData`  
Description: This is a concrete implementation of `FlipbookData`, and is specific to using `Sprites` as frames. It is the data file needed for both `SpriteFlipbook`, and `ImageFlipbook` flipbook players.

## API
* Properties:
	* `Material` Material
	* `int` Length