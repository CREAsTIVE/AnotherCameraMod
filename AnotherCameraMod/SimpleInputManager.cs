using UnityEngine;
using UnityEngine.InputSystem;

namespace AnotherCameraMod
{
	// Make as separated library
	// TODO: Refactor this shit
	public class InputManager
	{
		// Right
		public static InputAction rightPositionAction = new InputAction("Right Position", InputActionType.Value, "<XRController>{LeftHand}/devicePosition");
		public static Vector3 rightPosition => rightPositionAction.ReadValue<Vector3>();

		public static InputAction rightRotationAction = new InputAction("Right Rotation", InputActionType.Value, "<XRController>{RightHand}/deviceRotation");
		public static Quaternion rightRotation => rightRotationAction.ReadValue<Quaternion>();

		public static InputAction rightAxisAction = new InputAction("Right Joystick", InputActionType.Value, "<XRController>{RightHand}/joystick");
		public static Vector2 rightAxis => rightAxisAction.ReadValue<Vector2>();

		public static InputAction rightTouchpadAction = new InputAction("Right Touchpad", InputActionType.Value, "<XRController>{RightHand}/touchpad");
		public static Vector2 rightTouchpad => rightTouchpadAction.ReadValue<Vector2>();

		public static InputAction rightGripAction = new InputAction("Right Grip", InputActionType.Value, "<XRController>{RightHand}/grip");
		public static float rightGrip => rightGripAction.ReadValue<float>();

		public static InputAction rightTriggerAction = new InputAction("Right Trigger", InputActionType.Value, "<XRController>{RightHand}/trigger");
		public static float rightTrigger => rightTriggerAction.ReadValue<float>();

		public static InputAction rightJoystickClickedAction = new InputAction("Right Joystick Clicked", InputActionType.Value, "<XRController>{RightHand}/joystickClicked");
		public static float rightJoystickClicked => rightJoystickClickedAction.ReadValue<float>();

		// TODO: DeviceVelocity

		public static InputAction rightPrimaryAction = new InputAction("Right Primary Button", InputActionType.Value, "<XRController>{RightHand}/joystickClicked");
		public static float rightPrimary => rightPrimaryAction.ReadValue<float>();

		public static InputAction rightSecondaryAction = new InputAction("Right Secondary Button", InputActionType.Value, "<XRController>{RightHand}/joystickClicked");
		public static float rightSecondary => rightSecondaryAction.ReadValue<float>();

		// Left
		public static InputAction leftPositionAction = new InputAction("Left Position", InputActionType.Value, "<XRController>{LeftHand}/devicePosition");
		public static Vector3 leftPosition => leftPositionAction.ReadValue<Vector3>();

		public static InputAction leftRotationAction = new InputAction("Left Rotation", InputActionType.Value, "<XRController>{LeftHand}/deviceRotation");
		public static Quaternion leftRotation => leftRotationAction.ReadValue<Quaternion>();

		public static InputAction leftAxisAction = new InputAction("Left Joystick", InputActionType.Value, "<XRController>{LeftHand}/joystick");
		public static Vector2 leftAxis => leftAxisAction.ReadValue<Vector2>();

		public static InputAction leftTouchpadAction = new InputAction("Left Touchpad", InputActionType.Value, "<XRController>{LeftHand}/touchpad");
		public static Vector2 leftTouchpad => leftTouchpadAction.ReadValue<Vector2>();

		public static InputAction leftGripAction = new InputAction("Left Grip", InputActionType.Value, "<XRController>{LeftHand}/grip");
		public static float leftGrip => leftGripAction.ReadValue<float>();

		public static InputAction leftTriggerAction = new InputAction("Left Trigger", InputActionType.Value, "<XRController>{LeftHand}/trigger");
		public static float leftTrigger => leftTriggerAction.ReadValue<float>();

		public static InputAction leftJoystickClickedAction = new InputAction("Left Joystick Clicked", InputActionType.Value, "<XRController>{LeftHand}/joystickClicked");
		public static float leftJoystickClicked => leftJoystickClickedAction.ReadValue<float>();

		// TODO: DeviceVelocity

		public static InputAction leftPrimaryAction = new InputAction("Left Primary Button", InputActionType.Value, "<XRController>{LeftHand}/joystickClicked");
		public static float leftPrimary => leftPrimaryAction.ReadValue<float>();

		public static InputAction leftSecondaryAction = new InputAction("Left Secondary Button", InputActionType.Value, "<XRController>{LeftHand}/joystickClicked");
		public static float leftSecondary => leftSecondaryAction.ReadValue<float>();

		public static void Enable()
		{
			// TODO: OMG MY EYES
			if (!rightPositionAction.enabled) rightPositionAction.Enable();
			if (!rightRotationAction.enabled) rightRotationAction.Enable();
			if (!rightAxisAction.enabled) rightAxisAction.Enable();
			if (!rightTouchpadAction.enabled) rightTouchpadAction.Enable();
			if (!rightGripAction.enabled) rightGripAction.Enable();
			if (!rightTriggerAction.enabled) rightTriggerAction.Enable();
			if (!rightJoystickClickedAction.enabled) rightJoystickClickedAction.Enable();
			if (!rightPrimaryAction.enabled) rightPrimaryAction.Enable();
			if (!rightSecondaryAction.enabled) rightSecondaryAction.Enable();

			if (!leftPositionAction.enabled) leftPositionAction.Enable();
			if (!leftRotationAction.enabled) leftRotationAction.Enable();
			if (!leftAxisAction.enabled) leftAxisAction.Enable();
			if (!leftTouchpadAction.enabled) leftTouchpadAction.Enable();
			if (!leftGripAction.enabled) leftGripAction.Enable();
			if (!leftTriggerAction.enabled) leftTriggerAction.Enable();
			if (!leftJoystickClickedAction.enabled) leftJoystickClickedAction.Enable();
			if (!leftPrimaryAction.enabled) leftPrimaryAction.Enable();
			if (!leftSecondaryAction.enabled) leftSecondaryAction.Enable();
		}
	}
}
