namespace Util
{
  public static class Define
  {
    public enum Layer
    {
      Ground = 6,
      Monster = 7,
      Block = 8
    }

    public enum MouseEvent
    {
      PointerDown,
      Press,
      PointerUp,
      Click
    }

    public enum CameraView
    {
      QuaterView
    }

    public enum UIEvent
    {
      Click,
      Drag
    }

    public enum Scene
    {
      Unknown,
      Login,
      Lobby,
      Game
    }

    public enum Sound
    {
      Sfx,
      Bgm,
      MaxCount
    }

    public static int GetMask(this Layer layer) => 1 << (int)layer;
    public static int GetLayer(this Layer layer) => (int)layer;
  }
}