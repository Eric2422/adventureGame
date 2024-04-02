using Godot;
using System.Collections.Generic;

public partial class SceneManager : Node
{
	// The directory where scenes are stored
	private static string _sceneDirectory = "./scenes/";

	/// <summary>
	/// Changes the scene from the current scene to the next scene.
	/// Transfers the player from this scene to the next.
	/// </summary>
	/// <param name="nextScene">The next scene to be loaded.</param>
	/// <param name="player">The player Node that is being used in the current scene.</param>
	public static void ChangeScene(string nextScene, Player player)
	{
		// Store the player's current scene.
		Node currentScene = player.GetParent();
		currentScene.RemoveChild(player);

		// Load the next scene.
		string scenePath = _sceneDirectory + nextScene + ".tscn";
		Room newScene = (Room)ResourceLoader.Load<PackedScene>(scenePath).Instantiate();

		newScene.AddChild(player);
		currentScene.GetTree().Root.AddChild(newScene);

		// Reposition the player to the appropriate door.
		GD.Print("EntrancePositions:");
		foreach (string key in newScene.EntrancePositions.Keys) {
			GD.Print(newScene.EntrancePositions[key]);
		}

		Vector2 position = newScene.EntrancePositions[currentScene.Name];
		player.Position = position;

		// Remove the old scene.
		currentScene.QueueFree();
	}
}
