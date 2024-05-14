using Harmony;
using MelonLoader;
using RUMBLE.Managers;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

namespace AnotherCameraMod
{
	public static class Il2cppExtensions
	{
		public static T Find<T>(this Il2CppSystem.Collections.Generic.List<T> list, Func<T, bool> predicate)
		{
			foreach (var e in list)
				if (predicate(e)) return e;
			return default(T);
		}
	}

	public enum CameraControlState
	{
		None,
		GUI,
		FreeCam
	}

	public static class GOExtensions
	{
		public static RectTransform Fill(this RectTransform transform)
		{
			transform.anchorMin = new Vector2(0, 0);
			transform.anchorMax = new Vector2(1, 1);
			transform.pivot = new Vector2(0.5f, 0.5f);
			transform.sizeDelta = Vector2.zero;
			transform.anchoredPosition = Vector2.zero;
			return transform;
		}
	}

	public class AnotherCameraMod : MelonMod
	{
		public Camera camera;

		public RenderTexture targetTexture = null;
		//static InputActionMap actionMap = new InputActionMap("actionmap");
		

		public GameObject movementGO;
		public GameObject playerGO;

		CameraControlState state = CameraControlState.None;

		public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
			InputManager.Enable();

			camera = new GameObject("Another Camera").AddComponent<Camera>();
			camera.clearFlags = CameraClearFlags.Skybox;
			camera.cameraType = CameraType.SceneView;

			setupCanvas();

			System.Collections.IEnumerator tryFindObject()
			{
				yield return new WaitForSeconds(0.5f);
				playerGO = GameObject.Find("Player Controller(Clone)");
				movementGO = GameObject.Find("Movement");
			}

			MelonCoroutines.Start(tryFindObject());

			//if (!actionMap.enabled) actionMap.Enable();
		}

		RawImage img = null;
		Canvas gui;
		public void createGui()
		{
			gui = new GameObject("Another GUI").AddComponent<Canvas>();

			gui.renderMode = RenderMode.WorldSpace;

			{
				var transform = gui.GetComponent<RectTransform>();
				transform.position = Vector3.zero;
				transform.sizeDelta = new Vector2(100, 100);
				transform.localScale = new Vector3(1/transform.sizeDelta.x, 1/transform.sizeDelta.y, 1) * 2;
			}

			gui.GetComponent<CanvasScaler>().dynamicPixelsPerUnit = 5;


			var layout = new GameObject("Options").AddComponent<VerticalLayoutGroup>();
			layout.padding.top = 10;
			layout.padding.left = 10;
			layout.padding.right = 10;
			layout.padding.bottom = 10;

			layout.spacing = 20;

			layout.GetComponent<RectTransform>().Fill();
			layout.childControlWidth = true;

			// Test button
			{
				var btn = new GameObject("Test button").AddComponent<Button>();
				btn.onClick.AddListener(new Action(() => LoggerInstance.Msg("Clicked!")));
				
			}
		}
		public void Action()
		{

		}

		public void setupCanvas()
		{
			if (camera == null) throw new Exception("NO CAMERA");
			if (!(targetTexture is null)) GameObject.Destroy(targetTexture);
			targetTexture = new RenderTexture(1920, 1080, 24);
			camera.targetTexture = targetTexture;

			var canvas = new GameObject("Screen overlay").AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;

			var imageObject = new GameObject("Image");
			imageObject.transform.SetParent(canvas.gameObject.transform);
			imageObject.AddComponent<RectTransform>().Fill();
			img = imageObject.AddComponent<RawImage>();
			img.texture = targetTexture;
		}
		bool holdRightTriggerFlag = false;
		Quaternion? lockedRotation = null;
		public override void OnUpdate()
		{
			if (img != null && targetTexture != null)
				img.texture = targetTexture;

			if (movementGO == null || playerGO == null || camera == null) return;

			// Update control state

			switch (state)
			{
				case CameraControlState.FreeCam:
					camera.transform.position += 
						(
							InputManager.rightAxis.y * camera.transform.forward + 
							InputManager.leftAxis.y * camera.transform.up + 
							InputManager.rightAxis.x * camera.transform.right
						) * (InputManager.rightTrigger * 3 + 0.1f);
					if (InputManager.leftGrip > 0.5)
					{
						var lRot = (InputManager.leftRotation * Quaternion.Euler(90, 0, 0));
						if (lockedRotation is null)
							lockedRotation = camera.transform.rotation * Quaternion.Inverse(lRot);
						camera.transform.rotation = (Quaternion)lockedRotation * lRot;
					}
					else lockedRotation = null;

					break;
			}

			if (InputManager.rightJoystickClicked > 0.5)
			{
				if (!holdRightTriggerFlag)
					toggleFreeCam();
				holdRightTriggerFlag = true;
			} else { holdRightTriggerFlag = false; }
		}

		void toggleFreeCam()
		{
			if (movementGO == null || playerGO == null) return;
			if (state == CameraControlState.GUI) return;

			if (state == CameraControlState.None)
			{
				state = CameraControlState.FreeCam;
				movementGO.active = false;
			}
			else if (state == CameraControlState.FreeCam)
			{
				state = CameraControlState.None;
				movementGO.active = true;
			}
		}
	}
}
