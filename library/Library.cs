using Godot;

public partial class Library : Room {
    private Door _hallwayDoor;

    private Bookshelf[] _bookshelves;

    private bool _keyObtained;

    public override void _Ready()
    {
        base._Ready();

        GD.Print("Library _Ready()");

        _hallwayDoor = GetNode<Door>("HallwayDoor");

        _exitDoors.Add(_hallwayDoor, "res://hallway/hallway.tscn");

        _keyObtained = false;

        _bookshelves = new Bookshelf[3];

        for (int i=1; i<=3; i++) {
            _bookshelves[i-1] = GetNode<Bookshelf>($"Bookshelf{i}");
        }        
    }
}