using Godot;

public partial class GameConstants
{
    // Animationss
    public const string ANIM_IDEL = "Idle";
    public const string ANIM_MOVE = "Move";
    public const string ANIM_DASH = "Dash";
    public const string ANIM_ATTACK = "Attack";
    public const string ANIM_DEATH = "Death";
    public const string ANIM_EXPAND = "Expand";
    public const string ANIM_EXPLOSION = "Explosion";
    public const string ANIM_STUN = "Stun";

    // Inputs
    public const string INPUT_MOVE_LEFT = "MoveLeft";
    public const string INPUT_MOVE_RIGHT = "MoveRight";
    public const string INPUT_MOVE_FORWARD = "MoveForward";
    public const string INPUT_MOVE_BACKWARD = "MoveBackward";
    public const string INPUT_DASH = "Dash";
    public const string INPUT_ATTACK = "Attack";

    public const string INPUT_PAUSE = "Pause";
    public const string INPUT_CONTINUE = "Continue";

    public const string INPUT_INTERACT = "Interact";

    // notifications
    public const int NOTIFICATION_ENTER_STATE = 5001;
    public const int NOTIFICATION_EXIT_STATE = 5002;
}